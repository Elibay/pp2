using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace serialiExample
{
    public class Student
    {
        String name;
        double gpa;
        public Student(String name, double gpa)
        {
            this.name = name;
            this.gpa = gpa;
        }
    }
    public class Lesson
    {
        double averageGpa;
        List<Student> students;
        int count;
        string name;

        public void addStudent(Student student)
        {
            students.Add(student);
        }
        public Lesson()
        {
            name = "";
            averageGpa = 0.0;
            students = new List<Student>();
        }
        public Lesson(String name)
        {
            this.name = name;
            averageGpa = 0.0;
            students = new List<Student>();
        }
        public void save()
        {
            FileStream fs = new FileStream("Lesson.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(Lesson));
            xs.Serialize(fs, this);
            fs.Close();
        }
        public Lesson getLesson()
        {
            FileStream fs = new FileStream("Lesson.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(Lesson));
            Lesson lesson = xs.Deserialize(fs) as Lesson;
            return lesson;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Lesson pp1 = new Lesson("PP 1");
            Student student = new Student("Nur", 2.22);
            pp1.addStudent(student);
            pp1.save();

        }
    }
}
