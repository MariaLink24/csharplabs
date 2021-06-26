using System;
using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;
using testlab;

public  enum Education {Specialist, Bachelor, SecondEducation}

class Program{
    static void Main(string[] args){
       
        Person p1 = new Person("Fyodr", "Uncle", new DateTime(2000, 11, 4));
        Person p2 = new Person();
     
        Student s1 = new Student(p1, Education.Bachelor, 1);
        Student s2 = new Student();
      
   
        Person p3 = new Person();
        Person p4 = new Person();

        Student s3 = new Student(p3, Education.Bachelor, 1);
        Student s4 = new Student(p4, Education.Specialist, 2);


        StudentCollection<Student> stcl = new StudentCollection<Student>();
        StudentCollection<Student> stcl2 = new StudentCollection<Student>();
       

        Journal j1 = new Journal();
        Journal j2 = new Journal();

        stcl.StudentChanged += j1.handler;
        stcl2.StudentChanged += j2.handler;


        Student[] st = new Student[2];
        st[0] = s1;
        st[1] = s2;
        stcl.AddStudents(st);

        Student[] st2 = new Student[2];
        st2[0] = s3;
        st2[1] = s4;
        stcl2.AddStudents(st2);

        stcl.Remove(0);
        stcl.Replace(s2, s3);

        Console.WriteLine(j1);
        Console.WriteLine(j2);
    }
}
