using System;
class Student{
        private Person person;
        private Education education;
        int group;
        Exam[] examArr;

        public Person student {
              get { return person; }
            set { person = value; }
        } 
         public Education educationType {
              get { return education; }
            set { education = value; }
        } 

        public int groupNumber {
              get { return group; }
            set { group = value; }
        }

        public Exam[] exams {
              get { return examArr; }
            set { examArr = value; }
        }

         public double meanValue {
              get { 
                  double mean = 0;
                  if (examArr != null){
                    for (int i=0; i<examArr.Length; i++){
                            mean+=examArr[i].grade;
                        }
                     mean /= (double)examArr.Length;
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
     }
      public Student(){
         person = new Person();
         education = Education.Bachelor;
         group = 1;
     }

     public void AddExams(Exam[] exms){
            if (examArr != null) 
                for (int i=0; i<exms.Length; i++){
                    examArr = exms;
                }
            else examArr = exms;

        }
        public override string ToString()
             {
                 string exams = "";
                 if (examArr.Length!=0)
                    foreach(Exam e in examArr){
                        exams += e.ToString() + " ";
                    }

                return person.first +  " " + person.last + " "  + person.birthYear.ToString() + " "
                 + educationType.ToString() + " " + group.ToString() + " " + exams + "\n";
              }
        public virtual string ToShortString()
             {
                return person.first +  " " + person.last + " "  + person.birthYear.ToString() + " " + educationType.ToString() + " " + group.ToString() + " " + meanValue.ToString() + "\n";
            }

    }