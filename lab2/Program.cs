using System;
using System.Collections;
using System.Diagnostics;

public  enum Education {Specialist, Bachelor, SecondEducation}

class Program{
    static void Main(string[] args){
       
        Person p1 = new Person();
        Person p2 = new Person();
        // Console.WriteLine("cсылки на p1 p2 равны: " + Object.ReferenceEquals(p1, p2)+"\n");
        // Console.WriteLine("равны объекты p1 p2: " + p1.Equals(p2)+"\n");
        // Console.WriteLine("p1 hash: " + p1.GetHashCode()+"\n");
        // Console.WriteLine("p2 hash: " + p2.GetHashCode()+"\n");   

        Student s1 = new Student(p1, Education.Bachelor, 1);
        Console.WriteLine("свойство person для student : " + s1.p +"\n");   

        Exam cs = new Exam();
        Exam math = new Exam("math", 4, new DateTime(2021-5-6));
        Exam physics = new Exam("physics", 4, new DateTime(2021-5-7));
        Exam[] exams = new Exam[3];
        exams[0]= cs;
        exams[1]= math;
        exams[2]= physics;
        ArrayList examsArrayList = new ArrayList();
        examsArrayList.AddRange(exams);    
        s1.AddExams(examsArrayList);

        Test t = new Test();
        Test[] tests = new Test[1];
        tests[0] = t;
        ArrayList testsArrayList = new ArrayList();
        testsArrayList.AddRange(tests);    
        s1.AddTests(testsArrayList);
        Student s2 = (Student)s1.DeepCopy();
        s1.first =  "Kot";
        Console.WriteLine("оригинальный student : " + s1.ToString() +"\n");    
        Console.WriteLine("скопированный student : " + s2.ToString() +"\n");    
        Console.WriteLine("оригинальный student : " + s1.first +"\n");    


        try
            {
                s1.groupNumber = 600;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            foreach (var task in s1.getAllExamsAndTest())
                Console.WriteLine(task.ToString());


            foreach (var task in s1.getSuccessfulExams(3))
                Console.WriteLine(task.ToString());
    
              foreach (var task in s1.getDoneTestsAndExams())
                Console.WriteLine(task.ToString());

            foreach (var task in s1.getDoneTests())
                Console.WriteLine(task.ToString());


       
    }
}
