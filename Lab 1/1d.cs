using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSknowledgePro
{

    // Abstract Class Message
    public abstract class Message
    {
        public abstract void show();
    }

    public class Welcome : Message
    {
        public override void show()
        {
            Console.WriteLine("Welcome to Knowledge Pro Max");
        }
    }

    public class student
    {
        public string name;
        public string section;
        public string department;
        public int regno, sem;
        public int[] marks = new int[5];
        public int total;
    }

    // Interface for AddStudent
    public class iAddStudent {
        public List<student> m_studList = new List<student>();
        public int m_nMaxStudents;
        public virtual void AddStudents(){}
        public virtual void AddDetails(){}
    }

    public class AddStudent : iAddStudent
    {

        public override void AddStudents()
        {
            Console.Write("Enter the number of students: ");
            int numStudents = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= numStudents; i++)
            {
                Console.WriteLine("\nEnter " + i.ToString() + " Student Information\n");
                AddDetails();
            }
        }

        public override void AddDetails()
        {
            string name, section, department;
            int regno, sem;
            Console.Write("Student Name: ");
            name = Console.ReadLine();
            Console.Write("Student Register Number: "); // regno
            regno = Convert.ToInt32(Console.ReadLine());
            Console.Write("Semester: "); // Semester
            sem = Convert.ToInt32(Console.ReadLine());
            Console.Write("Section: "); // Section
            section = Console.ReadLine();
            Console.Write("Department: "); // Department
            department = Console.ReadLine();
            student stud = new student();
            stud.name = name;
            stud.sem = sem;
            stud.section = section;
            stud.department = department;
            stud.regno = regno;
            m_studList.Add(stud);
            m_nMaxStudents = m_studList.Count;
        }
    }

    // Interface for InputMarks
    public class iInputMarks {
        public virtual AddStudent GetMarks(){return new AddStudent();}
    }

    public class InputMarks : iInputMarks
    {
        public override AddStudent GetMarks()
        {
            AddStudent students = new AddStudent();
            students.AddStudents();
            int[] marks = new int[5];
            for (int i = 0; i < students.m_nMaxStudents; i++)
            {
                Console.WriteLine("\nEnter " + i.ToString() + " Student Marks\n");
                for (int j = 1; j <= 5; j++)
                {
                    Console.Write("Sub " + j.ToString() + " Mark: ");
                    marks[j - 1] = Convert.ToInt32(Console.ReadLine());
                }
                students.m_studList[i].marks = marks;
                for (int j = 0; j < 5; j++)
                {
                    students.m_studList[i].total += marks[j];
                }
            }

            return students;
        }
    }

    public class iDisplayDetails {
        public virtual void ViewRecords(){}
    }

    public class DisplayDetails : iDisplayDetails
    {
        public override void ViewRecords()
        {
            InputMarks marks = new InputMarks();
            AddStudent students = marks.GetMarks();
            Console.WriteLine("_______________________________________________________________");
            Console.WriteLine("SNo Student Name       Sub1   Sub2   Sub3   Sub4   Sub5   Total");
            Console.WriteLine("_______________________________________________________________");
            for (int i = 0; i < students.m_nMaxStudents; i++)
            {
                Console.Write("{0, -5}", i + 1);
                Console.Write("{0, -19}", students.m_studList[i].name);
                Console.Write("{0, -7}", students.m_studList[i].marks[0]);
                Console.Write("{0, -7}", students.m_studList[i].marks[1]);
                Console.Write("{0, -7}", students.m_studList[i].marks[2]);
                Console.Write("{0, -7}", students.m_studList[i].marks[3]);
                Console.Write("{0, -7}", students.m_studList[i].marks[4]);
                Console.Write("{0, -7}", students.m_studList[i].total);
                Console.WriteLine();
            }
            Console.WriteLine("_______________________________________________________________");
        }
    }

    class Program
    {
        // static public allStudents theStudents = new allStudents();
        static public DisplayDetails records = new DisplayDetails();
        static void Main(string[] args)
        {

            Message m;
            m = new Welcome();
            m.show();

            records.ViewRecords();

            char ch = Console.ReadKey().KeyChar;
        }
    }
}