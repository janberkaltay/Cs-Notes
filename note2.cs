using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Dersleri
{
    internal class Program
    {

        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DU2K;Initial Catalog=DbVisit;Integrated Security=True;");

            void Listele()
            {
                conn.Open();
                SqlCommand command = new SqlCommand("Select * from Person", conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader[0] + " | " + reader[1] + " | " + reader[2]);
                    Console.WriteLine("----------------------------------");
                }
                conn.Close();
            }

            // Arama işlemi

            Console.WriteLine("*****************");
            Console.WriteLine();
            Console.Write("Aranacak Şehri giriniz: ");
            String city = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("*****************");
            conn.Open();
            SqlCommand command6 = new SqlCommand("Select * from Person where city=@p1", conn);
            command6.Parameters.AddWithValue("@p1", city);
            SqlDataReader reader2 = command6.ExecuteReader();
            while (reader2.Read())
            {
                Console.WriteLine(reader2[0] + " | " + reader2[1] + " | " + reader2[2]);
            }
            conn.Close();


            // İstatistik veriler

            // Toplam Kişi Sayısı

            conn.Open();
            SqlCommand command7 = new SqlCommand("Select count(*) from Person", conn);
            SqlDataReader reader3 = command7.ExecuteReader();
            while (reader3.Read())
            {
                Console.WriteLine("Toplam Kişi Sayısı: " + reader3[0]);
            }
            conn.Close();


            // Uçuşlardan Kazanılacak Toplam Para

            conn.Open();
            SqlCommand command8 = new SqlCommand("Select sum(Price) from Flight", conn);
            SqlDataReader reader8 = command8.ExecuteReader();
            while (reader8.Read())
            {
                Console.WriteLine("Toplam Uçuşlardan Kazanılan Para: " + reader8[0] + "TL");
            }
            conn.Close();


            // Ortalama Uçuş Başı Kar

            conn.Open();
            SqlCommand command9 = new SqlCommand("SELECT SUM(Price) FROM Flight", conn);
            SqlDataReader reader9 = command9.ExecuteReader();
            double totalRevenue = 0;

            while (reader9.Read())
            {
                totalRevenue = Convert.ToDouble(reader9[0]);
            }
            Console.WriteLine("Toplam Uçuşlardan Kazanılan Para: " + totalRevenue);

            reader9.Close();

            SqlCommand command10 = new SqlCommand("SELECT COUNT(*) FROM Flight", conn);
            SqlDataReader reader10 = command10.ExecuteReader();

            int totalFlightCount = 0;

            while (reader10.Read())
            {
                totalFlightCount = Convert.ToInt32(reader10[0]);
            }

            Console.WriteLine("Toplam Uçuş Sayısı: " + totalFlightCount);

            reader10.Close();

            if (totalFlightCount > 0)
            {
                double averageRevenuePerFlight = totalRevenue / totalFlightCount;
                Console.WriteLine("Ortalama Uçuş Başı Kar: " + averageRevenuePerFlight);
            }
            else
            {
                Console.WriteLine("Uçuş bulunmamaktadır, ortalama hesaplanamıyor.");
            }
            conn.Close();


            Console.ReadLine();

        }
    }
}

