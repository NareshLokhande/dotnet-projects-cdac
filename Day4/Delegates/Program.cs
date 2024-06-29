namespace Delegates
{
    // Step 1 : Create a delegate class having
    // the same signature as the function to call

    public delegate void Del1();

    // Object
    // Delegate
    // MulticastDelegate
    // Del1

    public delegate int DelAdd(int a, int b);
    internal class Program1
    {
        static void Main1()
        {
            // Step 2 : Declare a delegate reference , create a delegate 
            // object and pass function name as a parameter 

            Del1 objDel = new Del1(Display);

            // Step 3 : Call the dunction via the delegate reference
            objDel();
        }

        static void Main2()
        {
            //Del1 objDel = new Del1(Display);
            Del1 objDel = Display;      //same result as above
            objDel();

            objDel = Show;
            objDel();

            Console.WriteLine();
            objDel += Show;     // It will now point to display as well as show
            // This is multicastdelegate
            objDel();

            Console.WriteLine();
            objDel += Display;     
            objDel();

            Console.WriteLine();
            objDel -= Display;
            objDel();

            Console.WriteLine();
            objDel -= Show;
            objDel();

            Console.WriteLine();
            objDel -= Show;
            objDel();
        }

        static void Main3()
        {
            DelAdd o1 = Add;
            Console.WriteLine(o1(10,5));

            Class1 o2 = new Class1();
            //o1 = o2.Show;
        }

        static void Main4()
        {
            Del1 objDel =(Del1) Delegate.Combine(new Del1(Display), new Del1(Show), new Del1(Display));
            objDel();

            //Delete the last added
            //objDel = (Del1)Delegate.Remove(objDel, new Del1(Display));
            
            //Remove all occurances of display
            objDel = (Del1)Delegate.RemoveAll(objDel, new Del1(Display));

            objDel();
        }



        // TO DO - Try calling a function with return values as multi cast delegate
        static void Display()
        {
            Console.WriteLine("Display..!");
        }

        static void Show()
        {
            Console.WriteLine("Show..!");
        }

        static int Add(int a, int b)
        {
            return a + b;
        }

        public class Class1
        {
            static void Display()
            {
                Console.WriteLine("Display..!");
            }

            static void Show()
            {
                Console.WriteLine("Show..!");
            }
        }
    }
    
    internal class Program
    {
        static int Add(int a, int b)
        { return a + b; }
        static int Subtract(int a, int b)
        { return a - b; }
        static int Multiply(int a, int b)
        { return a * b; }
        

        static void main()
        {
            Console.WriteLine(CallMathOperation(Add));
            Console.WriteLine(CallMathOperation(Subtract));
            Console.WriteLine(CallMathOperation(Multiply));
        }
        //pass function to be called as a parameter

        static int CallMathOperation(DelAdd objMathOperation)   //objMathOperartion = Add
        {
            return objMathOperation(10, 5);
        }
    }
}
