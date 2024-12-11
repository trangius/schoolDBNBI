using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;

namespace MySchoolProgram;

class Student
{
    public int Id{ get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
}

class Program
{
    static void Main()
    {
        // anslut till databasen med hjälp av connection string

        string connectionstring = File.ReadAllText("connectionstring.txt");
        Console.WriteLine(connectionstring);

        using IDbConnection connection = new SqlConnection(connectionstring);
        // hämta ut alla studenter från databasen till en lista
        IEnumerable<Student> students = connection.Query<Student>("SELECT * FROM Students");

        foreach(Student s in students)
        {
            Console.WriteLine($"Id: {s.Id} Name: {s.Name}, Email: {s.Email}, DateOfBirth: {s.DateOfBirth}");
        }

        // Lägg till en ny student
        // Läsa in namn, email och dateofbirth från användaren
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();
        Console.Write("Date of birth: ");
        string dateOfBirth = Console.ReadLine();

        // Spara i datbasen
        string query = $"INSERT INTO Students (Name, Email, DateOfBirth) VALUES ('{name}', '{email}', '{dateOfBirth}')";
        Console.WriteLine(query);
        connection.Execute(query);
    }
}