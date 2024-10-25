using DomainCommon.Model;

namespace Justhis.InfrastructureCommon
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="obj"></param>
        Task AddAsync(TEntity obj);
        /// <summary>
        /// 根据id获取对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync(Guid id);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync();
        /// <summary>
        /// 根据对象进行更新
        /// </summary>
        /// <param name="obj"></param>
        Task UpdateAsync(TEntity obj);
        /// <summary>
        /// 根据id删除
        /// </summary>
        /// <param name="id"></param>
        Task RemoveAsync(Guid id);


    }
}
