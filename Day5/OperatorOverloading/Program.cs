using System.Net;

namespace OperatorOverloading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Emp o1 = new Emp { EmpNo = 1, Basic = 10000, DepNo = 10, Name="Naresh" };
            Emp o2 = new Emp { EmpNo = 2, Basic = 20000, DepNo = 15, Name="Pradeep" };

            o1 = o1 + 5;
            //o1 = Emp,Operator+(o1,5)


            Emp o3;
            o3 = o1 * o2;
            //o3 = Emp,Operator*(o1,o2)

            Console.WriteLine(o1.DepNo);
            Console.WriteLine(o3.Name);

            int i = 10;
            i = i + 5;

        }
    }

    public class Emp
    {
        public static Emp operator+(Emp o1, int i)
        {
            Emp retval = new Emp();
            retval.EmpNo = o1.EmpNo;
            retval.Basic = o1.Basic;
            retval.Name = o1.Name;
            retval.DepNo = o1.DepNo + i;
            return retval;
        }

        public static Emp operator*(Emp o1, Emp o2)
        {
            Emp retval = new Emp();
            retval.EmpNo = o1.EmpNo;
            retval.Basic = o1.Basic;
            retval.Name = o1.Name + o2.Name;
            retval.DepNo = o1.DepNo;
            return retval;
        }

        public int EmpNo { get; set; }
        public decimal Basic { get; set; }
        public int DepNo { get; set; }
        public String Name { get; set; }

    }
}
