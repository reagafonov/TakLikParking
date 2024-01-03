namespace Services.Contracts.Abstractions;

public interface IPage
{
    public int Skip { get; set; }
    
    public int Take { get; set; }
}