using System;
using System.Collections.Generic;
using System.Text;

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
         plist = new List<Person>();
         slist = new List<string>();
         dperson = new Dictionary<Person, Student>();
         dstring = new Dictionary<string, Student>();

         for (int i = 0; i <= n; i++)
            {
                StringBuilder str_build = new StringBuilder();  
                Random random = new Random();  
                str_build.Append(Convert.ToChar(Convert.ToInt32(Math.Floor(25 * random.NextDouble())) + 65)); 
                Person randPerson = new Person(str_build.ToString(), str_build.ToString(), new DateTime());
                Student randStudent = new Student(randPerson, Education.Bachelor, 1);
                
                StringBuilder str_build2 = new StringBuilder();  
                Random random2 = new Random();  
                str_build2.Append(Convert.ToChar(Convert.ToInt32(Math.Floor(25 * random2.NextDouble())) + 65)); 
                Person randPerson2 = new Person(str_build2.ToString(), str_build2.ToString(), new DateTime());
                Student randStudent2 = new Student(randPerson2, Education.Bachelor, 1);

                plist.Add(randPerson);
                slist.Add(str_build.ToString());
                dperson.Add(randPerson, randStudent);
                dstring.Add(str_build.ToString(), randStudent2);
            }
        
        }

        public void findElementInList()
        {
            Person randomPerson = new Person("ewfv", "erwfv", new DateTime());
            int start1 = Environment.TickCount;
            if (plist.Contains(plist[0]))
            {
                int end1 = Environment.TickCount - start1;
                Console.WriteLine("plist содержит 1й элемент {0}, время поиска  {1}", plist[1], end1);
            }
            int start2 = Environment.TickCount;

             if (plist.Contains(plist[plist.Count/2]))
            {
                int end2 = Environment.TickCount - start2;
                Console.WriteLine("plist содержит центральный элемент {0}, время поиска  {1}", plist[plist.Count/2], end2);
            }
            int start3 = Environment.TickCount;

             if (plist.Contains(plist[plist.Count-1]))
            {
                int end3 = Environment.TickCount - start3;
                Console.WriteLine("plist содержит последний элемент {0}, время поиска  {1}", plist[plist.Count-1], end3);
            }
            int start4 = Environment.TickCount;

             if (plist.Contains(randomPerson))
            {
                int end4 = Environment.TickCount - start4;
                Console.WriteLine("plist содержит элемент не из коллекции {0}, время поиска  {1}", randomPerson, end4);
            }
           
        }

        public void findElemetKeyDictionary(){
            Person p = new Person("hfjekw", "fkwe", new DateTime());
            Student randomSt = new Student(p, Education.SecondEducation, 2);
             int start1 = Environment.TickCount;
            if (dperson.ContainsKey(dperson[plist[0]]))
            {
                int end1 = Environment.TickCount - start1;
                Console.WriteLine("dperson содержит key 1 элемента {0}, время поиска  {1}", dperson[plist[0]], end1);
            }
            int start2 = Environment.TickCount;
            if (dperson.ContainsKey(dperson[plist[plist.Count/2]]))
            {
                int end2 = Environment.TickCount - start2;
                Console.WriteLine("dperson содержит key центрального элемента {0}, время поиска  {1}", dperson[plist[plist.Count/2]], end2);
            }
            int start3 = Environment.TickCount;
            if (dperson.ContainsKey(dperson[plist[plist.Count-1]]))
            {
                int end3 = Environment.TickCount - start3;
                Console.WriteLine("dperson содержит key последнего элемента {0}, время поиска  {1}", dperson[plist[plist.Count-1]], end3);
            }
            int start4 = Environment.TickCount;
            if (dperson.ContainsKey(randomSt))
            {
                int end4 = Environment.TickCount - start4;
                Console.WriteLine("dperson содержит key элемента не из коллекции {0}, время поиска  {1}", randomSt, end4);
            }

        }

        public void findEdlemetValueDictionary(){
            Student randomSt = new Student();
            int start1 = Environment.TickCount;
            if (dperson.ContainsValue(dperson[plist[0]]))
            {
                int end1 = Environment.TickCount - start1;
                Console.WriteLine("dperson содержит value 1 элемента {0}, время поиска  {1}", dperson[plist[0]], end1);
            }
            int start2 = Environment.TickCount;
            if (dperson.ContainsValue(dperson[plist[plist.Count/2]]))
            {
                int end2 = Environment.TickCount - start2;
                Console.WriteLine("dperson содержит value центрального элемента {0}, время поиска  {1}", dperson[plist[plist.Count/2]], end2);
            }
            int start3 = Environment.TickCount;
            if (dperson.ContainsValue(dperson[plist[plist.Count-1]]))
            {
                int end3 = Environment.TickCount - start3;
                Console.WriteLine("dperson содержит value последнего элемента {0}, время поиска  {1}", dperson[plist[plist.Count-1]], end3);
            }
            int start4 = Environment.TickCount;
            if (dperson.ContainsValue(randomSt))
            {
                int end4 = Environment.TickCount - start4;
                Console.WriteLine("dperson содержит value элемента не из коллекции {0}, время поиска  {1}", randomSt, end4);
            }
 
        }
    }
     