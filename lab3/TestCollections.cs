using System;
using System.Collections.Generic;
class TestCollections{
   private  List<Person> plist;
   private List<string> slist;
   private Dictionary<Person, Student> dperson;
   private Dictionary<string, Student> dstring;
   
 static public Student generate(int n)
        {
            return new Student();
        }

   
        public TestCollections(int n)
        {
         plist = new List<Person>(n);
         slist = new List<string>(n);
         dperson = new Dictionary<Person, Student>(n);
         dstring = new Dictionary<string, Student>(n);
        
        }

        public void SearchTheElem(int size)
        {
            Student s = new Student();
            int startOfOperation = Environment.TickCount;
            if (editions.Contains(mag3.MyMethod))
            {
                int finalOperation = Environment.TickCount - startOfOperation;
                Console.WriteLine("В списке Эдишн содержится {0} элемент, время: {1}", size, finalOperation);
            }
 
            int startOfOperation2 = Environment.TickCount;
            if (List1.Contains(mag3.MyMethod.ToString()))
            {
                int finalOperation2 = Environment.TickCount - startOfOperation2;
                Console.WriteLine("В списке Стринг содержится {0} элемента, время: {1}", size, finalOperation2);
            }
 
            int startOfOperation3 = Environment.TickCount;
            if (Dict.ContainsKey(mag3.MyMethod))
            {
                int finalOperation3 = Environment.TickCount - startOfOperation3;
                Console.WriteLine("В списке DictKey содержится {0} элемента, время: {1}", size, finalOperation3);
            }
 
            int startOfOperation4 = Environment.TickCount;
            if (Dict.ContainsValue(mag3))
            {
                int finalOfOperation4 = Environment.TickCount - startOfOperation4;
                Console.WriteLine("В списке DictValue содержится {0} элемента, время: {1}", size, finalOfOperation4);
            }
 
            int startOfOperation5 = Environment.TickCount;
            if (List2.ContainsKey(mag3.MyMethod.ToString()))
            {
                int finalOfOperation5 = Environment.TickCount - startOfOperation5;
                Console.WriteLine("В списке List2Key содержится {0} элемента, время: {1}", size, finalOfOperation5);
            }
 
            int startOfOperation6 = Environment.TickCount;
            if (List2.ContainsValue(mag3))
            {
                int finalOfOperation6 = Environment.TickCount - startOfOperation6;
                Console.WriteLine("В списке List2Value содержится {0} элемента, время: {1}", size, finalOfOperation6);
            }
 
        }
    }
     

}