using MySql.Data.MySqlClient;

public class Database
{
    private static string connectionString =
        "server=localhost;uid=root;pwd=;database=inventaris_mini;";

    public static MySqlConnection GetConnection()
    {
        return new MySqlConnection(connectionString);
    }
}
