using System.Collections;

namespace Collections
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            ArrayList objArrayList = new ArrayList();
            objArrayList.Add("Naresh");
            objArrayList.Add(10);

            //Object = int ---> boxing
            //int x = arrlst[0] --> unboxing

            
        }

        static void Main3(string[] args)
        {
            //Hashtable objDictionary = new Hashtable();
            SortedList objDictionary = new SortedList();
            objDictionary.Add(10, "Naresh");
            objDictionary.Add(20, "Anannya");
            objDictionary.Add(40, "Mahesh");
            objDictionary.Add(30, "Priyanka");

            objDictionary[10] = "Changed value";    //Update
            
            objDictionary[50] = "New value";    
            //This key was not there so it added it too

            objDictionary.Clear();  //Will empty the collection

            //bool isPresent = objDictionary.Contains(key);
            //bool isPresent = objDictionary.ContainsKey(key);
            //bool isPresent = objDictionary.ContainsValue(value);

            //objDictionary.GetKey(index);
            IList keys = objDictionary.GetKeyList();
            IList values = objDictionary.GetKeyList();

            //objDictionary.IndexOfKey(key);
            //objDictionary.IndexOfValue(value);

            //objDictionary.Keys;
            //objDictionary.Values;

            //objDictionary.Remove(key);
            //objDictionary.RemoveAt(index);

            foreach (DictionaryEntry item in objDictionary.Keys)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value);
            }
        }

        static void Main4(string[] args)
        {
            Stack s = new Stack();
            s.Push(10);

            Console.WriteLine(s.Peek());
            Console.WriteLine(s.Pop());

            Queue q = new Queue();
            q.Enqueue(10);

            Console.WriteLine(q.Peek());
            Console.WriteLine(q.Peek());
        }

        static void Main5(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(10);

            foreach (int item in list)
            {
                Console.WriteLine(item);
            }

            List<Employee> emps = new List<Employee>();
            emps.Add(new Employee { EMPNo = 1, Name = "aaa" });
            emps.Add(new Employee { EMPNo = 2, Name = "aaa" });
            emps.Add(new Employee { EMPNo = 3, Name = "aaa" });

            foreach (Employee item in emps)
            {
                Console.WriteLine(item.Name);
            }
        }

        static void Main6(string[] args)
        {
            SortedList<int, String> list = new SortedList<int, string>();
            list.Add(10, "Naresh");
            list.Add(20, "Mahesh");
            list.Add(30, "Ganesh");
        }

        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(10);

            Queue<int> q = new Queue<int>();
            q.Enqueue(10);
        }
    }

    public class Employee
    {
        public int EMPNo { get; set; }
        public string Name { get; set; }
    }
}
