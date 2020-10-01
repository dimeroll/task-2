using System;
using System.Data;
using System.Collections.Generic;

namespace task2
{
    class Program
    {
        abstract class Student
        {
            public string name;
            public string state;
            public Student(string name_)
            {
                name = name_;
                state = "";
            }
            public void Relax()
            { 
                state = state + "Relax";
            }
            public void Read() 
            {
                state = state + "Read"; 
            }
            public void Write() 
            {
                state = state + "Write"; 
            }
            public abstract void Study();

        }

        class GoodStudent : Student
        {
            public GoodStudent(string name) : base(name)
            {
                state = state + "good";
            }
            public override void Study()
            {
                Read(); Write(); Read(); Write();
                Relax();
            }
        }

        class BadStudent : Student
        {
            public BadStudent(string name) : base(name)
            {
                state = state + "bad";
            }
            public override void Study()
            {
                Relax(); Relax(); Relax(); Relax();
                Read();
            }
        }
        class Group
        {
            public string groupName;
            public List<Student> listOfStudents = new List<Student>();
            public Group(string groupName_)
            {
                groupName = groupName_;
            }
            public void AddStudent(Student st)
            {
                listOfStudents.Add(st);
            }
            public string GetInfo()
            {
                string res = groupName+" : ";
                foreach(Student st in listOfStudents)
                {
                    res = res + st.name + " ";
                }
                return res;
            }

            public string GetFullInfo()
            {
                string res = groupName + " : ";
                foreach (Student st in listOfStudents)
                {
                    res = res + st.name + " - " + st.state + " ";
                }
                return res;
            }
        }
        static void Main(string[] args)
        {
           while(true)
            {
                Console.WriteLine("Введiть назву групи");
                Group group = new Group(Console.ReadLine());
                Console.WriteLine("Введiть iмена поганих студентiв по одному на рядок, якщо ввели усiх, введiть all");
                while (true)
                {
                    string s = Console.ReadLine();
                    if(s != "all")
                    {
                        BadStudent st = new BadStudent(s);
                        group.AddStudent(st);
                        st.Study();
                    }
                    else { break; }
                }

                Console.WriteLine("Введiть iмена успiшних студентiв по одному на рядок, якщо ввели усiх, введiть all");
                while (true)
                {
                    string s = Console.ReadLine();
                    if (s != "all")
                    {
                        GoodStudent st = new GoodStudent(s);
                        group.AddStudent(st);
                        st.Study();
                    }
                    else { break; }
                }
                Console.WriteLine("Iнформацiя про групу " + group.GetFullInfo());
            }
        }
    }
}
