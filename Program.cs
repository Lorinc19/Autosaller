using AutoSale.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoSale
{
    public class Program
    {
        public static Connect conn = new Connect();
        public static List<Car> cars = new List<Car>();

        public static void feladat1()
        {
            
            string sql = "SELECT * FROM cars";
            conn.Connection.Open();
            MySqlCommand cmd = new MySqlCommand(sql,conn.Connection);
            MySqlDataReader dr = cmd.ExecuteReader();
            
            dr.Read();

            do
            {
                Car car = new Car();
                car.Id = dr.GetInt32(0);
                car.Brand = dr.GetString(1);
                car.Type = dr.GetString(2);
                car.License = dr.GetString(3);
                car.Date = dr.GetInt32(4);
                cars.Add(car);
            }
            while (dr.Read());

            



            

            conn.Connection.Close();
        }
        static void feladat2()
        {
            string marka, tipus, azon;
            int ev;
            Console.WriteLine("Adjon meg egy auto márkát");
            marka= Console.ReadLine();


            Console.WriteLine("adja meg a típusát");
            tipus= Console.ReadLine();


            Console.WriteLine("ADJA MEG A alvázszámát");
            azon= Console.ReadLine();

            Console.WriteLine("Adja meg az évjáratot");
            ev=Convert.ToInt32(Console.ReadLine());

            string sql = $"INSERT INTO `cars`(`Brand`, `Type`, `License`, `Date`) VALUES ('{marka}','{tipus}','{azon}','{ev}')";
            conn.Connection.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
            cmd.ExecuteNonQuery();
            

            conn.Connection.Close();
        }
        static void feladt3()
        {
            int id, ev;

            Console.WriteLine("Adja meg a sorszámot");
            id= Convert.ToInt32(Console.ReadLine()) ;

            Console.WriteLine("adja meg milyen évre szeretné módosítani");
            ev = Convert.ToInt32(Console.ReadLine());

            string sql =$"UPDATE `cars` SET `Date`='{ev}' WHERE `ID`={id}";
            conn.Connection.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
            cmd.ExecuteNonQuery();


            conn.Connection.Close();

        }

        static void feladat4()
        {
            int id;

            Console.WriteLine("Adja meg a sorszámot");
            id = Convert.ToInt32(Console.ReadLine());



            string sql = $"DELETE FROM `cars` WHERE ID={id}";
            conn.Connection.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
            cmd.ExecuteNonQuery();


            conn.Connection.Close();
        }
        static void Main(string[] args)
        {
            
            feladat1();
            foreach (var item in cars)
            {
                Console.WriteLine($"Márka: {item.Brand}, Azonosító: {item.License}");
            }
            feladat2();
            
            feladt3();
            feladat4();
            

            

            
        }
    }
}
