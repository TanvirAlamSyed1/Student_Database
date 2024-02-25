using System;

namespace StudentObject
{
    class student
    {
        //attriubutes
        //public int Id { get; set; }
        private int Id;
        private string Name;
        private int Age;

        //constructor
        public student(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        //getter and setter 
        public string getName()
        {
            return this.Name;
        }
        public int getId()
        {
            return this.Id;
        }
        public int getAge()
        {
            return this.Age;
        }
        public void setId(int id)
        {
            this.Id = id;
        }
        public void setAge(int age)
        {
            this.Age = age;
        }
        public void setName(string name)
        {
            this.Name = name;
        }


        public string speak()
        {
            string speak = "Hello, my name is " + Name + " my ID is " + Id.ToString()+ " I am " + Age.ToString() + " years old";
            return speak;
        }

    }
}
