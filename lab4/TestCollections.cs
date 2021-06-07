using System;
using System.Collections.Generic;
using System.Text;
    public delegate KeyValuePair<TKey, TValue> GenerateElement<TKey, TValue>(int j);
    public delegate bool FindElement<TKey>(TKey key);

class TestCollections<TKey,TValue>{
   private  List<TKey> plist;
   private List<string> slist;
   private Dictionary<TKey, TValue> dperson;
   private Dictionary<string, TValue> dstring;
   
 static public Student generate(int n)
        {
            return new Student();
        }

   
        public TestCollections(int n, GenerateElement<TKey,TValue> generator)
        {
         plist = new List<TKey>();
         slist = new List<string>();
         dperson = new Dictionary<TKey, TValue>();
         dstring = new Dictionary<string, TValue>();
        KeyValuePair<TKey, TValue> res;
         for (int i = 0; i <= n; i++)
            {
                res = generator(i);
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

                plist.Add(res.Key);
                slist.Add(str_build.ToString());
                dperson.Add(res.Key, res.Value);
                dstring.Add(str_build.ToString(), res.Value);
            }
        
        }

public  bool FindInlist(TKey key)
        {
           return plist.Contains(key);
        }
       public bool FindInslist(string key)
        {
            return slist.Contains(key);
        }
        public bool FindKeyInDict(TKey key)
        {
             return dperson.ContainsKey(key);
        }
        public bool FindKeyInsDict(string key)
        {
           return  dstring.ContainsKey(key);
        }
        public bool FindVInDict(TValue key)
        {
            return dperson.ContainsValue(key);
        }

    }
     