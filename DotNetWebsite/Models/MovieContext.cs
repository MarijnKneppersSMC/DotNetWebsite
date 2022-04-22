using DotNetWebsite.Extensions;
using MySql.Data.MySqlClient;

namespace DotNetWebsite.Models
{
    public class MovieContext
    {
        public string ConnectionString { get; set; }

        public MySqlConnection Connection { get; }

        private static MovieContext? _instance = null;
        public static MovieContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new NullReferenceException("An attempt at getting the MovieContext was made before it was initialised");
                }
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        public MovieContext(string connectionString)
        {
            ConnectionString = connectionString;

            Connection = new MySqlConnection(ConnectionString);

            OpenConnection();

            Instance = this;
        }

        public void OpenConnection()
        {
            //NOTE: if connection is timing out, verify you are using the correct connection string. Can be found at Program.cs on line 14
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
    }
}
