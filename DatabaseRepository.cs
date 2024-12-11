using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;

namespace MySchoolProgram;

class DatabaseRepository
{
    public IEnumerable<Student> GetStudents()
    {
        string connectionstring = File.ReadAllText("connectionstring.txt");
        using IDbConnection connection = new SqlConnection(connectionstring);
        return connection.Query<Student>("SELECT * FROM Students");
    }

    public void InsertStudent(string name, string email, DateTime dateOfBirth)
    {
        // Spara i datbasen
        string connectionstring = File.ReadAllText("connectionstring.txt");
        using IDbConnection connection = new SqlConnection(connectionstring);
        string query = $"INSERT INTO Students (Name, Email, DateOfBirth) VALUES ('{name}', '{email}', '{dateOfBirth}')";
        // Console.WriteLine(query);
        // anslut till databasen med hjälp av connection string
        connection.Execute(query);
    }
    
    public void UpdateStudent(int id, string name, string email, DateTime dateOfBirth)
    {
        // Spara i datbasen
        string connectionstring = File.ReadAllText("connectionstring.txt");
        using IDbConnection connection = new SqlConnection(connectionstring);
        string query = $" UPDATE Students SET Name = '{name}', Email = '{email}', DateOfBirth = '{dateOfBirth}' WHERE Id = {id}"; 
        
        // Console.WriteLine(query);
        // anslut till databasen med hjälp av connection string
        connection.Execute(query);
    }
}