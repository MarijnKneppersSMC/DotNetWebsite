using DotNetWebsite.Extensions;
using MySql.Data.MySqlClient;

namespace DotNetWebsite.Models
{
    public class MovieContext
    {
        public string ConnectionString { get; set; }

        public MySqlConnection Connection { get; }

        public MovieContext(string connectionString)
        {
            ConnectionString = connectionString;

            Connection = new MySqlConnection(ConnectionString);

            OpenConnection();

            GetMovie(1);
        }

        public void OpenConnection()
        {
            Connection.Open();

            Console.WriteLine("Successfully opened connection with server");
            Console.WriteLine("Server Information:");
            Console.WriteLine("\tVersion: " + Connection.ServerVersion);
        }

        public void CloseConnection()
        {
            Connection.Close();

            Console.WriteLine("Connection succesfully closed");
        }

        public Movie GetMovie(int ID)
        {
            MySqlCommand cmd = new MySqlCommand("select * from Movies where ID = " + ID, Connection);

            using var reader = cmd.ExecuteReader();
            reader.Read();

            Movie movie = new Movie();

            //Some setter trickery as you can't pass a property as a reference
            reader.ReadInt("ID", s => movie.Id = s);
            reader.ReadString("TITLE", s => movie.Title = s);
            reader.ReadString("SYNOPSIS", s => movie.Synopsis = s);
            reader.ReadString("DIRECTOR", s => movie.Director = s);
            reader.ReadInt("YEAR", s => movie.Year = s);
            reader.ReadInt("LENGTH", s => movie.Length = s);

            return movie;
        }

        private void NullSafeSet(string? value, Action<string> setter)
        {
            if(!string.IsNullOrEmpty(value))
            {
                setter(value);
            }
        }

        private void NullSafeSet(int value, Action<int> setter)
        {
            if(value != 0)
            {
                setter(value);
            }
        }
    }
}
