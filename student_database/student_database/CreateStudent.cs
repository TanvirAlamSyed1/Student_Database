using System;
using System.Text;
using StudentObject;

namespace createstudent
{
    class Functions
    {
        public static student AddStudent() // creating an instance of an object 
        {
            Console.WriteLine("Enter Student ID: ");
            string read = Console.ReadLine(); // reads input of user
            while (int.TryParse(read, out int result) != true) // error prevention
            {
                Console.WriteLine("Error, Try again");
                Console.WriteLine("Enter Student ID: ");
                read = Console.ReadLine();
            }
            int userID = Convert.ToInt32(read); // takes in user ID
            Console.WriteLine("Enter Student Name: ");
            string userName = Console.ReadLine();
            while (string.IsNullOrEmpty(userName))// error prevention
            {
                Console.WriteLine("Error, Try again");
                Console.WriteLine("Enter Student Name: ");
                userName = Console.ReadLine();
            }

            int userAge;
            Console.WriteLine("Enter Student Age: ");
            read = Console.ReadLine();
            while (int.TryParse(read, out int result) != true)// error prevention
            {
                Console.WriteLine("Error, Try again");
                Console.WriteLine("Enter Student Age: ");
                read = Console.ReadLine();
            }
            userAge = Convert.ToInt32(read);
            return new student(userID, userName, userAge); // sends back a new student
        }
        public static List<student> DeleteStudent(List<student> studentList, int studentID)
        {
            int place = 0;  //position variable         
            for (int i = 0; i <= studentList.Count - 1; i++) // reads through each student's ID
            {
                if (studentList[i].getId() == studentID) // if students id is the same
                {
                    place = i; break; // position is noted
                }
            }
            studentList.RemoveAt(place);//remove object from list
            return studentList;
        }

        public static List<student> EditStudent(List<student> studentList, int studentID)
        {
            foreach (student i in studentList) // looks through student list
            {
                if (i.getId() == studentID) // if student id is same as input
                {
                    Console.WriteLine("What would you like to edit: ID , Name or Age"); // asks what you want to edit
                    string userInput = Console.ReadLine();
                    if (userInput != null)
                    {
                        if (userInput == "ID") // asks them for the new item they want to add to the object
                        {
                            Console.WriteLine("Enter Student's New ID: ");
                            string read = Console.ReadLine();
                            while (int.TryParse(read, out int result) != true) // error prevention
                            {
                                Console.WriteLine("Error, Try again");
                                Console.WriteLine("Enter Student's New ID: ");
                                read = Console.ReadLine();
                            }
                            i.setId(Convert.ToInt32(read)); // sets new ID to the object
                        }
                        else if (userInput == "Name")
                        {
                            Console.WriteLine("Enter Student New Name: ");
                            string userName = Console.ReadLine();
                            while (string.IsNullOrEmpty(userName))
                            {
                                Console.WriteLine("Error, Try again");
                                Console.WriteLine("Enter Student New Name: ");
                                userName = Console.ReadLine();
                            }
                            i.setName(userName);
                        }
                        else if (userInput == "Age")
                        {
                            Console.WriteLine("Enter Student Age: ");
                            string read = Console.ReadLine();
                            while (int.TryParse(read, out int result) != true)
                            {
                                Console.WriteLine("Error, Try again");
                                Console.WriteLine("Enter Student Age: ");
                                read = Console.ReadLine();
                            }
                            i.setAge(Convert.ToInt32(read));

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
            return studentList;
        }
        public static void WriteToFile(List<student> studentList)
        {
            var sb = new StringBuilder();
            var basePath = AppDomain.CurrentDomain.BaseDirectory; // gets the current directory's file address
            var finalPath = Path.Combine(basePath, "listOfStudent.csv"); // creates the full path for the file
            if (!File.Exists(finalPath)) // if file doesn't exist
            {
                var file = File.Create(finalPath); // creates the file
                file.Close();
            }
            else
            {
                File.Delete(finalPath); // deletes file so we can write over it
                var file = File.Create(finalPath); // creates new file
                file.Close();
            }
            foreach (student obj in studentList)
            {
                sb = new StringBuilder();
                var line = ""; // empty list
                line = obj.getId().ToString() + "," + obj.getName() + "," + obj.getAge().ToString() + ","; // gets all attributes from the object
                line = line.Substring(0, line.Length - 1);
                sb.AppendLine(line);
                TextWriter sw = new StreamWriter(finalPath, true); // mess around with this 
                sw.Write(sb.ToString());
                sw.Close();
            }
        }

        public static List<student> LoadFile()
        {
            var studentList = new List<student>(); // creates an empty list
            var basePath = AppDomain.CurrentDomain.BaseDirectory; //file directory
            var reader = new StreamReader(basePath + "listOfStudent.csv"); // creates a reader into the file
            if (File.Exists(basePath + "listOfStudent.csv"))// if file exists
            {
                while (!reader.EndOfStream) //  while the file doesn't end
                {
                    var line = reader.ReadLine();// reads a line of the file
                    var values = line.Split(','); // splits the line into an array
                    int counter = 0; // counter is used to identify which attribute we are reading from in the array
                    student addStudent = new student(0, "", 0); // creating an empty student
                    foreach (var item in values)
                    {
                        if (counter == 0)
                        {
                            addStudent.setId(Convert.ToInt32(item)); // edit student's id
                            counter++;
                        }
                        else if (counter == 1)
                        {
                            addStudent.setName(item); // edit student's name
                            counter++;
                        }
                        else if (counter == 2)
                        {
                            addStudent.setAge(Convert.ToInt32(item)); // edit student's age
                            counter = 0;
                        }

                    }
                    studentList.Add(addStudent); // adds student to student list 
                }
            }
            else
            {
                Console.Write("File doesn't exist");
            }
            reader.Close();
            return studentList;
        }
    }
}
