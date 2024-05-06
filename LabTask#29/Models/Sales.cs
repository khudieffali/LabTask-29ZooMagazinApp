using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabTask_29.Models
{
    internal class Sales
    {
        public int _id { get; set; }
        private static int IdCount { get; set; }
        public List<Product> Products { get; set; } = new();
        public List<Customer> Customers { get; set; } = new();
        public DateTime DateOfSale { get; set; }
        public static List<Sales> SalesList { get; set; } = new();

        public Sales(List<Product> products, string name, DateTime date)
        {
            IdCount++;
            _id = IdCount;
            Products = products;
            DateOfSale = date;
            Customers.Add(new Customer(name));
        }
        public Sales()
        {

        }

        public void GetAllSales()
        {
            if (SalesList != null)
            {
                foreach (var item in SalesList)
                {
                    foreach (var item2 in item.Customers)
                    {
                        Console.WriteLine("-----------------");
                        Console.WriteLine($"Musterinin adi: {item2.Name}");
                    }
                    Console.WriteLine("-----------------");
                    foreach (var item1 in item.Products)
                    {

                        Console.WriteLine($"satilan mehsullar: ");
                        Console.WriteLine($"mehsul adi:{item1.Name} {item1.Description}");
                    }
                    Console.WriteLine($"Satis tarixi : {item.DateOfSale}");
                }
            }
            else
            {
                Console.WriteLine("Satisiniz yoxdur");
            }
        }

        public void GetDateRangeSales(DateTime startDate, DateTime endDate)
        {
            int count = 0;
            if (SalesList != null)
            {
                foreach (var item in SalesList)
                {
                    if(startDate<=item.DateOfSale && endDate >= item.DateOfSale)
                    {
                        count++;
                        foreach (var item2 in item.Customers)
                        {
                            Console.WriteLine("-----------------");
                            Console.WriteLine($"Musterinin adi: {item2.Name}");
                        }
                        Console.WriteLine("-----------------");
                        foreach (var item1 in item.Products)
                        {

                            Console.WriteLine($"satilan mehsullar: ");
                            Console.WriteLine($"mehsul adi:{item1.Name} {item1.Description}");
                        }
                        Console.WriteLine($"Satis tarixi : {item.DateOfSale}");
                    }
                }
                if (count == 0)
                {
                    Console.WriteLine("Bu tarix araliginda satis olmayib");
                }
            }
            else
            {
                Console.WriteLine("Satisiniz yoxdur");
            }

        }
    }
}
