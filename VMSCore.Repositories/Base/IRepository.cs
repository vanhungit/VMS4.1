using System;
using System.Collections.Generic;

namespace VMSCore.Infrastructure.Base.Repositories
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        void Delete(T entity);
        void DeleteById(Guid id);
        void DeleteByCondition(Func<T, bool> expression);
        void DeleteRange(List<T> entities);
        void DeleteRangeById(List<Guid> ids);
        void DeleteRangeByIdStr(List<string> ids);
        List<T> GetAll();
        List<T> GetAllByToken();
        List<T> GetAllByCondition(Func<T, bool> expression, Func<T, object> orderBy = null, int skip = 0, int take = int.MaxValue);
        T GetById(Guid id);
        T GetByCode(string code);
        T GetByIdStr(string id);
        T Update(T entity);

    }
}
