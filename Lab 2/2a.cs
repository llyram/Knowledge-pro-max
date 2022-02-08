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
        public int total_marks;
        public int total_creds;
    }

    public class faculty : person
    {
        public string designation;
    }



    public class AddStudent
    {

        public static List<student> m_studList = new List<student>();
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
                    m_studList[i].total_marks += marks[j];
                }
            }
            // Add Marks to students

        }

        public void ViewSingle(int reg_no)
        {
            for (int i = 0; i < m_nMaxStudents; i++)
            {
                if (m_studList[i].regno == reg_no)
                {
                    Console.WriteLine("_______________________________________________________________");
                    Console.WriteLine("SNo Student Name       Sub1   Sub2   Sub3   Sub4   Sub5   Total");
                    Console.WriteLine("_______________________________________________________________");
                    Console.Write("{0, -5}", i + 1);
                    Console.Write("{0, -19}", m_studList[i].name);
                    Console.Write("{0, -7}", m_studList[i].marks[0]);
                    Console.Write("{0, -7}", m_studList[i].marks[1]);
                    Console.Write("{0, -7}", m_studList[i].marks[2]);
                    Console.Write("{0, -7}", m_studList[i].marks[3]);
                    Console.Write("{0, -7}", m_studList[i].marks[4]);
                    Console.Write("{0, -7}", m_studList[i].total_marks);
                    Console.WriteLine();
                }
            }
        }
    }

    public class InputCreds : AddStudent
    {
        public void GetCreds()
        {
            Console.WriteLine("");
            int[] creds = new int[5];
            for (int i = 0; i < m_studList.Count; i++)
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
                    m_studList[i].total_creds += creds[j];
                }
            }
            // Add credits to students

        }
    }

    sealed public class DisplayMarks : InputMarks
    {
        public void ViewMarks()
        {
            Console.WriteLine("_______________________________________________________________");
            Console.WriteLine("SNo Student Name       Sub1   Sub2   Sub3   Sub4   Sub5   Total");
            Console.WriteLine("_______________________________________________________________");
            for (int i = 0; i < m_nMaxStudents; i++)
            {
                Console.Write("{0, -5}", i + 1);
                Console.Write("{0, -19}", m_studList[i].name);
                Console.Write("{0, -7}", m_studList[i].marks[0]);
                Console.Write("{0, -7}", m_studList[i].marks[1]);
                Console.Write("{0, -7}", m_studList[i].marks[2]);
                Console.Write("{0, -7}", m_studList[i].marks[3]);
                Console.Write("{0, -7}", m_studList[i].marks[4]);
                Console.Write("{0, -7}", m_studList[i].total_marks);
                Console.WriteLine();
            }
            Console.WriteLine("_______________________________________________________________");
        }
    }

    sealed public class DisplayCreds : InputCreds
    {
        public void ViewCreds()
        {
            Console.WriteLine("_______________________________________________________________");
            Console.WriteLine("SNo Student Name       Sub1   Sub2   Sub3   Sub4   Sub5   Total");
            Console.WriteLine("_______________________________________________________________");
            for (int i = 0; i < m_studList.Count; i++)
            {
                Console.Write("{0, -5}", i + 1);
                Console.Write("{0, -19}", m_studList[i].name);
                Console.Write("{0, -7}", m_studList[i].creds[0]);
                Console.Write("{0, -7}", m_studList[i].creds[1]);
                Console.Write("{0, -7}", m_studList[i].creds[2]);
                Console.Write("{0, -7}", m_studList[i].creds[3]);
                Console.Write("{0, -7}", m_studList[i].creds[4]);
                Console.Write("{0, -7}", m_studList[i].total_creds);
                Console.WriteLine();
            }
            Console.WriteLine("_______________________________________________________________");
        }
    }

    class Program
    {
        // static public allStudents theStudents = new allStudents();
        static public DisplayMarks mark_records = new DisplayMarks();
        static public DisplayCreds cred_records = new DisplayCreds();
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
            Boolean flag;
            while (true)
            {
                Console.WriteLine("Welcome to Knowledge Pro Max");
                Console.WriteLine("Are you a :");
                Console.WriteLine("1. Student");
                Console.WriteLine("2. Teacher");
                int selection = Convert.ToInt32(Console.ReadLine());

                switch (selection)
                {
                    case 1:
                        flag = true;
                        while (flag)
                        {
                            Console.WriteLine("Enter your register number : ");
                            int reg_no = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Select an option:\n1. View Marks\n2. View Attendance\n3. Exit to Main menu");
                            int selection1 = Convert.ToInt32(Console.ReadLine());
                            switch (selection1)
                            {
                                case 1:
                                    mark_records.ViewSingle(reg_no);
                                    break;
                                case 2:
                                    break;
                                case 3:
                                    flag = false;
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    case 2:
                        flag = true;
                        while (flag)
                        {
                            Console.WriteLine("Select an option:\n1. Add new Student\n2. Enter Marks for students\n3. Enter Credis for students\n4. View marks of all students\n5. View credits of all students\n6. Exit to Main menu");
                            int selection1 = Convert.ToInt32(Console.ReadLine());
                            switch (selection1)
                            {
                                case 1:
                                    mark_records.AddStudents();
                                    break;
                                case 2:
                                    mark_records.GetMarks();
                                    break;
                                case 3:
                                    cred_records.GetCreds();
                                    break;
                                case 4:
                                    mark_records.ViewMarks();
                                    break;
                                case 5:
                                    cred_records.ViewCreds();
                                    break;
                                case 6:
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
}
