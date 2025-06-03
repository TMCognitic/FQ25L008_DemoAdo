// See https://aka.ms/new-console-template for more information

// 1. On va jouter à notre projet Microsoft.Data.SqlClient (via Nuget)
using Microsoft.Data.SqlClient;
// 2. Etablir la connexion

using (SqlConnection connection = new SqlConnection())
{
    connection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DemoAdo;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;";
    connection.Open();
    //Console.WriteLine(connection.State);

    using (SqlCommand command = connection.CreateCommand())
    { 
        command.CommandText = "SELECT COUNT(*) FROM Personne;";

        int count = (int)command.ExecuteScalar();
        Console.WriteLine($"Nombre de ligne(s) dans ma table Personne : {count}");
    }
}

using (SqlConnection connection = new SqlConnection())
{
    connection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DemoAdo;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;";
    connection.Open();
    //Console.WriteLine(connection.State);

    using (SqlCommand command = connection.CreateCommand())
    {
        command.CommandText = "SELECT GETDATE();";

        DateTime now = (DateTime)command.ExecuteScalar();
        Console.WriteLine($"Date : {now}");
    }
}

using (SqlConnection connection = new SqlConnection())
{
    connection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DemoAdo;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;";
    connection.Open();
    //Console.WriteLine(connection.State);

    using (SqlCommand command = connection.CreateCommand())
    {
        command.CommandText = "SELECT 'Personne' AS Type, Id, Nom, Prenom, Email FROM Personne;";

        using (SqlDataReader reader = command.ExecuteReader())
        {

            while (reader.Read())
            {
                Console.WriteLine(reader["Email"]);
            }
        }
    }
}