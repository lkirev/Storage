using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sklad
{
    public class Part
    {
        public int Id { get; private set; }
        public String Part_name { get; private set; }
        public uint Quantity { get; set; }
        public String Part_desc { get; private set; }
        public String Part_loc { get;  set; }
        //public static MySqlConnection DbConn { get; private set; }


        private Part(int id, String part_name, uint quantity, String part_desc, String part_loc)
        {
            if (id > 0) { this.Id = id; }
            if (part_name != null) { this.Part_name = part_name; }
            if (quantity > 0) { this.Quantity = quantity; }
            this.Part_desc = part_desc;
            this.Part_loc = part_loc;
        }

        /*public static void InitializeDB()
        {
            try
            {
                DbConn = new MySql.Data.MySqlClient.MySqlConnection("Persist Security Info=False;server=localhost;database=sklad1m;uid=root;password=admin");
            } catch (MySql.Data.MySqlClient.MySqlException e)
            {
                MessageBox.Show("Error connection to DB" + e.Message);
            }
        }*/

        public static List<Part> GetParts()
        {
            List<Part> parts = new List<Part>();
            String query = "SELECT * FROM parts";

            MySqlCommand cmd = new MySqlCommand(query, Database.DbConn);

            Database.DbConn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = (int)reader["id"];
                String part_name = reader["part_name"].ToString();
                uint quantity = (uint)reader["quantity"];
                String part_desc = reader["part_desc"].ToString();
                String part_loc = reader["part_loc"].ToString();

                parts.Add(new Part(id, part_name, quantity, part_desc, part_loc));
            }

            reader.Close();
            Database.DbConn.Close();
            return parts;
        }


        public static String AddParts(String id, String name, String quant, String desc, String loc)
        {
            int Id = int.Parse(id);
            String Name = name;
            uint quantity = uint.Parse(quant);
            String description = desc;
            int location = int.Parse(loc);

            return string.Format("INSERT INTO parts VALUES('{0}', '{1}', '{2}', '{3}', '{4}')", Id, Name, quantity, description, location);
        }

        public static String AddPartIDT2(String id, String name, String quant, String desc, String loc, String sub_loc)
        {
            int Id = int.Parse(id);
            String Name = name;
            uint Quantity = uint.Parse(quant);
            String Description = desc;
            int LocationId = Location.LocationIDT2(loc, sub_loc);

            return string.Format("INSERT INTO parts Values('{0}', '{1}', '{2}', '{3}', '{4}')", Id, Name, Quantity, Description, LocationId);
        }

        public static String AddPartID(String id, String name, String quant, String desc, String loc)
        {
            int Id = int.Parse(id);
            String Name = name;
            uint Quantity = uint.Parse(quant);
            String Description = desc;
            int LocationId = Location.LocationID(loc);

            return string.Format("INSERT INTO parts Values('{0}', '{1}', '{2}', '{3}', '{4}')", Id, Name, Quantity, Description, LocationId);
        }


        public static String RemovePart(int id, uint quantity)
        {
            Console.WriteLine("vlizam tuka");
            Console.WriteLine("ID REMOVED IS: " + id + " " + id.GetType());
            Console.WriteLine("QUANTITY REMOVED IS: " + quantity + " " + quantity.GetType());

            return string.Format("UPDATE parts SET quantity = '{0}' WHERE id = '{1}'", quantity, id);
        }

        public static String AddPartQuantity(int id, uint quantity)
        {
            return string.Format("UPDATE parts SET quantity = '{0}' WHERE id = '{1}'", quantity, id);
        }


        public static String DeletePart(int id)
        {
            return string.Format("DELETE FROM parts WHERE id = '{0}'", id);
        }

        public static List<Part> PartSearchById(int idIn)
        {
            String query = string.Format("SELECT * FROM parts WHERE id='{0}'", idIn);
            List<Part> parts = new List<Part>();

            MySqlCommand cmd = new MySqlCommand(query, Database.DbConn);

            Database.DbConn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = (int)reader["id"];
                String part_name = reader["part_name"].ToString();
                uint quantity = (uint)reader["quantity"];
                String part_desc = reader["part_desc"].ToString();
                String part_loc = reader["part_loc"].ToString();

                parts.Add(new Part(id, part_name, quantity, part_desc, part_loc));
            }

            reader.Close();
            Database.DbConn.Close();
            return parts;
        }

        public static List<Part> PartSearchByName(String nameIn)
        {
            String query = string.Format("SELECT * FROM parts WHERE part_name='{0}'", nameIn);
            List<Part> parts = new List<Part>();

            MySqlCommand cmd = new MySqlCommand(query, Database.DbConn);

            Database.DbConn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = (int)reader["id"];
                String part_name = reader["part_name"].ToString();
                uint quantity = (uint)reader["quantity"];
                String part_desc = reader["part_desc"].ToString();
                String part_loc = reader["part_loc"].ToString();
                //String part_loc = Location.LocationName(int.Parse(reader["part_loc"].ToString()));

                parts.Add(new Part(id, part_name, quantity, part_desc, part_loc));
            }

            reader.Close();
            Database.DbConn.Close();
            return parts;
        }

        public static List<Part> PartSearchByDesc(String DescIn)
        {
            String query = string.Format("SELECT * FROM parts WHERE part_desc='{0}'", DescIn);
            List<Part> parts = new List<Part>();

            MySqlCommand cmd = new MySqlCommand(query, Database.DbConn);

            Database.DbConn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = (int)reader["id"];
                String part_name = reader["part_name"].ToString();
                uint quantity = (uint)reader["quantity"];
                String part_desc = reader["part_desc"].ToString();
                String part_loc = reader["part_loc"].ToString();

                parts.Add(new Part(id, part_name, quantity, part_desc, part_loc));
            }

            reader.Close();
            Database.DbConn.Close();
            return parts;
        }

        public static List<Part> PartSearchByLoc(int locId)
        {
            String query = string.Format("SELECT * FROM parts WHERE part_loc='{0}'", locId);
            List<Part> parts = new List<Part>();

            MySqlCommand cmd = new MySqlCommand(query, Database.DbConn);

            Database.DbConn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = (int)reader["id"];
                String part_name = reader["part_name"].ToString();
                uint quantity = (uint)reader["quantity"];
                String part_desc = reader["part_desc"].ToString();
                String part_loc = reader["part_loc"].ToString();

                parts.Add(new Part(id, part_name, quantity, part_desc, part_loc));
            }

            reader.Close();
            Database.DbConn.Close();
            return parts;
        }



        /*public static void AddParts()
        {
            List<Part> Parts = new List<Part>();

            Add AddForm = new Add();

            int Id = Int32.Parse(TxtId.Text);
            String Name = TxtName.Text;
            uint Quantity = (uint)Int32.Parse(TxtQuantity.Text);
            String Part_desc = TxtDesc.Text;
            String Part_loc = TxtLocation.Text;

            String query = "INSERT INTO parts VALUES(" + Id + ", " + ", " + Name + ", " + Quantity + ", " + Part_desc + ", " + Part_loc + ")";

            MySqlCommand cmd = new MySqlCommand(query, DbConn);

            AddForm.ShowDialog();
        
        }
        public static void AddPartsDB()
        {

            Console.WriteLine("opade");

            //String query = Add.AddParts();

            Console.WriteLine("query");

            /*
            MySqlCommand cmd = new MySqlCommand(query, DbConn);

            DbConn.Open();

            cmd.ExecuteNonQuery();

            DbConn.Close(); 
        }*/

    }
}
