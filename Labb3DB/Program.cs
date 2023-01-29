using Labb3DB.Data;
using Labb3DB.Models;

namespace Labb3DB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SchoolDBContext context = new SchoolDBContext();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Vad vill du göra?\n1. Sortera elever genom namn\n2. Sortera elever genom klass" +
                    "\n3. Skapa ny personal");
                switch (Console.ReadLine())
                {
                    case "1":
                        SortStudentsByName(context);
                        break;
                    case "2":
                        SortStudentByClass(context);
                        break;
                    case "3":
                        CreateNewFaculty(context);
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val");
                        break;
                }
            }
        }
        static void SortStudentsByName(SchoolDBContext context)
        {
            var studTable = context.Students;
            Console.Clear();
            Console.WriteLine("Vill du se sorterade med för eller efternamn?");
            Console.WriteLine($"1. Förnamn\n2. Efternamn");
            string choice1 = Console.ReadLine();
            Console.WriteLine("Vill du se i stigande eller fallande ordning?");
            Console.WriteLine($"1. Stigande\n2. Fallande");
            string choice2 = Console.ReadLine();
            if (choice1 == "1")
            {
                if (choice2 == "1")
                {
                    foreach (var student in studTable.OrderBy(s => s.Fnamn))
                    {
                        Console.WriteLine($"{student.Fnamn} {student.Lnamn}");
                    }
                }
                else
                {
                    foreach (var student in studTable.OrderBy(s => s.Fnamn).Reverse())
                    {
                        Console.WriteLine($"{student.Fnamn} {student.Lnamn}");
                    }
                }
            }
            else
            {
                if (choice2 == "1")
                {
                    foreach (var student in studTable.OrderBy(s => s.Lnamn))
                    {
                        Console.WriteLine($"{student.Fnamn} {student.Lnamn}");
                    }
                }
                else
                {
                    foreach (var student in studTable.OrderBy(s => s.Lnamn).Reverse())
                    {
                        Console.WriteLine($"{student.Fnamn} {student.Lnamn}");
                    }
                }
            }
            Console.ReadKey();
        }
        static void SortStudentByClass(SchoolDBContext context)
        {
            Console.Clear();

            foreach (var c in context.Classes)
            {
                Console.WriteLine(c.KlassId + " - " + c.KlassNamn);
            }

            Console.WriteLine("Vilken klass vill du skriva ut eleverna av?");

            if (Int32.TryParse(Console.ReadLine(), out int classToPrint))
            {
                Console.Clear();

                var classStudents = context.ClassStudents.Where(c => c.KlassId == classToPrint).Select(s => s.Student);
                foreach (var item in classStudents)
                {
                    Console.WriteLine(item.Fnamn + " " + item.Lnamn);
                }
            }

            Console.ReadKey();
        }
        static void CreateNewFaculty(SchoolDBContext context)
        {
            bool noError = false;
            bool jobNoError = false;
            Console.WriteLine("Vilket personnummer har den nya personalen?");
            noError = Int32.TryParse(Console.ReadLine(), out int personNummer);
            Console.WriteLine("Vad har personalen för förnamn?");
            string fNamn = Console.ReadLine();
            Console.WriteLine("Vad har personalen för efternamn?");
            string lNamn = Console.ReadLine();
            Console.WriteLine("Vilken adress har personalen?");
            string adress = Console.ReadLine();
            Console.WriteLine("Vilket telefonnummer har personalen?");
            string telefonNummer = Console.ReadLine();
            Console.WriteLine("Vilken email har personalen?");
            string eMail = Console.ReadLine();
            Console.WriteLine("Vilket JobID har personalen?");
            foreach (var item in context.Jobs)
            {
                Console.WriteLine(item.JobId + " - " + item.JobNamn);
            }
            noError = Int32.TryParse(Console.ReadLine(), out int jobID);
            foreach (var item in context.Jobs)
            {
                if (item.JobId == jobID)
                {
                    jobNoError = true;
                    break;
                }
                else
                {
                    jobNoError = false;
                }
            }

            if (noError && jobNoError)
            {
                Faculty newFacultyMember = new Faculty()
                {
                    Personnummer = personNummer,
                    Fnamn = fNamn,
                    Lnamn = lNamn,
                    Adress = adress,
                    Telefonnummer = telefonNummer,
                    Email = eMail,
                    JobId = jobID
                };
                context.Faculties.Add(newFacultyMember);
                context.SaveChanges();
            }
            else
            {
                if (!jobNoError)
                {
                    Console.WriteLine("Ogiltig JobID");
                }
                else
                {
                    Console.WriteLine("Ogiltig input");
                }
                Console.ReadLine();

            }
        }
    }
}