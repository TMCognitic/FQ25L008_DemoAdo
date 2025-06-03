// See https://aka.ms/new-console-template for more information

// 1. On va jouter à notre projet Microsoft.Data.SqlClient (via Nuget)
using DemoAdo.App;
using Microsoft.Data.SqlClient;
// 2. Etablir la connexion

//using (SqlConnection connection = new SqlConnection())
//{
//    connection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DemoAdo;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;";
//    connection.Open();
//    //Console.WriteLine(connection.State);

//    using (SqlCommand command = connection.CreateCommand())
//    { 
//        command.CommandText = "SELECT COUNT(*) FROM Personne;";

//        int count = (int)command.ExecuteScalar();
//        Console.WriteLine($"Nombre de ligne(s) dans ma table Personne : {count}");
//    }
//}

//using (SqlConnection connection = new SqlConnection())
//{
//    connection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DemoAdo;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;";
//    connection.Open();
//    //Console.WriteLine(connection.State);

//    using (SqlCommand command = connection.CreateCommand())
//    {
//        command.CommandText = "SELECT GETDATE();";

//        DateTime now = (DateTime)command.ExecuteScalar();
//        Console.WriteLine($"Date : {now}");
//    }
//}

//using (SqlConnection connection = new SqlConnection())
//{
//    connection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DemoAdo;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;";
//    connection.Open();
//    //Console.WriteLine(connection.State);

//    using (SqlCommand command = connection.CreateCommand())
//    {
//        command.CommandText = "SELECT 'Personne' AS Type, Id, Nom, Prenom, Email FROM Personne;";

//        List<Personne> personnes = new List<Personne>();
//        using (SqlDataReader reader = command.ExecuteReader())
//        {
//            while (reader.Read())
//            {
//                personnes.Add(new Personne((int)reader["Id"], (string)reader["Nom"], (string)reader["Prenom"], (string)reader["Email"]));
//            }
//        }

//        foreach (Personne personne in personnes)
//        {
//            Console.WriteLine($"{personne.Id} : {personne.Nom} {personne.Prenom} ({personne.Email})");
//        }
//    }
//}

string nom = "Willis";
string prenom = "Bruce";
string email = "bruce4.willis@imdb.com'); use master; drop database demoAdo; --";


using (SqlConnection connection = new SqlConnection())
{
    connection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DemoAdo;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;";
    connection.Open();
    //Console.WriteLine(connection.State);

    using (SqlCommand command = connection.CreateCommand())
    {
        command.CommandText = $"INSERT INTO Personne (Nom, Prenom, Email) VALUES (N'{nom}', N'{prenom}', N'{email}')";

        int rows = command.ExecuteNonQuery();
        Console.WriteLine($"Nombre de ligne(s) modifiée : {rows}");
    }
}