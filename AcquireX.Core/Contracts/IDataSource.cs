using AcquireX.Core.Model;

namespace AcquireX.Core.Contracts
{
    public interface IDataSource
    {
        Task<IList<Product>> GetProductsAsync();
    }

}
