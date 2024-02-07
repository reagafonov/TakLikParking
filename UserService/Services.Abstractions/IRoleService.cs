// using Services.Contracts;
//
// namespace Services.Abstractions;
//
// public interface IRoleService
// {
//     /// <summary>
//     /// Создать
//     /// </summary>
//     /// <param name="PersonDto">ДТО пользователя</para>
//     Task<int> Create(RoleDto parkingDto, CancellationToken token);
//     
//     /// <summary>
//     /// Удалить
//     /// </summary>
//     /// <param name="id">идентификатор</param>
//     Task Delete(int id, CancellationToken token);
//     
//     /// <summary>
//     /// Изменить
//     /// </summary>
//     /// <param name="id">идентификатор</param>
//     /// <param name="PersonDto">ДТО пользователя</param>
//     Task Update(int id, RoleDto dto, CancellationToken token);
//     
//     /// <summary>
//     /// Получить
//     /// </summary>
//     /// <param name="id">идентификатор</param>
//     /// <returns>ДТО пользоваиеля</returns>
//     Task<RoleDto> GetByID(int id);
//     
//     /// <summary>
//     /// Получить список
//     /// </summary>
//     /// <param name="page">номер страницы</param>
//     /// <param name="pageSize">объем страницы</param>
//     /// <returns></returns>
//     Task<ICollection<RoleDto>> GetPaged(int page, int pageSize, CancellationToken token);
// }