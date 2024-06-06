using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace AdoManager
{
    internal class Ado
    {
        internal int InserData(string connectionString)
        {
            string Picture, Description, ProductName;
            int CategoryId ;
            float Price;
            Console.WriteLine("enter ProductName");
            ProductName = Console.ReadLine();
            Console.WriteLine("enter Description");
            Description = Console.ReadLine();
            Console.WriteLine("enter Picture");
            Picture = Console.ReadLine();
            Console.WriteLine("enter CategoryId");
            int.TryParse(Console.ReadLine(), out CategoryId);
            Console.WriteLine("enter Price");
            float.TryParse(Console.ReadLine(), out Price);
            Console.WriteLine();
            string query = "INSERT INTO Products(Product_Name, Description, Picture, Category_Id,Price)" +
                "VALUES(@ProductName,@Description, @Picture, @CategoryId,@Price)";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar,30).Value= ProductName;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 50).Value = Description;
                cmd.Parameters.Add("@Picture", SqlDbType.NVarChar, 50).Value = Picture;
                cmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value = CategoryId;
                cmd.Parameters.Add("@Price", SqlDbType.Float).Value = Price;

                con.Open();
                int rowAffected = cmd.ExecuteNonQuery();    
                con.Close();
                return rowAffected;

            }
            

        }
        internal int InserCat(string connectionString)
        {
            string Category_Name;
            Console.WriteLine("enter Category");
            Category_Name = Console.ReadLine();
            string query = "INSERT INTO Categories(Category_Name)" +
                "VALUES(@Category_Name)";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@Category_Name", SqlDbType.NVarChar,20).Value = Category_Name;
                con.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowAffected;

            }


        }
        internal void readData(string connectionString)
        {
            string queryString = "select * from Products";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, con);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int i = 0; i <6; i++)
                        {
                            Console.Write(reader[i]);
                        }
                       Console.WriteLine();
                        
                    }
                    reader.Close();
                }
                catch (Exception ex)
                { 
                Console.WriteLine(ex.Message);}
                }
            Console.ReadLine();
        }
       
    }
}
