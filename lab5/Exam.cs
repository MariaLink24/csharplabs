using System;
using System.Collections.Generic;
class Exam : IDateAndCopy, IComparable, IComparer<Exam> {
        public string subject;
        public int grade;
        public DateTime examDate;

    public DateTime Date { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public Exam(string s, int g, DateTime d){
         subject = s;
         grade = g;
         examDate = d;
     }
      public Exam(){
         subject = "C# practice";
         grade = 5;
         examDate = new DateTime(2021, 6, 1);
     }
      DateTime IDateAndCopy.Date
        {
            get { return examDate; }
            set { examDate = value; }

        }
        public override string ToString()
        {
            return subject + " " + grade.ToString() + " " + examDate.ToString() + "\n";
        }
        public object DeepCopy()
        {
            Exam copiedExam = new Exam();
            copiedExam.examDate = examDate;
            copiedExam.grade = grade;
            copiedExam.subject = (string)subject.Clone();
            return (object)copiedExam;
        }

        public int CompareTo(object obj){
            return subject.CompareTo(((Exam)obj).subject);
        }

         public int Compare(Exam x, Exam y)
    {
         if (x.grade < y.grade)
            return 1;
        else if (x.grade > y.grade)
            return -1;
        else
            return 0;
    }

    }