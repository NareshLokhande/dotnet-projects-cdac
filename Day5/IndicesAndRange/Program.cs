namespace IndicesAndRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String[] names = { "A", "B", "C", "D", "E", "F", "G", "H", "I" };
            Console.WriteLine(IndexExamples.GetFirst(names));
        }
    }

    public class IndexExamples
    {
        public static String GetFirst(string[] names)
        {
            //return names[0];
            Index index = new Index(0);
            return names[index];
        }

        public static String GetLastMethod(string[] names)
        {
            Index index = new Index(1, true);
            return names[index];
        }
    }
}
