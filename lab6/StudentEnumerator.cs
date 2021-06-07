using System;
using System.Collections;
using System.Linq;

class StudenEnumerator : IEnumerator{

Student student;
string currSubj;
int position = -1;
ArrayList  subjs;
public StudenEnumerator(Student s){
    student = s;
}
 public object Current {
    get {
      return currSubj;
    }
  }
public bool MoveNext(){
    subjs = getSameSubjects();
    if (position == subjs.Count - 1) {
      Reset();
      return false;
    }
    position++;
    return true;
}
public void Reset(){
    position = -1;

}
public ArrayList getExamNames(){
    ArrayList subjs=null;
            for (int i = 0; i < student.exams.Count; i++)
            {
              Exam ex = (Exam) student.exams[i];
              subjs.Add(ex.subject);
            }

            
            return subjs;
}
public ArrayList getTestsNames(){
    ArrayList subjs=null;
            for (int i = 0; i < student.tests.Count; i++)
            {
              Test t = (Test) student.tests[i];
              subjs.Add(t.subject);
            }

            return subjs;
}
public ArrayList getSameSubjects(){
    var exams = getExamNames();
    var tests = getTestsNames();
var elements = System.Linq.Enumerable.Intersect(exams.ToArray(), tests.ToArray()).ToArray();
ArrayList result = new ArrayList(elements);
return result;
}


}