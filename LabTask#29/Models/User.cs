using LabTask_29.Enums;
using LabTask_29.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabTask_29.Models
{
    internal class User : IUserLoginRegister
    {
        public int Id { get; set; }
        public static int Count { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public byte Age { get; set; }
        public Role Role { get; set; }
        public static List<User> UserList { get; set; } = new();
        public static  User LoginUser { get; set; }

        public User(string name, string surname, byte age, Role role, string username, string password)
        {
            Count++;
            Name = name;
            Surname = surname;
            Age = age;
            Role = role;
            Username = username;
            Password = password;
            Id = Count;
        }
        public User()
        {

        }
        //Add User
        public void Add(User user)
        {
            UserList.Add(user);
        }
        // User Login Method
        public bool Login()
        {
            head:
            Console.WriteLine("Istifadeci adi daxil edin: ");
            string userName = Console.ReadLine();
            if(String.IsNullOrWhiteSpace(userName)) { Console.WriteLine("Zehmet olmasa istifadeci adi qeyd edin"); goto head; }
            checkPassword:
            Console.WriteLine("Parol daxil edin (minimum 8 element, en az 1 boyuk ve en az 1 kicik herf olmalidir): ");
            string inputPassword = Console.ReadLine();
            if (!PasswordChecker(inputPassword)) goto checkPassword;
            foreach (var item in UserList)
            {
                if (item.Username== userName && item.Password == inputPassword)
                {
                    LoginUser = item;   
                    return true;
                }
            }
            return false;
           
        }

        // User Register Method
        public /*(string,string,byte,Role,string,string)*/ void Register()
        {
            Console.WriteLine("Ad daxil edin:");
            string name = Console.ReadLine();

            Console.WriteLine("Soyad daxil edin: ");
            string surName = Console.ReadLine();
        checkAge:
            Console.WriteLine("Yas daxil edin:");
            string inputAge = Console.ReadLine();
            bool checkAge = byte.TryParse(inputAge, out byte age);
            if (!checkAge) goto checkAge;

            Console.WriteLine("Rolunu daxil edin (Admin, Moderator, User): ");
            string role = Console.ReadLine();
            head:
            Console.WriteLine("Istifadeci adi daxil edin: ");
            string userName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userName)) { Console.WriteLine("Zehmet olmasa istifadeci adi qeyd edin"); goto head; }

        checkPassword:
            Console.WriteLine("Parol daxil edin (minimum 8 element, en az 1 boyuk ve en az 1 kicik herf olmalidir): ");
            string inputPassword = Console.ReadLine();
            if (!PasswordChecker(inputPassword)) goto checkPassword;
            foreach (var item in UserList)
            {
                if(!item.Username.Equals(userName, StringComparison.OrdinalIgnoreCase))
                {
                   
                   Username= userName;
                }
                else
                {
                    Console.WriteLine("Istifadeci artiq movcuddur");
                    return;
                }
            }
            User newUser = new(name, surName, age, RoleChecker(role), userName, inputPassword);
            Add(newUser);
            Console.WriteLine("Istifadeci ugurla elave edildi");
        }


        // Password Checker Method
        public bool PasswordChecker(string password)
        {
            if (String.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Parol hissesi bos qeyd edilib");
                return false;
            }
            else if (password.Length < 8)
            {
                Console.WriteLine("Parol 8 elementden az qeyd edilib");
                return false;
            }
            else if (!password.Any(char.IsUpper))
            {
                Console.WriteLine("En az 1 boyuk herf olmalidir");
                return false;
            }
            else if (!password.Any(char.IsLower))
            {
                Console.WriteLine("En az 1 kicik herf olmalidir");
                return false;
            }
            else
            {
                return true;
            }
        }


        // Check Role Method
        public Role RoleChecker(string userRole)
        {
            if (userRole.ToLower() == "admin")
            {
                return Role.Admin;
            }
            else if (userRole.ToLower() == "moderator")
            {
                return Role.Moderator;
            }
            else
            {
                return Role.User;
            }
        }



    
    }
}
