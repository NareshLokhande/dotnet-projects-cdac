namespace FieldsAndProperties
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //int i;  // local variables are unassigned
            //Console.WriteLine(i); //error
            Class1 o1 = new Class1();

            //o1.i = 200;
            //Console.WriteLine(o1.i);

            //o1.SetI(100);
            //Console.WriteLine(o1.GetI());

            //o1.i = ++o1.i + o1.i++ - --o1.i -o1.i--; // can't do this
            o1.I = ++o1.I + o1.I++ - --o1.I -o1.I--; // can do this


            o1.I = 10;     //set
            Console.WriteLine(o1.I);    //get

            o1.Prop3 = "aa";
            Console.WriteLine(o1.Prop3);
        }
    }

    public class Class1
    {
        /*
        //class level variable - field
        private int i;   //initialised to their default value

        public void SetI(int VALUE)
        {
            if (VALUE < 100)
                i = VALUE;
            else
                Console.WriteLine("Invalid value");
        }

        public int GetI() { return i; }
        */

        private int i;

        public int I        //property
        {
            set 
            {
                if (value <100)
                {
                    i = value;
                }
                else
                {
                    Console.WriteLine("Invalid value");
                }
            }
            get { return i; } 
        }

        public String Prop2;    //field
        //Auto Generated - automatic
        //No Validations
        //Compler generates the code for get and set
        //Also Generates the private variable

        public String Prop3 { get; set; }
    }
}
