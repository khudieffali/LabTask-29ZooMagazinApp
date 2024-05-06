using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabTask_29.Models
{
    internal class Product
    {
        public int Id { get; set; } = 0;
        public static int Count { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public static List<Product> Products { get; set; } = new();
        public static List<Product> SelectedProducts { get; set; } = new();
        public Product(string name,string description)
        {
                Name = name;
              Description = description;
            Count++;
            Id = Count;
        }
        public Product()
        {
          
        }
        public List<Product> Add()
        {
            Console.WriteLine("Mehsul adi daxil edin: ");
            string productName = Console.ReadLine();
            Console.WriteLine("Aciqlama daxil edin: ");
            string description = Console.ReadLine();
            Product product=new(productName,description);
            Products.Add(product);
            return Products;
        }
        public void Remove(Product product)
        {
            Products.Remove(product);   
        }
        public List<Product> GetByIdProductsAddBasket(string[] idList)
        {
            if (idList.Count() != 0)
            {
                foreach (var item in idList)
                {

                    foreach (var item1 in Products)
                    {
                        if (item1.Id == Convert.ToInt32(item))
                        {
                            SelectedProducts.Add(item1);
                        }
                    }
                }
                Console.WriteLine("Secdiyiniz mehsullar ugurla sebete elave olundu");
                return SelectedProducts;
            }
            else return null;

        }
    }
}
