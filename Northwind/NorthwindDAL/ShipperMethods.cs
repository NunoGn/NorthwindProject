using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace NorthwindDAL
{
    public static class ShipperMethods
    {
        private static SqlConnection connection = new SqlConnection(@"data source = .\SQLEXPRESS; initial catalog = Northwind;" +
                                                                        "integrated security = true;");


        public static DataTable ShipperSelect()
        {
            SqlCommand command = new SqlCommand("SELECT ShipperID, CompanyName,Phone FROM Shippers " +
                                                "ORDER BY CompanyName ASC", connection);
            SqlDataReader reader;
            connection.Open();
            reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            connection.Close();
            return table;
        }

        public static void ShipperInsert(Shipper s)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Shippers(CompanyName,Phone) VALUES(@cn, @p)", connection);
            command.Parameters.AddWithValue("@cn", s.Name);
            command.Parameters.AddWithValue("@p", s.Phone);
            connection.Open();
            try
            {
                command.ExecuteNonQuery();
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public static void ShipperUpdate(Shipper s)
        {
            SqlCommand command = new SqlCommand("UPDATE Shippers SET CompanyName= @cn, Phone=@p WHERE ShipperID=@id", connection);
            command.Parameters.AddWithValue("@cn", s.Name);
            command.Parameters.AddWithValue("@p", s.Phone);
            command.Parameters.AddWithValue("id", s.ID);
            connection.Open();
            try
            {
                command.ExecuteNonQuery();
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public static void ShipperDelete(Shipper s)
        {
            SqlCommand command = new SqlCommand("DELETE Shippers WHERE ShipperID=@id", connection);
            command.Parameters.AddWithValue("@id", s.ID);
            connection.Open();
            try
            {
                command.ExecuteNonQuery();
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }





    }
}

