using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class StudentCollection<TKey>  {

private static List<Student> studentList;
private static Dictionary<TKey, Student> studentDictionary = new Dictionary<TKey, Student>;
private static KeySelector<TKey> key;



public double maxMean {
    get {return studentList.Max(s=> s.meanValue);}
}

public IEnumerable<Student> specialists {
    get {return studentList.Where(s=> s.educationType ==Education.Specialist);}
}

public StudentCollection(){
    studentList = new List<Student>();
}

public StudentCollection(KeySelector<TKey> k){
  key = k;
}
public void AddDefaults(){
    studentList.Add(new Student());
}
public void AddStudents(Student[] students){
    for (int i=0; i<students.Length; i++){
        studentList.Add(students[i]);
    }
}

public override string ToString()
    {
        string res = "";
        if (studentList!=null){
            foreach(Student s in studentList){
                res += s.ToString() + " ";
            }
        }
        return res;
    }

public virtual string ToShortString(){
     string res = "";
        if (studentList!=null){
            foreach(Student s in studentList){
                res += s.ToShortString() + " " + s.exams.Count + " " + s.tests.Count + " ";
            }
        }
        return res;
}
public void compareByMeanValue(){
    studentList.Sort((IComparer<Student>) new StudentComparator());

}

public void compareByBirthdate(){
       studentList.Sort( (IComparer<Student>) new Person());

}

public void compareByLastName(){
     studentList.Sort(delegate (Student x, Student y)
            {   
                return x.last.CompareTo(y.last);
            });
}

public IOrderedEnumerable<IGrouping<double, Student>> AverageMarkGroup(double value){
var queryLastNames =
        from student in studentList
        group student by student.meanValue==value into newGroup
        select newGroup;
return (IOrderedEnumerable<IGrouping<double, Student>>)queryLastNames;
}


}

