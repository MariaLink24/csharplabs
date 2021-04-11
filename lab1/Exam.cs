using System;
class Exam {
        public string subject;
        public int grade;
        public DateTime examDate;

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
        public override string ToString()
        {
            return subject + " " + grade + " " + examDate.ToString() + "\n";
        }

    }