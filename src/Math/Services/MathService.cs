﻿using Math.Services;

namespace Math.API.Services;

public class MathService : IMathService
{

    public Task<long> AddAsync(long a, long b, CancellationToken cancellationToken = default)
    {
        var result = checked(a + b);
        return Task.FromResult(result);
    }
}