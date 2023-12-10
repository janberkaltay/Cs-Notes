// C# Notes with Entity Framework 

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_Dersleri.Model;

namespace Console_Dersleri
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DbVisitEntities db = new DbVisitEntities();

            //Listeleme
            void listPerson()
            {
                var values = db.Person.ToList();
                foreach (var value in values)
                {
                    Console.WriteLine(value.Id + "|" + value.Name + "|" + value.City);
                }
            }

            void listCountry()
            {
                var values = db.Country.ToList();
                for (int i = 0; i < values.Count; i++)
                {
                    Console.WriteLine(values[i].CountryId + "|" + values[i].CountryName + "|" + values[i].CountryCapital);
                    Console.WriteLine("------------------------------------");
                }
            }

            // Adding (Ekleme)

            Person person = new Person();
            person.Name = "Ahmet Şafak";
            person.City = "Mersin";
            db.Person.Add(person);
            db.SaveChanges();
            listPerson();

            Country country = new Country();
            country.CountryCapital = "Madrid";
            country.CountryName = "İspanya";
            db.Country.Add(country);
            db.SaveChanges();


            // Removing (Silme)

            Console.Write("Silinecek Ülkenin Kodunun Giriniz: ");
            int countryCode = Convert.ToInt32(Console.ReadLine());
            var value2 = db.Country.Find(countryCode);
            db.Country.Remove(value2);
            db.SaveChanges();
            listCountry();

            // Güncelleme
            var value3 = db.Country.Find(3);
            value3.CountryName = "Belçika";
            value3.CountryCapital = "Brüksel";
            db.SaveChanges();
            listCountry();

            Console.ReadLine();
        }
    }
}
