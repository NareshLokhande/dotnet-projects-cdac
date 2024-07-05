namespace ExceptionHandling
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            Class1 obj = new Class1();
            obj = null;
            int x = Convert.ToInt32(Console.ReadLine());
            obj.P1 = 100 / x;
            Console.WriteLine(obj.P1);
            Console.ReadLine();
        }

        static void Main2(string[] args)
        {
           try
            {
                Class1 obj = new Class1();
                obj = null;
                int x = Convert.ToInt32(Console.ReadLine());
                obj.P1 = 100 / x;
                Console.WriteLine(obj.P1);
                Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("Exception Occured");
            }
        }

        static void Main3(string[] args)
        {

            Class1 obj = new Class1();
            try
            {
                obj = null;
                int x = Convert.ToInt32(Console.ReadLine());
                obj.P1 = 100 / x;
                Console.WriteLine(obj.P1);
                Console.ReadLine();
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("DBException Occured");
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine("NRException occured");
            }
            catch(FormatException ex)
            {
                Console.WriteLine("FRException occured");
            }
            Console.ReadLine();
        }

        static void Main4(string[] args)
        {
            Class1 obj = new Class1();
            try
            {
                obj = null;
                int x = Convert.ToInt32(Console.ReadLine());
                obj.P1 = 100 / x;
                Console.WriteLine(obj.P1);
                Console.ReadLine();
            }
            catch(FormatException ex)
            {
                Console.WriteLine("Format Exception Occured");
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine("NRException occured");
            }
            catch (DivideByZeroException ex)
            //catch (ArithmeticException ex) 
            //catch (SystemException ex) //base class exception has to caught after derived class exceptions
            {
                Console.WriteLine("DBException occurred");
            }
            catch (Exception ex) //catches all unhandled exceptions
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();

        }

        static void Main5(string[] args)
        {
            Class1 obj = new Class1();
            try
            {
                //obj = null;
                int x = Convert.ToInt32(Console.ReadLine());
                obj.P1 = 100 / x;
                Console.WriteLine(obj.P1);
                Console.WriteLine("No Exceptions");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Format Exception Occured");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("NRException occured");
            }
            catch (DivideByZeroException ex)
            //catch (ArithmeticException ex) 
            //catch (SystemException ex) //base class exception has to caught after derived class exceptions
            {
                Console.WriteLine("DBException occurred");
            }
            catch (Exception ex) //catches all unhandled exceptions
            {
                Console.WriteLine(ex.Message);
            }
            // Finnaly runs when exception does not occur or when occures and is 
            //handled or exception occurs and is not handle

            finally
            {
                Console.WriteLine("Finally");
            }
            Console.WriteLine("After finnaly");
        }

        static void Main6()// nested try block
        {
            Class1 obj = new Class1();
            try
            {
                //obj = null;
                int x = Convert.ToInt32(Console.ReadLine());
                obj.P1 = 100 / x;
                Console.WriteLine(obj.P1);
                Console.WriteLine("No Exceptions");
            }

            catch (FormatException ex)
            {
                try
                {
                    Console.WriteLine("FormatException occurred. Enter only numbers");
                    int x = Convert.ToInt32(Console.ReadLine());
                    obj.P1 = 100 / x;
                    Console.WriteLine(obj.P1);
                }
                catch
                {
                    Console.WriteLine("nested try catch example");
                }
                finally
                {
                    Console.WriteLine("nested try finally example");
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("NRException occurred");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("DBException occurred");
            }
            catch (Exception ex) //catches all unhandled exceptions
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("finally");

            }
            Console.ReadLine();
        }
    }

    public class Class1
    {
        private int p1;

        public int P1
        {
            get { return p1; }
            set { p1 = value; }
        }
    }
}

namespace ExceptionHandling2
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 obj = new Class1();
            try
            {
                int x = Convert.ToInt32(Console.ReadLine());
                obj.P1 = x;
                Console.WriteLine(obj.P1);
                Console.WriteLine("No Exceptions");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("FormatException occurred");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("NRException occurred");
            }
            catch (InvalidP1Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.ReadLine();
        }
    }

    public class InvalidP1Exception : Exception
    {
        public InvalidP1Exception(string message) : base(message)
        {

        }
    }
    public class Class1
    {
        private int p1;
        public int P1
        {
            get { return p1; }
            set
            {
                if(value < 100)
                    p1 = value;
                else
                {
                    throw new Exception();
                    throw new Exception("Invalid P1");
                    //throw new InvalidP1Exception();

                    throw new InvalidP1Exception("Invalid P1");

                }
            }
    }
}