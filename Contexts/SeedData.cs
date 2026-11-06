using EFCore04.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore04.Contexts
{
    public static class SeedData
    {
        public static readonly Manager[] Managers = {
            new () { Id = 1, FullName = "Hassan Mahmoud", Email = "hassan.mahmoud@nbg.com", PhoneNumber = "01011112222", HireDate = new DateTime(2015, 3, 1) },
            new () { Id = 2, FullName = "Salma Adel",     Email = "salma.adel@nbg.com",     PhoneNumber = "01022223333", HireDate = new DateTime(2018, 9, 15) },
            new () { Id = 3, FullName = "Omar Khaled", Email = "omar.khaled@nbg.com", PhoneNumber = "01033334444", HireDate = new DateTime(2020, 1, 10) }
        };

        public static readonly Branch[] Branches = {
            new () { Code = "CAI-01", Name = "Cairo Main Branch",  Address = "10 Tahrir Square, Cairo",     PhoneNumber = "0227000001", ManagerId = 1 },
            new () { Code = "ALX-01", Name = "Alexandria Branch",  Address = "5 Corniche Road, Alexandria", PhoneNumber = "0345000002", ManagerId = 2 },
            new () { Code = "GIZ-01", Name = "Giza Branch",        Address = "22 Pyramids Street, Giza",    PhoneNumber = "0233000003", ManagerId = 3 }
        };
    }
}
