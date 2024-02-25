using System.Text;
using StudentObject;
using createstudent;

namespace student_database
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<student> studentList = new List<student>(); // declare an empty list of students
            Boolean end = false; // this will cause the program to end
            while (end != true)
            {
                Console.WriteLine("Welcome to Student Database");
                Console.WriteLine("Choose your Options: Add, Edit, Delete, Read List, Download List, Load List, End");
                string userInput = Console.ReadLine();
                if (userInput != null)
                {
                    if (userInput == "Add")
                    {
                        
                        studentList.Add(Functions.AddStudent()); // we're going to add student to student list 
                    }
                    else if (userInput == "Edit") // edits student details
                    {
                        Console.WriteLine("Please Provide Student's ID: ");
                        string read = Console.ReadLine();
                        while (int.TryParse(read, out int result) != true)
                        {
                            Console.WriteLine("Error, Try again");
                            Console.WriteLine("Enter Student ID: ");
                            read = Console.ReadLine();
                        }
                        studentList = Functions.EditStudent(studentList, Convert.ToInt32(read));
                    }
                    else if (userInput == "Delete") //deletes a student from a list
                    {
                        Console.WriteLine("Please Provide Student's ID: ");
                        string read = Console.ReadLine();
                        while (int.TryParse(read, out int result) != true) // error prevention
                        {
                            Console.WriteLine("Error, Try again");
                            Console.WriteLine("Enter Student ID: ");
                            read = Console.ReadLine();
                        }
                        studentList = Functions.DeleteStudent(studentList, Convert.ToInt32(read));
                    }
                    else if (userInput == "Read List") // reads student list 
                    {
                        foreach (student i in studentList)
                        {
                            Console.WriteLine(i.getId().ToString() + ", " + i.getName() + ", " + i.getAge());
                        }
                    }
                    else if (userInput == "Download List") // downloads all students into a CSV file
                    {
                        Functions.WriteToFile(studentList);
                    }
                    else if (userInput == "Load List") // loads list from csv File
                    {
                        studentList = Functions.LoadFile();
                    }
                    else if (userInput == "End") // ends code
                    {
                        end= true;
                    } 
                    else
                    {
                         Console.WriteLine("Error - this isn't an option");
                    }
                }
                else
                {
                    Console.WriteLine("Error - this isn't an option");
                }
            }         
        }
    }
}
