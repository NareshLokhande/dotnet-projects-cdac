using System.Threading.Channels;

namespace ConstrAndObjectInitializer
{
    internal class Program
    {
        static void Main(string[] args)
        {
           // Class1 o1 = new Class1();
           //Console.WriteLine(o1.);
           
            //Without Object initializer
            Class1 o2 = new Class1();
            o2.i = 10;
            o2.j = 20;
            o2.k = 30;
            o2.P1 = 50;

            //object initializer
            Class1 o3 = new Class1() { i=10, j=20 ,k=30,P1=50};

            // object initializer without () -> Gives same output
            Class1 o3 = new Class1 { i = 10, j = 20, k = 30, P1 = 50 };
        }
    }
}

public class Class1
{
    public int i;
    public int j;
    public int k;
    /*
    public Class1()
    {
        Console.WriteLine("No param const called");
        i= 10;
    }

    public Class1(int i, int j, int k)
    {
        Console.WriteLine("Int const called");
        this.i = i;
        this.j = j;
        this.k = k;
        //this is a reference to the current object
    }
    */

    private int p1;
    public int P1
    {
        set
        {
            if (value < 10)
            {
                p1=value;
            }
            else
            {
                Console.WriteLine("Invalid P1");
            }
        }
        get { return p1; }
    }

    public Class1(int i=10 , int j=20, int k=30)
    {
        Console.WriteLine("Int const called");
        this.p1 = P1;   //variable  -> Don't use this -> no validations
        this.P1 = P1;   //set for P1

        this.i = i;
        this.j = j;
        this.k = k;
        //this is a reference to the current object
    }
}