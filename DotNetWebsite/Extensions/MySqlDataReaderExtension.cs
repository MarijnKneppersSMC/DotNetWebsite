using MySql.Data.MySqlClient;

namespace DotNetWebsite.Extensions
{
    public static class MySqlDataReaderExtension
    {

        public static void ReadString(this MySqlDataReader reader, string column, Action<string> setter)
        {
            if(!string.IsNullOrEmpty(reader[column].ToString()))
            {
                setter(reader[column].ToString()!);
            }
        }

        public static void ReadInt(this MySqlDataReader reader, string column, Action<int> setter)
        {
            int value = Convert.ToInt32(reader[column]);

            // 0 is returned by ToInt32 when a value is null
            if(value != 0)
            {
                setter(value);
            }
        }

    }
}
