using LabTask_29.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabTask_29.Interfaces
{
    internal interface IZooMagazin
    {
        public void Add();
        public void Update(int id);
        public void Delete(int id);
        public List<Product> GetAll();
        public void DoSale();

    }
}
