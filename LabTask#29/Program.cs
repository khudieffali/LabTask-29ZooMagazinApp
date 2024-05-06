using LabTask_29.Models;
using LabTask_29.Enums;
using System.Collections.Concurrent;

bool end = true;


while (end)
{
    Console.WriteLine("-------------------------------------");
    Console.WriteLine("Etmek isdediyiniz emeliyyati secin: ");
    Console.WriteLine("-------------------------------------");
    Console.WriteLine("Istifadeci  Qeydiyyati (1): ");
    Console.WriteLine("Istifadeci girisi (2): ");
    Console.WriteLine("Mehsul elave et (3): ");
    Console.WriteLine("Secilmis mehsulu yenile (4): ");
    Console.WriteLine("Secilmis mehsulu sil (5): ");
    Console.WriteLine("Mehsul siyahisina bax (6): ");
    Console.WriteLine("Almaq Istediyiniz mehsullari secin (7)");
    Console.WriteLine("Sebetinize baxin (8)");
    Console.WriteLine("Satisi tamamlayin (9)");
    Console.WriteLine("Satislara baxin (10)");
    Console.WriteLine("Mueyyen tarix araliginda satislarin axtarisi (11)");
    Console.WriteLine("Emeliyyati bitir (0): ");

checkProcess:
    Console.WriteLine("secimi daxil edin:");
    string inputProcess = Console.ReadLine();
    bool checkProcess = int.TryParse(inputProcess, out int process);
    if (!checkProcess) goto checkProcess;
    User user = new();
    ZooMagazin magazin = new();
    Product product = new();
    Sales sale = new();
    string[] idList = { };
    switch (process)
    {

        case 1:
            user.Register();
            break;
        case 2:
            if (user.Login())
            {
                Console.WriteLine("Daxil oldunuz");
            }
            else Console.WriteLine("Istifadeci adi ve ya parol sehvdir");
            break;
        case 3:
            int countAdd = 0;
            if (User.UserList == null && User.UserList.Count == 0) { Console.WriteLine("Istifadeci movcud deyil"); }
            if (User.LoginUser != null)
            {
                countAdd++;
                if (User.LoginUser.Role != Role.User)
                {
                    magazin.Add();
                    Console.WriteLine("Mehsul ugurla magazaya elave olundu");
                    break;
                }
                else
                {
                    Console.WriteLine("Istifadeci mehsul elave ede bilmez");
                    break;
                }
            }
            if (countAdd == 0) Console.WriteLine("Zehmet olmasa giris edin");
            break;
        case 4:
            int countUpdate = 0;
            if (User.LoginUser != null)
            {
                countUpdate++;
                if (User.LoginUser.Role != Role.User)
                {
                checkById:
                    Console.WriteLine("Mehsul Id sini daxil edin:");
                    string inputById = Console.ReadLine();
                    bool checkById = int.TryParse(inputById, out int id);
                    if (!checkById) goto checkById;
                    magazin.Update(id);
                    break;
                }
                else
                {
                    Console.WriteLine("Istifadeci mehsulda deyisiklik ede bilmez");
                    break;
                }
            }
            if (countUpdate == 0) Console.WriteLine("Zehmet olmasa giris edin");

            break;

        case 5:
            int countRemove = 0;

            if (User.LoginUser != null)
            {
                countRemove++;
                if (User.LoginUser.Role == Role.Admin)
                {
                checkById:
                    Console.WriteLine("Mehsul Id sini daxil edin:");
                    string inputById = Console.ReadLine();
                    bool checkById = int.TryParse(inputById, out int id);
                    if (!checkById) goto checkById;
                    magazin.Delete(id);
                    break;
                }
                else
                {
                    Console.WriteLine("Yalniz Admin mehsul sile biler");
                    break;
                }
            }
            if (countRemove == 0) Console.WriteLine("Zehmet olmasa giris edin");
            break;
        case 6:
            if (magazin.GetAll() != null)
            {
                foreach (var item in magazin.GetAll())
                {
                    Console.WriteLine($"Mehsulun ID si:{item.Id} Mehsul adi: {item.Name} Mehsul aciqlamasi: {item.Description}");
                }
            }
            else
            {
                Console.WriteLine("Mehsul movcud deyil zehmet olmasa elave edin");
            }

            break;
        case 7:
            if (magazin.GetAll() != null)
            {
                Product.SelectedProducts.Clear();
                foreach (var item in magazin.GetAll())
                {
                    Console.WriteLine($"Mehsulun ID si:{item.Id} Mehsul adi: {item.Name} Mehsul aciqlamasi: {item.Description}");
                    Console.WriteLine("----------------------------------------------");
                }
                Console.WriteLine("Hormetli musteri Zehmet olmasa adinizi qeyd edin:");
                string customerName = Console.ReadLine();
                Customer newCustomer = new(customerName);
                Console.WriteLine("Zehmet olmasa almaq istediyiniz mehsullari qeyd edin (Id-leri ni secin:(vergul ve ya bosluq qoyaraq)): ");
                string inputProductsBasket = Console.ReadLine();
                idList = inputProductsBasket.Split(' ', ',');
                product.GetByIdProductsAddBasket(idList);
            }
            else
            {
                Console.WriteLine("Mehsul movcud deyil zehmet olmasa elave edin");
            }
            break;
        case 8:
            if (Product.SelectedProducts.Count() != 0 && magazin.GetAll()!=null )
            {
                Console.WriteLine($"Musteri adi: {Customer.NameStatic} ");
                foreach (var item in Product.SelectedProducts)
                {
                    Console.WriteLine($"Mehsulun Id-si: {item.Id} Mehsulun adi: {item.Name} Mehsulun aciqlamasi:{item.Description}");
                }
            }
            else
            {
                Product.SelectedProducts.Clear();
                Console.WriteLine("Sebetinizde mehsul yoxdur");
            }
            break;
            case 9:
                magazin.DoSale();
            break;
            case 10:
            sale.GetAllSales();
            break;
            case 11:
            Console.WriteLine("Baslangic tarixi qeyd edin(bu formatda qeyd edin: AY.GUN.IL SAAT:SAAT ): ");
            checkingDateStart:
            string inputDateStart = Console.ReadLine();
            bool checkDateStart = DateTime.TryParse(inputDateStart, out DateTime DateStart);
            if (!checkDateStart) goto checkingDateEnd;

            Console.WriteLine("Son tarixi qeyd edin(bu formatda qeyd edin: AY.GUN.IL SAAT:SAAT ): ");
        checkingDateEnd:
            string inputDateEnd = Console.ReadLine();
            bool checkDateEnd = DateTime.TryParse(inputDateEnd, out DateTime DateEnd);
            if (!checkDateEnd) goto checkingDateEnd;
            sale.GetDateRangeSales(DateStart, DateEnd);
            break;
        case 0:
            Console.WriteLine("Emeliyyat basa catdi");
            end = false;
            break;
    }
}












