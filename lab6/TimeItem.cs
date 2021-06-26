using System;
namespace testlab
{
   
    public class TimeItem
    { 
        
        public int n { get; set; }
        public int k { get; set; }
        public double CsTime { get; set; }
        public double CppTime { get; set; }
        public double Factor { get { return CsTime / CppTime; } }

        public TimeItem() { }

        public TimeItem(int n, int k, double csTime, double cppTime)
        {
            this.n = n; this.k = k; this.CsTime = csTime; this.CppTime = cppTime;
        }

        public override string ToString()
        {
            return "Порядок: " + n + "; Повтороы: " + k + "; Время C#: " + CsTime + "; Время С++: " + CppTime + "; коэф: " + Factor;
        }
    }
}
