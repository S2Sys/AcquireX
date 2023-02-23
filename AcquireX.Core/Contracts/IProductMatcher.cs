using AcquireX.Core.Model;

namespace AcquireX.Core.Contracts
{
    public interface IProductMatcher
    {
        IList<Product> Match(IList<Product> source, IList<Product> target);
    }


}
