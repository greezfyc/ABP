using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace LearningMpaAbp.EntityFramework.Repositories
{
    /// <summary>
    /// 框架自行创建的抽象类
    /// 通过模板建立的项目已经定义了一个仓储基类：SimpleTaskSystemRepositoryBase（这是一种比较好的实践，因为以后可以在这个基类中添加通用的方法）。
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public abstract class LearningMpaAbpRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<LearningMpaAbpDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected LearningMpaAbpRepositoryBase(IDbContextProvider<LearningMpaAbpDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class LearningMpaAbpRepositoryBase<TEntity> : LearningMpaAbpRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected LearningMpaAbpRepositoryBase(IDbContextProvider<LearningMpaAbpDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
