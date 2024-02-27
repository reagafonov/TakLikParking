using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Services.Abstractions;
using Services.Contracts;
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
    private readonly ICommonCrudService<UserDTO,string> _loginStore;
    private readonly string _issuer;
    private readonly string _audience;
    private readonly string _key;
    
    public UserController(IMapper mapper,
        IConfiguration configuration, ICommonCrudService<UserDTO, string> loginStore)
    {
        _mapper = mapper;
        _loginStore = loginStore;
        var jwtSettings = configuration.GetSection("jwtOptions");
        _issuer = jwtSettings["Issuer"];
        _audience = jwtSettings["audience"];
        _key = jwtSettings["SecurityKey"];
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public virtual async Task<IActionResult> Login([FromBody]UserLogin loginData, CancellationToken token)
    {
        await Task.Delay(2000, token);
        IList<Claim> claimsAsync;

        if (loginData.Login == "Admin" && loginData.Password == "super")
        {
            claimsAsync = new List<Claim>()
            {
                new(ClaimTypes.Role, RolesEnum.SuperAdmin.GetRoleName())
            };
        }
        else
        {
            var findByIdAsync = await _loginStore.GetByID(loginData.Login, token);
            if (findByIdAsync is null)
            {
                return Forbid("Пользователь не найден");
            }

            var loggedIn = findByIdAsync.Password == loginData.Password;
            if (!loggedIn)
            {
                return new JsonResult(new JwtResponse()
                {
                    IsAuthorized = false,
                    Reason = "Неправильный пароль"
                });
            }

            claimsAsync = Enum.GetValues<RolesEnum>().Where(x=>findByIdAsync.Roles.HasFlag(x)).Select(x=>x.GetRoleName())
                .Select(x=>new Claim(ClaimTypes.Role,x)).ToList();
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

    
    [HttpPost("register")]
    [AllowAnonymous]
    public virtual async Task<IActionResult> Register([FromBody] UserInfo userModel, CancellationToken token)
    {
        await Task.Delay(2000, token);

        var existedUser = await _loginStore.GetByID(userModel.UserName,token);
        if (existedUser is not null)
        {
            return BadRequest("Пользователь уже существует");
        }

        var roles = userModel.Roles;
        if (roles.Any(x=> x != RolesEnum.Client) &&
            User.IsInRole(RolesEnum.SuperAdmin))
            return BadRequest("Нет доступа");

        
        var user = _mapper.Map<UserDTO>(userModel);
        var role = roles.FirstOrDefault();
        foreach (var rolesEnum in roles.Skip(1))
        {
            role |= rolesEnum;
        }

        user.Roles = role;
        await _loginStore.Create(user,token);
        return Ok();
    }
    
    [HttpPut("change-password")]
    public virtual async Task<IActionResult> EditAsync([FromBody]ResetPasswordRequest request, CancellationToken token)
    {
        if (!User.IsInRole(RolesEnum.SuperAdmin) && User.Identity.Name != request.Login) 
            return Unauthorized(JwtBearerDefaults.AuthenticationScheme);
        var user = await _loginStore.GetByID(request.Login, token);
        if (user is null)
            return NotFound("User");
        token.ThrowIfCancellationRequested();
        
        user.Password = request.NewPassword;
        await _loginStore.Update(user.ID, user, token);
       
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromBody]string login, [FromBody]string password, CancellationToken token)
    {
        if ((!(User.Identity?.IsAuthenticated ?? false)) ||
            (User.FindFirst("super_admin") is null && User.Identity.Name != login)) return Unauthorized();
        var user = await _loginStore.GetByID(login,token);
        if (user is null)
            return NotFound("user");
        await _loginStore.DeleteAsync(user.ID,token);
        return Ok();

    }
}