using AutoMapper;
using Domain.Entities;
using Services.Abstractions;
using Services.Contracts;
using Services.Repositories.Abstractions;

namespace Services.Implementations;

public class ParkingService:IParkingService
{
    private readonly IParkingRepository _repository;
    private readonly IMapper _mapper;

    public ParkingService(IParkingRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <summary>
    /// Получить список парковок
    /// </summary>
    /// <param name="page">Номер страницы</param>
    /// <param name="pageSize">Размер страниц</param>
    /// <param name="token">Токен отмены</param>
    /// <returns>Занные для указанной страницы</returns>
    public async Task<ICollection<ParkingDTO>> GetPaged(int page, int pageSize, CancellationToken token)
    {
        ICollection<Parking> parkingCollection =await _repository.GetPagedAsync(page, pageSize, token);

        return _mapper.Map<ICollection<Parking>,ICollection<ParkingDTO>>(parkingCollection);
    }

    /// <summary>
    /// Получить
    /// </summary>
    /// <param name="id">Идентификатиор</param>
    /// <returns>ДТО парковки</returns>
    public async Task<ParkingDTO> GetByID(int id)
    {
        var entity = await _repository.GetAsync(id);
        return _mapper.Map<Parking, ParkingDTO>(entity);
    }

    /// <summary>
    /// Создать
    /// </summary>
    /// <param name="parkingDto">Данные</param>
    /// <param name="token">Токен отмены</param>
    /// <returns>Ключ вставленной записи</returns>
    public async Task<int> Create(ParkingDTO parkingDto, CancellationToken token)
    {
        var parking = _mapper.Map<Parking>(parkingDto);
        var result =  _repository.Add(parking);
        await _repository.SaveChangesAsync(token);
        return result.Id;
    }

    /// <summary>
    /// Обновить
    /// </summary>
    /// <param name="id">Идентификатор изменяемой записи</param>
    /// <param name="dto">новые данные</param>
    /// <param name="token">Токен отмены</param>
    public async Task Update(int id, ParkingDTO dto, CancellationToken token)
    {
        var entity = _mapper.Map<ParkingDTO,Parking>(dto);
        entity.Id = id;
        _repository.Update(entity);
        await _repository.SaveChangesAsync(token);
    }

    /// <summary>
    /// Удалить 
    /// </summary>
    /// <param name="id">Идентификатоор удаляемой записи</param>
    /// <param name="token">Токен отмены</param>
    public async Task Delete(int id, CancellationToken token)
    {
        _repository.Delete(id);
        await _repository.SaveChangesAsync(token);
    }
}