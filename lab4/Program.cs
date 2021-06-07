using System;
using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;

public  enum Education {Specialist, Bachelor, SecondEducation}

class Program{
    static void Main(string[] args){
       
        Person p1 = new Person("Fyodr", "Uncle", new DateTime(2000, 11, 4));
        Person p2 = new Person();
     
        Student s1 = new Student(p1, Education.Bachelor, 1);

        Exam cs = new Exam();
        Exam math = new Exam("math", 4, new DateTime(2021-5-6));
        Exam physics = new Exam("physics", 4, new DateTime(2021-5-7));
        Exam[] exams = new Exam[3];
        exams[0]= cs;
        exams[1]= math;
        exams[2]= physics;
        List<Exam> examsList = new List<Exam>();
        examsList.AddRange(exams);    
        s1.AddExams(examsList);

        Test t = new Test();
        Test[] tests = new Test[1];
        tests[0] = t;
        List<Test> testsList = new List<Test>();
        testsList.AddRange(tests);    
        s1.AddTests(testsList);
     
        Student s2 = new Student();
        Exam ex1 = new Exam();
        Exam[] exams2 = new Exam[1];
        exams2[0]= ex1;
        List<Exam> examsList2 = new List<Exam>();
        examsList2.AddRange(exams);    
        s1.AddExams(examsList2);


       StudentCollection stcl = new StudentCollection();
       Student[] st = new Student[2];
        st[0] = s1;
        st[1] = s2;
        stcl.AddStudents(st);

        Console.WriteLine(stcl.ToString());
        stcl.compareByMeanValue();
        Console.WriteLine("compareByMeanValue " + stcl.ToShortString());
        stcl.compareByLastName();
        Console.WriteLine("compareByLastName " + stcl.ToShortString());
        stcl.compareByBirthdate();
        Console.WriteLine("compareByBirthdate " + stcl.ToShortString());

        Console.WriteLine("max mean value: " + stcl.maxMean);
        Console.WriteLine("specialists: " + stcl.specialists.ToString());
         
        // var grouped = stcl.AverageMarkGroup(4);
        // Console.WriteLine("grouped: ", grouped.ToString());

        TestCollections tc = new TestCollections(3);
        tc.findElementInList();
        tc.findElemetKeyDictionary();
        tc.findEdlemetValueDictionary();
        






    }
}
