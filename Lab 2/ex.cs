using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSknowledgePro
{

    public class person
    {
        public string name;
        public string department;
        public int regno;
        
    }

    public class student : person
    {
        public string section;
        public float attendance;
        public int sem;
        public int[] marks = new int[5];
        public int[] creds = new int[5];
        public int total;
    }

    public class faculty : person
    {
        public string designation;
    }



    public class AddStudent
    {

        public List<student> m_studList = new List<student>();
        public int m_nMaxStudents;
        public void AddStudents()
        {
            Console.Write("Enter the number of students: ");
            int numStudents = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= numStudents; i++)
            {
                Console.WriteLine("\nEnter " + i.ToString() + " Student Information\n");
                AddDetails();
            }
        }

        public void AddDetails()
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

    public class InputMarks : AddStudent
    {
        public void GetMarks()
        {
            int[] marks = new int[5];
            for (int i = 0; i < m_nMaxStudents; i++)
            {
                Console.WriteLine("\nEnter " + i.ToString() + " Student Marks\n");
                for (int j = 1; j <= 5; j++)
                {
                    Console.Write("Sub " + j.ToString() + " Mark: ");
                    marks[j - 1] = Convert.ToInt32(Console.ReadLine());
                }
                m_studList[i].marks = marks;
                for (int j = 0; j < 5; j++)
                {
                    m_studList[i].total += marks[j];
                }
            }
            // Add Marks to students

        }
    }
    
    public class InputCreds : AddStudent
    {
        public void GetCreds()
        {
            int[] creds = new int[5];
            for (int i = 0; i < m_nMaxStudents; i++)
            {
                Console.WriteLine("\nEnter " + i.ToString() + " Student Credits\n");
                for (int j = 1; j <= 5; j++)
                {
                    Console.Write("Sub " + j.ToString() + " Credits: ");
                    creds[j - 1] = Convert.ToInt32(Console.ReadLine());
                }
                m_studList[i].creds = creds;
                for (int j = 0; j < 5; j++)
                {
                    m_studList[i].total += creds[j];
                }
            }
            // Add credits to students

        }
    }

    public class DisplayDetails : InputMarks
    {
        public void ViewRecords()
        {
            Console.WriteLine("_____________________");
            Console.WriteLine("SNo Student Name       Sub1   Sub2   Sub3   Sub4   Sub5   Total");
            Console.WriteLine("_____________________");
            for (int i = 0; i < m_nMaxStudents; i++)
            {
                Console.Write("{0, -5}", i + 1);
                Console.Write("{0, -19}", m_studList[i].name);
                Console.Write("{0, -7}", m_studList[i].marks[0]);
                Console.Write("{0, -7}", m_studList[i].marks[1]);
                Console.Write("{0, -7}", m_studList[i].marks[2]);
                Console.Write("{0, -7}", m_studList[i].marks[3]);
                Console.Write("{0, -7}", m_studList[i].marks[4]);
                Console.Write("{0, -7}", m_studList[i].total);
                Console.WriteLine();
            }
            Console.WriteLine("_____________________");
        }
    }

    class Program
    {
        // static public allStudents theStudents = new allStudents();
        static public DisplayDetails records = new DisplayDetails();

        static void Main(string[] args)
        {
            // Log in Menu (Admin, Teacher and Student)

            // Admin Menu
            // 1. Add/Remove teachers
            // 2. Add/Remove students

            // Teacher's menu
            // 2. Enter marks
            //      1. Enter all marks
            //      2. Enter a particular student's marks
            // 3. View detials
            //      1. view some detials of all students
            //      2. view all details of a particular student


            // Students menu
            // 1. View Marks
            // 2. View Attendance Percentage
            Console.WriteLine("Welcome to Knowledge Pro Max");
            Console.WriteLine("Are you a :");
            Console.WriteLine("1. Student");
            Console.WriteLine("2. Teacher");
            int selection = Convert.ToInt32(Console.ReadLine());

            switch (selection)
            {
                case 1:
                    break;
                case 2:
                    Boolean flag = true;
                    while (flag)
                    {
                        Console.WriteLine("Select an option:\n1. Add new Student\n2. Enter Marks for students\n3. View records of all students");
                        int selection1 = Convert.ToInt32(Console.ReadLine());
                        switch (selection1)
                        {
                            case 1:
                                records.AddStudents();
                                break;
                            case 2:
                                records.GetMarks();
                                break;
                            case 3:
                                records.ViewRecords();
                                break;
                            case 4:
                                flag = false;
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}