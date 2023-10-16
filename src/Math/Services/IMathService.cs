namespace Math.Services;

public interface IMathService
{
    Task<long> AddAsync(long x, long y, CancellationToken cancellationToken); 
}
