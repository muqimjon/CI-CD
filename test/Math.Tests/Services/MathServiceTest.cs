﻿using Math.Services;
using Math.API.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Math.Tests.Services;

public class MathServiceTest
{
    private readonly ServiceProvider service;

    public MathServiceTest()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddTransient<IMathService, MathService>();

        this.service = serviceCollection.BuildServiceProvider();
    }

    [Fact]
    public async void ShouldAddTwoNumberCorrect()
    {
        var mathService = service.GetRequiredService<IMathService>();

        var a = 1;
        var b = 4;

        var result = await mathService.AddAsync(a, b, CancellationToken.None);

        Assert.Equal(5, result);
    }

    [Theory]
    [InlineData(long.MaxValue, 1)]
    [InlineData(long.MinValue, -1)]
    public async void ShouldAddTwoNumberExcept(long a, long b)
    {
        var mathService = service.GetRequiredService<IMathService>();

        var task = async () => await mathService.AddAsync(a, b, CancellationToken.None);

        await Assert.ThrowsAsync<OverflowException>(task);
    }
}