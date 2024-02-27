using Services.Contracts;

namespace Services.Abstractions;

public interface ICommonCrudService<TDto,TKey> where TDto:class 
{
    /// <summary>
    /// Создать
    /// </summary>
    /// <param name="PersonDto">ДТО </para>
    Task<TKey> Create(TDto parkingDto, CancellationToken token);
    
    /// <summary>
    /// Удалить
    /// </summary>
    /// <param name="id">идентификатор</param>
    Task DeleteAsync(TKey id, CancellationToken token);
    
    /// <summary>
    /// Изменить
    /// </summary>
    /// <param name="id">идентификатор</param>
    /// <param name="PersonDto">ДТО</param>
    Task Update(TKey id, TDto dto, CancellationToken token);

    /// <summary>
    /// Получить
    /// </summary>
    /// <param name="id">идентификатор</param>
    /// <param name="token"></param>
    /// <returns>ДТО</returns>
    Task<TDto> GetByID(TKey id, CancellationToken token);
    
    /// <summary>
    /// Получить список
    /// </summary>
    /// <param name="page">номер страницы</param>
    /// <param name="pageSize">объем страницы</param>
    /// <returns></returns>
    Task<ICollection<TDto>> GetPaged(int page, int pageSize, CancellationToken token);
}