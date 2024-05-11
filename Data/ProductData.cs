using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace Data
{
    public class ProductData
    {
        string connectionString = "Data Source=LAB1504-10\\SQLEXPRESS;Initial Catalog=aysa;User ID=yerly;Password=123456;";

        public List<Product> Get()
        {
            List<Product> products = new List<Product>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_GetProducts", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            Product product = new Product();
                            product.ProductID = Convert.ToInt32(reader["Product_id"]);
                            product.Name = reader["Name"].ToString();
                            product.Price = Convert.ToDecimal(reader["Price"]);
                            product.Stock = Convert.ToInt32(reader["Stock"]);
                            products.Add(product);
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener productos: {ex.Message}");
                throw;
            }

            return products;
        }

        public void RegisterProduct(Product product)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_InsertProducto", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@name", product.Name);
                        cmd.Parameters.AddWithValue("@Price", product.Price);
                        cmd.Parameters.AddWithValue("@Stock", product.Stock);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar el producto: {ex.Message}");
                throw;
            }
        }

        public void eliminar(int ID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_DeletProduct", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", ID);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el producto: {ex.Message}");
                throw;
            }
        }

        public void Insert()
        {
            // Implementar lógica para insertar un nuevo producto
        }

        public void Update()
        {
            // Implementar lógica para actualizar un producto existente
        }

        public void Delete()
        {
            // Implementar lógica para eliminar un producto existente
        }
    }
}
