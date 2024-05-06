using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabTask_29.Models
{
    internal class Customer
    {
        public string Name { get; set; }
        public static string NameStatic { get; set; }
        public Customer(string name)
        {
            Name=name;
            NameStatic = name;
        }
        
    }
}
