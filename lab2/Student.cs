using System;
using System.Collections;
class Student : Person, IDateAndCopy, IEnumerable{
        
        private Person person;
        private Education education;
        private int group;
        private ArrayList examArr;
        private ArrayList testArr;


         public Education educationType {
              get { return education; }
            set { education = value; }
        } 


        public int groupNumber {
              get { return group; }
            set {  
                 if (value <= 100 || value > 599)
                {
                    throw new ArgumentOutOfRangeException("err: boundaries exceeded [100; 599)");
                }
                groupNumber = value; 
                }
        }

        public System.Collections.ArrayList exams {
              get { return  (System.Collections.ArrayList)examArr; }
            set { examArr = (System.Collections.ArrayList)value; }
        }
         public System.Collections.ArrayList tests {
              get { return  (System.Collections.ArrayList)testArr; }
            set { testArr = (System.Collections.ArrayList)value; }
        }
        public Person p {
             get
            {
                return new Person((string)firstName.Clone(), (string)lastName.Clone(), birthDate);
            }
            set
            {
                firstName = (string)value.first.Clone();
                lastName = (string)value.last.Clone();
                birthDate = value.date;
            }
        }

         public double meanValue {
              get { 
                  double mean = 0;
                  if (examArr != null){
                    foreach(Exam e in examArr){
                            mean+=e.grade;
                        }
                     mean /= (double)examArr.Count;
                  }
                 return mean;
        }
         }
         public bool this[Education index] {
              get  {return education == index; }
        }

     public Student(Person p, Education e, int g){
         person = p;
         education = e;
         group = g;
         examArr = new System.Collections.ArrayList();
         testArr = new System.Collections.ArrayList();
     }
      public Student(){
         Person person = new Person();
         education = Education.Bachelor;
         group = 1;
         examArr = new System.Collections.ArrayList();
         testArr = new System.Collections.ArrayList();

     }

     public void AddExams(ArrayList exms){
            if(exms != null){
                foreach (Exam e in exms){
                   examArr.Add(e.DeepCopy());

                }
            }
        }

        public void AddTests(ArrayList tsts){
            if (tsts != null) {
                foreach (Test t in tsts){
                    testArr.Add(t.DeepCopy());
                }
            }
        }
        public override string ToString()
             {
                string result;
                result = person.ToString() + " "  +
                   educationType.ToString() +
                  " " + group.ToString() + " ";
                  
            if (examArr!=null) {
                foreach(Exam e in examArr)
                result = result + e.ToString() + " ";
            }
             if (testArr!=null) {
                foreach(Test t in testArr)
                result = result + t.ToString() + " ";
             }
                return result;

              }
        public override string ToShortString()
             {
                return person.first + " " + person.last+ " " + person.date.ToString() + " " +educationType.ToString() + " " + group.ToString() + " " + meanValue.ToString() + "\n";
            }
           public override object DeepCopy()
        {
            Student copiedStudent = new Student(person, education, group);
            copiedStudent.AddExams(this.examArr);
            copiedStudent.AddTests(this.testArr);
        
            return copiedStudent;
        }


        public IEnumerable getAllExamsAndTest() {
        if (examArr!=null){
            foreach (var exam in examArr)
                yield return exam;
        }
        if (testArr!=null){
            foreach (var test in testArr)
                yield return test;
        }
        }

        public IEnumerable getSuccessfulExams(int k) {
            if(examArr!=null){
            foreach (var exam in examArr) {
                Exam ex = (Exam) exam;
                if (ex.grade > k)
                    yield return exam;
            }
            }
        }
        public IEnumerable getDoneTestsAndExams(){
            if(examArr!=null){
                foreach(var exam in examArr){
                    Exam ex = (Exam) exam;
                if (ex.grade > 2)
                    yield return exam;
            }
                }
                if(testArr!=null){
                foreach(var test in testArr){
                    Test t = (Test) test;
                if (t.isPassed)
                    yield return test;
            }
                }
            }



          public IEnumerable getDoneTests(){
             if(examArr!=null){
                foreach(var exam in examArr){
                    Exam ex = (Exam) exam;

                if(testArr!=null){
                foreach(var test in testArr){
                    Test t = (Test) test;
                if (t.isPassed && t.subject==ex.subject && ex.grade>2)
                    yield return test;
            }
                }
          }
        }
    }

     public IEnumerator GetEnumerator()
        {
         return new StudenEnumerator(this);
    }

}