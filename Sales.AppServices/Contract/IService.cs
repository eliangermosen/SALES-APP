using Sales.AppServices.Core;

namespace Sales.AppServices.Contract
{
    public interface IService<TPost, TPut>
    {
        Task<ServiceResult> Save(TPost entity);
        Task<ServiceResult> Update(int id, TPut entity);
        Task<ServiceResult> GetAll();
        Task<ServiceResult> GetById(int id);
    }
}
