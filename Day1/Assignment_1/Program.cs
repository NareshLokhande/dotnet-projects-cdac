namespace Assignment_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Assignment1 a = new Assignment1();
            a.Name = "Pradeep";
            a.EmpNo = 2;
            a.DeptNo = 2;
            a.Basic = 9;

            Console.WriteLine(a.Name);
            Console.WriteLine(a.EmpNo);
            Console.WriteLine(a.DeptNo);
            Console.WriteLine(a.Basic);
        }
    }

    class Assignment1
    {
        private string name;
        private int empNo;
        private decimal basic;
        private short deptNo;

        public string Name
        {
            set
            {
                if (value.Contains(' '))
                    Console.WriteLine("Invalid Input");
                else
                    name = value;
            }
            get
            {
                return name;
            }
        }


        public int EmpNo
{
    set
    {
        if (value > 0)
            empNo = value;
        else
            Console.WriteLine("Invalid Input");
    }
    get
    {
        return empNo;
    }
}

public decimal Basic
{
    set
    {
        if (value > 8 && value < 12)
            basic = value;
        else
            Console.WriteLine("Invalid Value");
    }
    get
    {
        return basic;
    }
}

public short DeptNo
{
    set
    {
        if (value > 0)
            deptNo = value;
        else
            Console.WriteLine("Invalid Input");
    }
    get
    {
        return deptNo;
    }
}
    }
}