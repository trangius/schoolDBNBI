using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;

namespace MySchoolProgram;

class DatabaseRepository
{
    string connectionstring = File.ReadAllText("connectionstring.txt");
    
    public IDbConnection Connect()
    {
        return new SqlConnection(connectionstring);
    }

    public IEnumerable<Student> GetStudents()
    {
        // skapa en enkel textsträng som innehåller connection string
        using IDbConnection connection = Connect();
        return connection.Query<Student>("SELECT * FROM Students");
    }

    public void InsertStudent(string name, string email, DateTime dateOfBirth)
    {
        // Spara i datbasen
        string query = $"INSERT INTO Students (Name, Email, DateOfBirth) VALUES ('{name}', '{email}', '{dateOfBirth}')";
        // Console.WriteLine(query);
        // anslut till databasen med hjälp av connection string
        using IDbConnection connection = Connect();
        connection.Execute(query);
    }
    
    public void UpdateStudent(int id, string name, string email, DateTime dateOfBirth)
    {
        // Spara i datbasen
        string query = $" UPDATE Students SET Name = '{name}', Email = '{email}', DateOfBirth = '{dateOfBirth}' WHERE Id = {id}"; 
        // Console.WriteLine(query);
        // anslut till databasen med hjälp av connection string
        using IDbConnection connection = Connect();
        connection.Execute(query);
    }
}