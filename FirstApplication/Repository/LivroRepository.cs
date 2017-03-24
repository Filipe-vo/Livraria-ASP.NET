using FirstApplication.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace FirstApplication.Repository
{
    public class LivroRepository
    {
        public IEnumerable<Livro> GetAllLivros()
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\FirstApplication\FirstApplication\App_Data\FirstApplication.mdf;Integrated Security=True";

            using (var connection = new SqlConnection(connectionString))
            {

                var commandText = "SELECT * FROM Livro";
                var selectCommand = new SqlCommand(commandText, connection);

                Livro livro = null;
                var livros = new List<Livro>();

                try
                {
                    connection.Open();

                    using (var reader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {

                        while (reader.Read())
                        {
                            livro = new Livro();
                            livro.Id = (int)reader["Id"];
                            livro.Ano = (int)reader["Ano"];
                            livro.Titulo = reader["Titulo"].ToString();
                            livro.Autor = reader["Autor"].ToString();
                            livro.Editora = reader["Editora"].ToString();

                            livros.Add(livro);
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }

                return livros;
            }

        }

        internal void CreateLivro(Livro livro)
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\FirstApplication\FirstApplication\App_Data\FirstApplication.mdf;Integrated Security=True";

            using (var connection = new SqlConnection(connectionString))
            {
                var commandText = "INSERT INTO Livro (Ano, Titulo, Autor, Editora) VALUES (@Ano, @Titulo, @Autor, @Editora)";
                var insertCommand = new SqlCommand(commandText, connection);
                insertCommand.Parameters.AddWithValue("@Ano", livro.Ano);
                insertCommand.Parameters.AddWithValue("@Titulo", livro.Titulo);
                insertCommand.Parameters.AddWithValue("@Autor", livro.Autor);
                insertCommand.Parameters.AddWithValue("@Editora", livro.Editora);

                try
                {
                    connection.Open();
                    insertCommand.ExecuteNonQuery();

                }
                finally
                {
                    connection.Close();
                }
            }




        }

        public Livro GetLivro(int id)
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\FirstApplication\FirstApplication\App_Data\FirstApplication.mdf;Integrated Security=True";

            using (var connection = new SqlConnection(connectionString))
            {

                var commandText = $"SELECT * FROM Livro WHERE ID = {id}";
                var selectCommand = new SqlCommand(commandText, connection);

                Livro livro = null;


                try
                {
                    connection.Open();

                    using (var reader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {

                        while (reader.Read())
                        {
                            livro = new Livro();
                            livro.Id = (int)reader["Id"];
                            livro.Ano = (int)reader["Ano"];
                            livro.Titulo = reader["Titulo"].ToString();
                            livro.Autor = reader["Autor"].ToString();
                            livro.Editora = reader["Editora"].ToString();


                        }
                    }
                }
                finally
                {
                    connection.Close();
                }

                return livro;
            }

        }

        public bool DeleteLivro(int id)
        {
            int rows = 0;
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\FirstApplication\FirstApplication\App_Data\FirstApplication.mdf;Integrated Security=True";

            using (var connection = new SqlConnection(connectionString))
            {
                var commandText = $"DELETE FROM Livro WHERE Id = {id}";
                var selectCommand = new SqlCommand(commandText, connection);

                try
                {
                    connection.Open();
                    rows = selectCommand.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }
                return rows > 0;
            }
        }

        internal void UpdadeLivro(Livro livro)
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\FirstApplication\FirstApplication\App_Data\FirstApplication.mdf;Integrated Security=True";

            using (var connection = new SqlConnection(connectionString))
            {
                var commandText = $"UPDATE Livro SET Titulo = '{ livro.Titulo }', Autor = '{ livro.Autor }', Editora = '{ livro.Editora }', Ano = { livro.Ano } WHERE Id = { livro.Id }";
                var insertCommand = new SqlCommand(commandText, connection);

                try
                {
                    connection.Open();
                    insertCommand.ExecuteNonQuery();
                }
                finally
                {

                    connection.Close();
                }
            }
        }
    }
}