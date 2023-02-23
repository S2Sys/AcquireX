using AcquireX.Core.Contracts;
using AcquireX.Core.DTO;
using AcquireX.Core.Model;

namespace AcquireX.Core.Services
{
    public class ProductMatcherService : IProductMatcher
    {
        public IList<Product> Fetch(IList<Product> source, IList<Product> target)
        { 
            var products = new List<Product>();

            if (source.Any() && target.Any())
            {
                products.AddRange(from s in source
                                  join t in target on s.Upc equals t.Upc
                                  select s);

                products.AddRange(from s in source
                                  join t in target on s.Upc equals t.Upc
                                  select t);
            }

            return products.OrderBy(i => i.Upc).ToList();
        }
    }

}
