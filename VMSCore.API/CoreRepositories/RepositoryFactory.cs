using System;
using VMSCore.Infrastructure.Base.Repositories;

public interface IRepositoryFactory
{
    dynamic Create(Type entityType);
}

public class RepositoryFactory : IRepositoryFactory
{
    private readonly IServiceProvider _serviceProvider;

    public RepositoryFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public dynamic Create(Type entityType)
    {
        var repoType = typeof(IRepository<>).MakeGenericType(entityType);
        return _serviceProvider.GetService(repoType);
    }
}