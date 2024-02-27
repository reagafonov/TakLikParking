using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Asp.Versioning;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using WebApi.Models;
using  WebApi.Extensions;

namespace WebApi.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]

[Authorize]
public class UserController:ControllerBase
{
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly IUserLoginStore<User> _loginStore;
    private readonly string _issuer;
    private readonly string _audience;
    private readonly string _key;
    
    public UserController(IMapper mapper,
        UserManager<User> userManager,
        IUserLoginStore<User> loginStore,
        IConfiguration configuration,
        SignInManager<User> signInManager)
    {
        _mapper = mapper;
        _userManager = userManager;
        _loginStore = loginStore;
        var jwtSettings = configuration.GetSection("jwtOptions");
        _issuer = jwtSettings["Issuer"];
        _audience = jwtSettings["audience"];
        _key = jwtSettings["key"];
    }

    [HttpPost]
    [AllowAnonymous]
    public virtual async Task<IActionResult> Login(string username, string password, CancellationToken token)
    {
        await Task.Delay(2000, token);
        IList<Claim> claimsAsync;

        if (username == "Admin" && password == "super")
        {
            claimsAsync = new List<Claim>()
            {
                new Claim(ClaimTypes.Role, RolesEnum.SuperAdmin.GetRoleName())
            };
        }
        else
        {
            var findByIdAsync = await _loginStore.FindByIdAsync(username, token);
            if (findByIdAsync is null)
            {
                return Forbid("Пользователь не найден");
            }

            var loggedIn = await _userManager.CheckPasswordAsync(findByIdAsync, password);
            if (!loggedIn)
            {
                return Forbid("Неправильный пароль");
            }

            claimsAsync = await _userManager.GetClaimsAsync(findByIdAsync);
        }
        var jwt = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claimsAsync,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key)),
                SecurityAlgorithms.HmacSha256)
        );
        var writeToken = new JwtSecurityTokenHandler().WriteToken(jwt);
        var response = new JwtResponse()
        {
            IsAuthorized = true,
            access_token = writeToken
        };
        return new JsonResult(response);

    }

    
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public virtual async Task<IActionResult> Register([FromBody] UserInfo userModel, CancellationToken token)
    {
        await Task.Delay(2000, token);

        var existedUser = await _userManager.FindByIdAsync(userModel.UserName);
        if (existedUser is not null)
        {
            return BadRequest("Пользователь уже существует");
        }

        var roles = userModel.Roles;
        if (roles.Any(x=> x != RolesEnum.Client) &&
            User.IsInRole(RolesEnum.SuperAdmin))
            return BadRequest("Нет доступа");

        
        var user = _mapper.Map<User>(userModel);
        await _userManager.CreateAsync(user, userModel.Password);
        var claims = roles.Select(x=>  x.GetRoleName())
            .Select(x=>new Claim(ClaimTypes.Role,x));
        await _userManager.AddClaimsAsync(user, claims);
        return Ok();
    }
    
    [HttpPut]
    public virtual async Task<IActionResult> EditAsync([FromBody]ResetPasswordRequest request, CancellationToken token)
    {
        if (!User.IsInRole(RolesEnum.SuperAdmin) && User.Identity.Name != request.Login) 
            return Forbid();
        var user = await _userManager.FindByIdAsync(request.Login);
        if (user is null)
            return NotFound("User");
        token.ThrowIfCancellationRequested();
        var result = await _userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);
        if (!result.Succeeded)
            return Forbid(JsonConvert.SerializeObject(result.Errors));
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromBody]string login, [FromBody]string password, CancellationToken token)
    {
        if ((!(User.Identity?.IsAuthenticated ?? false)) ||
            (User.FindFirst("super_admin") is null && User.Identity.Name != login)) return Forbid();
        var user = await _userManager.FindByIdAsync(login);
        if (user is null)
            return NotFound("user");
        var result = await _userManager.DeleteAsync(user);
        if (!result.Succeeded)
            return Forbid(JsonConvert.SerializeObject(result.Errors));
        return Ok();

    }
}