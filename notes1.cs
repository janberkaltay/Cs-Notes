namespace Console_Dersleri
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-D2U2K;Initial Catalog=DbVisit;Integrated Security=True;");

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

            // Ekleme İşlemi
            conn.Open();
            SqlCommand command2 = new SqlCommand("insert into Person (Name, City) values (@p1, @p2)", conn);
            command2.Parameters.AddWithValue("@p1", "Esile Altay");
            command2.Parameters.AddWithValue("@p2", "Adana");
            command2.ExecuteNonQuery();
            conn.Close();
            Listele();


            // Silme İşlemi

            conn.Open();
            SqlCommand command3 = new SqlCommand("Delete From Person where Id=@p1",conn);
            command3.Parameters.AddWithValue("@p1", 11);
            command3.ExecuteNonQuery();
            conn.Close();
            Listele();

            //Güncelleme İşlemi

            conn.Open();
            SqlCommand command4 = new SqlCommand("Update Person Set Name= @p1, City= @p2 where Id=@p3", conn);
            command4.Parameters.AddWithValue("@p1", "Ayşe Zencir");
            command4.Parameters.AddWithValue("@p2", "Adana");
            command4.Parameters.AddWithValue("@p3", 5);
            command4.ExecuteNonQuery();
            conn.Close();
            Listele();

            //Dışarıdan Girilen Parametre ile Ekleme

            String name, city;
            Console.WriteLine("************************");
            Console.Write("Kişi Adı: ");
            name = Console.ReadLine();
            Console.Write("Şehir Adı: ");
            city = Console.ReadLine();
            Console.WriteLine("************************");
            Console.WriteLine("Kişi Listeye Başarılı Bir Şekilde Eklendi: " + name + " " + city);

            conn.Open();
            SqlCommand command5 = new SqlCommand("insert into Person (name,city) values (@p1,@p2)", conn);
            command5.Parameters.AddWithValue("@p1", name);
            command5.Parameters.AddWithValue("@p2", city);
            command5.ExecuteNonQuery();
            conn.Close();  
            Listele();

            Console.ReadLine();
        }
    }
}
