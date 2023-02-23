using AcquireX.Core.DTO;
using AcquireX.Core.Model;

namespace AcquireX.Core.Utility
{
    public static class ConvertExtentions

    {
        public static List<Product> ToDTO(this List<BannerProduct> items)
        {
            return (from item in items
                    select new Product
                    {
                        Brand = item.Brand,
                        ItemCode = item.ItemCode,
                        Manufacturer = item.Manufacturer,
                        Name = item.Name,
                        Price = item.Price,
                        Upc = item.Upc
                    }).ToList();
        }

        public static List<Product> ToDTO(this List<RSHughesProduct> items)
        {
            return (from item in items
                    select new Product
                    {
                        Brand = item.Brand,
                        ItemCode = item.ItemCode,
                        Manufacturer = item.Manufacturer,
                        Name = item.Name,
                        Price = item.Price,
                        Upc = item.Upc
                    }).ToList();
        }
    }
}

