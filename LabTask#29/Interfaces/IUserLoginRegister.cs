using LabTask_29.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabTask_29.Interfaces
{
    internal interface IUserLoginRegister
    {
        public bool Login();    
        public void Register();

        public  bool PasswordChecker(string password);
        public Role RoleChecker(string userRole);
    }
}
