namespace ClassBasics
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("Hello, World!");
            System.Console.WriteLine("Hello from system Console");
        }

        static void Main(string[] args)
        {
            Class1 o = new Class1();
            o.Display();
            o.Display("Hello");

            //Positional Parameter
            Console.WriteLine(o.Add(10, 5, 8));
            Console.WriteLine(o.Add(10, 8));
            Console.WriteLine(o.Add(5));
            Console.WriteLine(o.Add());

            //named parameter
            Console.WriteLine(o.Add(c:10));
            Console.WriteLine(o.Add(b:10));
        }
    }

    public class Class1     //: Object
    {
        public void Display()
        {
            Console.WriteLine("Display");
        }

        public void Display(String s)   // overloading
        {
            Console.WriteLine("Display" +s);
        }
        /*
        public int Add(int a, int b)
        {
            return a + b;
        }
        

        public int Add(int a, int b, int c)
        {
            return a + b + c;
        }
        
        public int Add(int a=0, int b = 0, int c=0)
        {
            return a + b + c;
        }
        */

        public void Dosomething()
        {
            int i = 100;
            Dosomething2(); // can only be called from outer fnction

            //Local function : Function defined within another function
            void Dosomething2()
            {
                //Local functions can access local variables declared in the outer variables

                Console.WriteLine(i);
            }

            //TO DO - try to overload a local function
        }

        
    }
}

namespace MyNamespace
{
    public class class1 { }
    namespace n1
    {
        public class class2 { }
    }
}