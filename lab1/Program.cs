using System;
using System.Diagnostics;

public  enum Education {Specialist, Bachelor, SecondEducation}

class Program{
    static void Main(string[] args){
        Student rand_student = new Student();
        Console.WriteLine("данные студента: " + rand_student.ToShortString());

        Console.WriteLine(rand_student[Education.Bachelor]);
        Console.WriteLine(rand_student[Education.SecondEducation]);
        Console.WriteLine(rand_student[Education.Specialist]);

        Person justPerson = new Person("Kot", "Matroskin", new DateTime(1999, 1, 1));
        Student new_rand_student = new Student(justPerson, Education.Specialist, 2);
        Console.WriteLine("данные второго студента: " + new_rand_student.ToShortString());

        Exam cs = new Exam();
        Exam math = new Exam("math", 4, new DateTime(2021-5-6));
        Exam physics = new Exam("physics", 4, new DateTime(2021-5-7));
        Exam[] exams = new Exam[3];
        exams[0]= cs;
        exams[1]= math;
        exams[2]= physics;
        new_rand_student.AddExams(exams);
        Console.WriteLine("данные второго студента  с экзаменами: " + new_rand_student.ToString());
        int n = 4;
        int m = 4;
        Exam[] exms1 = new Exam[n*m];
        for (int i = 0; i < n * m;i++) 
                exms1[i] = new Exam();
        Exam[,] exms2 = new Exam[n,m];
        for (int i = 0; i < n; i++) 
                for (int j = 0; j < m; j++) 
                    exms2[i,j] = new Exam();
            int sum = 0; 
            int k = 0;
            for (; sum < 4 * 4; k++)
                sum += k;
        Exam[][] exms3 = new Exam[n][];
        for (int i = 0; i < n; i++)
            {
                exms3[i] = new Exam[i];
                for (int j = 0; j < i; j++)
                    exms3[i][j] = new Exam();
            }
        Stopwatch timer = new Stopwatch();

          timer.Start();
            for(int i=0;i<n*m;i++)
            {
                exms1[i].subject = "russian";
                exms1[i].grade = 5;
                exms1[i].examDate = new DateTime();
            }
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            string time1 = timeTaken.ToString(@"m\:ss\.fff"); 
            timer.Start();
            for(int i=0;i<n;i++)
                for(int j=0;j<m;j++)
                {
                    exms2[i, j].subject = "russian";
                    exms2[i, j].grade = 5;
                    exms2[i, j].examDate = new DateTime();
                }
            timer.Stop();
            TimeSpan timeTaken2 = timer.Elapsed;
            string time2 = timeTaken2.ToString(@"m\:ss\.fff");             
            timer.Start();
            for(int i=0;i< n;i++)
                for(int j=0;j< i;j++)
                {
                    exms3[i][j].subject = "russian";
                    exms3[i][j].grade = 5;
                    exms3[i][j].examDate = new DateTime();
                }
            TimeSpan timeTaken3 = timer.Elapsed;
            string time3 = timeTaken3.ToString(@"m\:ss\.fff");                
            timer.Stop();
            Console.WriteLine("одномерный: " + time1+"\n");
            Console.WriteLine("двумерный прямоугольный: " + time2 + "\n");
            Console.WriteLine("двумерный ступенчатый: " + time3 + "\n");
            
    }
}
