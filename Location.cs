using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sklad
{
    public class Location
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Sub_loc { get; set; }

        static readonly String[] subsArr = new String[]
        {
            "0",
            "1-1", "1-2", "1-3", "1-4", "1-5", "1-6",
            "2-1", "2-2", "2-3", "2-4", "2-5", "2-6",
            "3-1", "3-2", "3-3", "3-4", "3-5", "3-6",
            "4-1", "4-2", "4-3", "4-4", "4-5", "4-6",
            "5-1", "5-2", "5-3", "5-4", "5-5", "5-6",
            "6-1", "6-2", "6-3", "6-4", "6-5", "6-6",
            "7-1", "7-2", "7-3", "7-4", "7-5", "7-6",
            "8-1", "8-2", "8-3", "8-4", "8-5", "8-6",
            "9-1", "9-2", "9-3", "9-4", "9-5", "9-6",
            "10-1", "10-2", "10-3", "10-4", "10-5", "10-6",
            "11-1", "11-2", "11-3", "11-4", "11-5", "11-6",
            "12-1", "12-2", "12-3", "12-4", "12-5", "12-6",
            "13-1", "13-2", "13-3", "13-4", "13-5", "13-6",
        };

        public Location(int id, string name, string sub_loc)
        {
            this.Id = id;
            this.Name = name;
            this.Sub_loc = sub_loc;
        }
        public Location(int id, string name)
        {
            this.Id = id;
            this.Name = name;
            this.Sub_loc = null;
        }
        public Location(string name)
        {
            this.Name = name;
            this.Sub_loc = null;
        }
        public static List<Location> GetLocationNames()
        {
            int count = 0;
            List<Location> locationNames = new List<Location>();
            String query = "SELECT DISTINCT loc_name FROM locations";

            MySqlCommand cmd = new MySqlCommand(query, Database.DbConn);

            Database.DbConn.Open();
            Console.WriteLine("DB opened");
            MySqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("executing command");
            while (reader.Read())
            {
                //int id = (int)reader["id"];
                String loc_name = reader["loc_name"].ToString();
                Console.WriteLine("initializing");
                Location loc = new Location(loc_name);
                Console.WriteLine("created obj " + loc.Name);
                locationNames.Add(loc);
                Console.WriteLine("added item");
                count++;
                /*if (!locationNames.Contains(loc))
                {
                    Console.WriteLine("in if");
                    locationNames.Add(loc);
                    count++;
                }*/
                
                //if (!(locationNames.(loc_name)))
                //{
                //}
                /*foreach (Location l in locationNames)
                {
                    Console.WriteLine("foreach");
                    if (!(l.Name.Contains(loc_name)))
                    {
                        Console.WriteLine("locname");
                        locationNames.Add(new Location(id, loc_name));
                    }
                }*/
            }
            Console.WriteLine(count);
            reader.Close();
            Database.DbConn.Close();
            return locationNames;
        }
        public static List<String> GetSubLocation()
        {
            List<String> subLocNames = new List<String>();
            String query = "SELECT sub_loc FROM locations";

            MySqlCommand cmd = new MySqlCommand(query, Database.DbConn);

            Database.DbConn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                String sub_loc = reader["sub_loc"].ToString();

                if (!(subLocNames.Contains(sub_loc)))
                {
                    for(int i = 0; i<subsArr.Length; i++)
                    {
                        if (subsArr[i].Equals(sub_loc)){
                            subLocNames.Add(sub_loc);
                        }
                    }
                    
                }
            }

            reader.Close();
            Database.DbConn.Close();
            Console.WriteLine("TYPE IS: " + subLocNames.ElementAt(0).GetType());
            return subLocNames;
        }

        public static String AddLocation(String locIn, String subLocIn)
        {
            String loc = locIn;
            String subLoc = subLocIn;

            if (String.IsNullOrEmpty(subLoc))
            {
                subLoc = "0";
            }

            return String.Format("INSERT INTO locations (loc_name, sub_loc) VALUES('{0}', '{1}')", loc, subLoc);
        }


        public static int LocationIDT2(String loc, String sub_loc)
        {

            String query = string.Format("SELECT id FROM locations WHERE loc_name='{0}' AND sub_loc='{1}'", loc, sub_loc);
            int id = 0;

            MySqlCommand cmd = new MySqlCommand(query, Database.DbConn);
            Database.DbConn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    id = (int)reader["id"];
                }
            }
            catch
            {
                MessageBox.Show("Несъществуващо местоположение!", "Грешка");
            }
            Console.WriteLine("ID of location is: " + id);

            reader.Close();
            Database.DbConn.Close();
            return id;
        }
        public static int LocationID(String loc)
        {

            String query = string.Format("SELECT id FROM locations WHERE loc_name='{0}' AND sub_loc=0", loc);
            int id = 0;

            MySqlCommand cmd = new MySqlCommand(query, Database.DbConn);
            Database.DbConn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    id = (int)reader["id"];
                }
            }
            catch
            {
                MessageBox.Show("Несъществуващо местоположение!", "Грешка");
            }
            Console.WriteLine("ID of location is: " + id);

            reader.Close();
            Database.DbConn.Close();
            return id;
        }

        public static String LocationName(int id)
        {
            //Database.DbConn.Close();
            String query0 = string.Format("SELECT loc_name FROM locations WHERE id = '{0}'", id);
            String query1 = string.Format("SELECT sub_loc FROM locations WHERE id = '{0}'", id);
            MySqlCommand cmd0 = new MySqlCommand(query0, Database.DbConn);
            MySqlCommand cmd1 = new MySqlCommand(query1, Database.DbConn); 
            
            Database.DbConn.Open();
            MySqlDataReader reader = cmd0.ExecuteReader();

            String loc = null;
            while(reader.Read())
            {
                loc = reader["loc_name"].ToString(); 
            }

            Database.DbConn.Close();
            Database.DbConn.Open();

            reader = cmd1.ExecuteReader();
            String sub_loc = null;
            while (reader.Read())
            {
                sub_loc = reader["sub_loc"].ToString();
            }

            if (sub_loc.Equals("") || sub_loc.Equals("0"))
            {
                Database.DbConn.Close();
                return string.Format("Стая: '{0}'", loc);
            }
            else
            {
                Database.DbConn.Close();
                return string.Format("Стая: '{0}', Рафт: '{1}'", loc, sub_loc);
            }


        }

    }
}
