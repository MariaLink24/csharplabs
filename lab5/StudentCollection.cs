using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using testlab;


public delegate void StudentListHandler<TKey>(object source, StudentListHandlerEventArgs<TKey> args);

class StudentCollection<TKey>  {


public string name { get; set; }
private static List<Student> studentList;
private static Dictionary<TKey, Student> studentDictionary = new Dictionary<TKey, Student>();
private static KeySelector<TKey> key;
public event StudentListHandler<TKey> StudentChanged;



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

    private KeySelector<TKey> _selector;

    public void AddDefaults()
    {
        Student s = new Student();
        StudentChanged(this, new StudentListHandlerEventArgs<TKey>(name, Update.Add, _selector(s)));
        studentDictionary.Add(_selector(s), s);
    }
    public void AddStudents(params Student[] a)
    {

        foreach (Student x in a)
        {
            StudentChanged(this, new StudentListHandlerEventArgs<TKey>(name, Update.Add, _selector(x)));
            studentDictionary.Add(_selector(x), x);
        }
    }

    public void Remove(int j)
    {

        studentDictionary.RemoveAt(j);
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

    public bool Replace(Student a, Student b)
    {
        TKey k = default(TKey);
        if (studentDictionary.ContainsValue(a))
        {
            foreach (KeyValuePair<TKey, Student> x in studentDictionary)
            {
                if (x.Value == a)
                {
                    k = x.Key;
                    break;
                }
            }
            StudentChanged(this, new StudentListHandlerEventArgs<TKey>(name, Update.Replace, k));
            studentDictionary[k] = b;
            return true;
        }
        else return false;
    }


}

