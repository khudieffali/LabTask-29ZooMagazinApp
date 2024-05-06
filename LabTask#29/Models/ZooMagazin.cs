using LabTask_29.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabTask_29.Models
{
    internal class ZooMagazin:IZooMagazin
    {
        public int Id { get; set; }
        public static int Count { get; set; }
        public static string Name { get; set; }
        public static List<Product> Products { get; set; }
        public static int Stock { get; set; }
        public static List<int> SelectedProducts { get; set; }

        public void Add()
        {
           Product product = new();
            if (Count < 1)
            {
                Console.WriteLine("Magazin adi qeyd edin:");
                string name = Console.ReadLine();
                Name = name;
                Count++;
                Id = Count;
            }
            var productList=product.Add();
            Products=productList;
            Stock++;
        }

        public void Delete(int id)
        {
            Product product=new();
            if (Products != null && Products.Count != 0)
            {
                foreach (var item in Products)
                {
                    if (item.Id == id)
                    {
                        product.Remove(item);
                        Console.WriteLine("Mehsul ugurla silindi");
                        Stock--;    
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Mehsul movcud deyil zehmet olmasa elave edin");
            }
        }

  

        public void Update(int id)
        {
            int count = 0;
            foreach (var item in Products)
            {
                if (item.Id == id)
                {
                    Console.WriteLine("Mehsul adi daxil edin: ");
                    string productName = Console.ReadLine();
                    Console.WriteLine("Aciqlama daxil edin: ");
                    string description = Console.ReadLine();
                    item.Name = productName;
                    item.Description = description;
                    count++;   
                    Console.WriteLine("Deyisiklik elave olundu");
                }
            }
            if(count == 0) { Console.WriteLine("Bu Id de mehsul movcud deyil"); }
        }
        public List<Product> GetAll()
        {
            if (Products != null && Products.Count != 0)
            {
                return Products;
              
            }
            else
            {
                return null; 
            }
        }

        public void DoSale()
        {
            List<Product> SaleProducts = new();
            if (Customer.NameStatic != null)
            {
                if (Product.SelectedProducts.Count != 0)
                {
                    Console.WriteLine($"Musteri adi: {Customer.NameStatic} ");
                    foreach (var item in Product.SelectedProducts)
                    {
                        SaleProducts.Add(item);
                    }
                    Sales newSale = new(SaleProducts,Customer.NameStatic, DateTime.Now);
                    Sales.SalesList.Add(newSale);
                    Console.WriteLine("Satis Ugurla heyata kecirildi");
                }
                else
                {
                    Console.WriteLine("Sebetinizde mehsul yoxdur");
                }
            }
            else
            {
                Console.WriteLine("Musteri adiniz qeyd olunmayib Zehmet olmasa almaq istediyiniz mehsullar seciminde adinizi qeyd edin");
            }
        }


    }
}
