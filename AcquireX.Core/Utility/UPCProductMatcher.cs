using AcquireX.Core.Contracts;
using AcquireX.Core.Model;

namespace AcquireX.Core.Utility
{
    public class UPCProductMatcher : IProductMatcher
    {
        public IList<Product> Match(IList<Product> source, IList<Product> target)
        {
            var matchedProducts = new List<Product>();

            matchedProducts.AddRange(from s in source
                                      join t in target on s.Upc equals t.Upc
                                      select s);

            matchedProducts.AddRange(from s in source
                                      join t in target on s.Upc equals t.Upc
                                      select t);

            return matchedProducts.OrderBy(i => i.Upc).ToList();
        }
    }

}
