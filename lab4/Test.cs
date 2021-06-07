using System;

class Test{
    public string subject;
    public bool isPassed;

    public Test(){
        subject = "test subject";
        isPassed = true;
    }
     public Test(string s, bool i){
        subject = s;
        isPassed = i;
    }
      public override string ToString()
        {
            return subject + " " + isPassed.ToString()  + "\n";
        }
     public object DeepCopy()
        {
            Test copiedTest = new Test();
            copiedTest.subject = (string)subject.Clone();
            copiedTest.isPassed = isPassed;
            return (object)copiedTest;
        }
}