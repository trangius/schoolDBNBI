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
    static DatabaseRepository repo = new DatabaseRepository();

    static void Main()
    {
        while(true)
        {
            Console.WriteLine("1. Print students");
            Console.WriteLine("2. Add student");
            Console.WriteLine("3. Exit");
            Console.Write("Select: ");
            string choice = Console.ReadLine();
            switch(choice)
            {
                case "1":
                    PrintStudents();
                    break;
                case "2":
                    InsertStudent();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }

    static void PrintStudents()
    {
        IEnumerable<Student> students = repo.GetStudents();
        foreach(Student s in students)
        {
            Console.WriteLine($"Id: {s.Id} Name: {s.Name}, Email: {s.Email}, DateOfBirth: {s.DateOfBirth}");
        }

    }

    static void InsertStudent()
    {
        // Läsa in namn, email och dateofbirth från användaren
        Console.Write("Name: ");
        string name = CHelp.ReadString();
        Console.Write("Email: ");
        string email = CHelp.ReadString(); 
        Console.Write("Date of birth: ");
        DateTime dateOfBirth = CHelp.ReadDate();
        repo.InsertStudent(name, email, dateOfBirth);
    }
}