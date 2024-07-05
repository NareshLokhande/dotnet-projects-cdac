using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Channels;

namespace FuncActionPredicate
{
    //public delegate void Del1();
    internal class Program
    {
        static void Main1()
        {
            //Del1 objDel = new Del1(Display);
            //objDel();

            //Action o1 = new Action(Display);

            Action o1 = Display;
            o1();

            Action<String> o2 = Display;
            o2("Naresh");

            Action<String, int, bool> o3 = Display;
            o3("Naresh", 1, false);
        }
        
        static void Main()
        {
            Func<String> o1 = GetCurrentTime;
            Console.WriteLine(o1());

            Func<int, int> o2 = GetDouble;
            Console.WriteLine(o2(10));

            Func<int, int, int> o3 = Add;
            Console.WriteLine(o3(10, 20));

            Func<int, bool> o4 = IsEven;
            Console.WriteLine(o4(10));

            Predicate<int> o5 = IsEven;
            Console.WriteLine(o5(10));

            //Lambda alternatives
            Func<String> o6 = () => DateTime.Now.ToLongTimeString();
            Console.WriteLine(o6());

            Func<int, int, int> o7 = (a, b) => a + b;
            Console.WriteLine(o7(10, 20));

            Predicate<int> o8 = i => i % 2 == 0;
            Console.WriteLine(o8(15));


            //When you can't shorten it ?
            Func<int, bool> o9 = i =>
            {
                if (i % 2 == 0)
                    return true;
                return false;
            };
            Console.WriteLine(o9(15));

            Action o10 = () => Console.WriteLine("Display");

        }
        static void Display()
        {
            Console.WriteLine("Display..!");
        }

        static void Display(String s)
        {
            Console.WriteLine("Hello " +s+ "..!");
        }

        static void Display(String s, int i, bool b)
        {
            Console.WriteLine("Hello " + s + "..!" +i +b);
        }

        static String GetCurrentTime()
        {
            return DateTime.Now.ToLongTimeString();
        }

        static int GetDouble(int a)
        {
            return a*2;
        }

        static int Add(int a, int b)
        {
            return a + b; 
        }

        static bool IsEven(int a)
        {
            if(a%2 == 0)
                return true;
            else
                return false;
        }
    }
}
