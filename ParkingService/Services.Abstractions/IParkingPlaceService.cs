using Services.Contracts;

namespace Services.Abstractions;

public interface IParkingPlaceService
{
    /// <summary>
    /// Получить список парковок
    /// </summary>
    /// <param name="page">Номер страницы</param>
    /// <param name="pageSize">Размер страниц</param>
    /// <param name="token">Токен отмены</param>
    /// <returns>Занные для указанной страницы</returns>
    Task<ICollection<ParkingDTO>> GetPaged(int page, int pageSize, CancellationToken token);

    /// <summary>
    /// Получить
    /// </summary>
    /// <param name="id">Идентификатиор</param>
    /// <returns>ДТО парковки</returns>
    Task<ParkingDTO> GetByID(int id);

    /// <summary>
    /// Создать
    /// </summary>
    /// <param name="parkingDto">Данные</param>
    /// <param name="token">Токен отмены</param>
    /// <returns>Ключ вставленной записи</returns>
    Task<int> Create(ParkingDTO parkingDto, CancellationToken token);

    /// <summary>
    /// Обновить
    /// </summary>
    /// <param name="id">Идентификатор изменяемой записи</param>
    /// <param name="dto">новые данные</param>
    /// <param name="token">Токен отмены</param>
    Task Update(int id, ParkingDTO dto, CancellationToken token);

    /// <summary>
    /// Удалить 
    /// </summary>
    /// <param name="id">Идентификатоор удаляемой записи</param>
    /// <param name="token">Токен отмены</param>
    Task Delete(int id, CancellationToken token);
}