﻿using Shop.Infrastructure.Config;
using Shop.Infrastructure.Config.Abstractions;

namespace Shop.Api.Modules.ConfigModule;

public class ProgramHeaderResolutionStrategy : IProgramResolutionStrategy
{
    private readonly HttpContext? _httpContext;

    public ProgramHeaderResolutionStrategy(IHttpContextAccessor httpContextAccessor)
    {
        _httpContext = httpContextAccessor.HttpContext;
    }

    public Task<string> GetProgramIdentifierAsync()
    {
        if (_httpContext is null)
            return Task.FromResult(string.Empty);
        return Task.FromResult(_httpContext.Request.Headers[ConfigConstants.ProgramIdentifierHeaderName].ToString());
    }
}
