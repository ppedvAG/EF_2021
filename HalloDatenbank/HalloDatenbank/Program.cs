using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloDatenbank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hallo");

            try
            {
                string conString = "Server=(localdb)\\mssqllocaldb;Database=NORTHWND;Trusted_Connection=true;";

                SqlConnection con = new SqlConnection(conString);
                con.Open();
                Console.WriteLine("Datenbankverbindung wurde herstellt");

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT COUNT(*) FROM Employees";

                object result = cmd.ExecuteScalar();
                if (result is int count)
                    Console.WriteLine($"Es wurden {count} Employees in der Datenbank gefunden");


                SqlCommand selectCmd = con.CreateCommand();
                selectCmd.CommandText = "SELECT * FROM Employees";
                SqlDataReader reader = selectCmd.ExecuteReader();
                while (reader.Read())
                {
                    string vorname = reader.GetString(2);
                    string nachname = Convert.ToString(reader["LastName"]);
                    DateTime birthDate = reader.GetDateTime(reader.GetOrdinal("BirthDate"));
                    Console.WriteLine($"{vorname} {nachname} {birthDate:d}");
                }




                con.Close();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Im Programm ist ein Fehler: {ex.Message}");
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Die Datenbank sagt: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler: {ex.Message}");
            }

            Console.WriteLine("Ende");
            Console.ReadKey();
        }
    }
}
