namespace Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            class1 o1 = new class1();
            o1.Display();
            o1.Delete();
            o1.Insert();
            o1.Update();
        }
    }

    public interface IDbFunctions
    {
        void Insert();
        void Update();
        void Delete();
    }

    public class class1 : IDbFunctions
    {
        public void Display()
        { 
            Console.WriteLine("Display from class 1");
        }

        public void Update()
        {
            Console.WriteLine("idb Delete from class1");
        }

        public void Delete()
        {
            Console.WriteLine("idb Delete from class1");
        }

        public void Insert()
        {
            Console.WriteLine("idb insert from class1");
        }
    }
}
