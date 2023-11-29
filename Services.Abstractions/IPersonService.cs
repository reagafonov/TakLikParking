﻿using Services.Contracts;

namespace Services.Abstractions;
public interface IPersonService
{
    /// <summary>
    /// Получить список
    /// </summary>
    /// <param name="page">номер страницы</param>
    /// <param name="pageSize">объем страницы</param>
    /// <returns></returns>
    Task<ICollection<PersonDto>> GetPaged(int page, int pageSize);

    /// <summary>
    /// Получить
    /// </summary>
    /// <param name="id">идентификатор</param>
    /// <returns>ДТО курса</returns>
    Task<PersonDto> GetById(int id);

    /// <summary>
    /// Создать
    /// </summary>
    /// <param name="PersonDto">ДТО курса</para
    Task<int> Create(PersonDto PersonDto);

    /// <summary>
    /// Изменить
    /// </summary>
    /// <param name="id">идентификатор</param>
    /// <param name="PersonDto">ДТО курса</param>
    Task Update(int id, PersonDto PersonDto);

    /// <summary>
    /// Удалить
    /// </summary>
    /// <param name="id">идентификатор</param>
    Task Delete(int id);
}
