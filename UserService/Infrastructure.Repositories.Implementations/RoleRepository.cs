// using Domain.Entities;
// using Infrastructure.EntityFramework;
// using Microsoft.EntityFrameworkCore;
// using Services.Repositories.Abstractions;
//
// namespace Infrastructure.Repositories.Implementations;
// public class RoleRepository: Repository<Role, int>, IRoleRepository
// {
//     public RoleRepository(DatabaseContext context) : base(context)
//     {
//     }
//
//     public async Task<ICollection<Role>> GetPagedAsync(int page, int pageSize, CancellationToken token)
//     {
//         return await GetAll().OrderBy(x => x.Id).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(token);
//     }
// }
