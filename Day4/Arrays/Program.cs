namespace Arrays
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            int[] arr = new int[5];
            //arr[0]...arr[4]

            for(int i=0; i<arr.Length; i++)
            {
                //Console.WriteLine("Enter the value for index " +i);     //String concatenation
                //Console.WriteLine("Enter the value for index {0}", i);     //Placeholder
                Console.Write($"Enter the value for index {i} : ");     //String interpolation

                arr[i] = int.Parse( Console.ReadLine() );
                //arr[i] = Convert.ToInt32( Console.ReadLine() );
            }

            foreach (int item in arr)
            {
                Console.WriteLine(item);
            }
            /*
            for each is a read only we cannot use it to accept the elements
            properties can be change but not to the elemenet 
            it is pointing to 
             */
        }

        static void Main2(string[] args)
        {
            int[] arr = new int[5] { 10, 20, 30, 40, 50};
            int[] arr2 =  { 10, 20, 30, 40, 50, 60};
            
            //Array.Clear(arr);   //initialises with default values
            int position = Array.IndexOf(arr, 30);
            position = Array.IndexOf(arr, 35);

            //if (position < 0)   // Not found
            position = Array.LastIndexOf(arr,30);
            position = Array.BinarySearch(arr,30);  // gives value other than minus -1
            
            //Copy array
            Array.Copy(arr, arr2, arr.Length);  //copy from arr to arr2
            Array.ConstrainedCopy(arr, 0, arr2, 0, arr.Length);                                               

            Array.Sort(arr);
            Array.Reverse(arr2); // Reverses
        }

        static void Main3(string[] args)
        {
            int[,] arr = new int[5, 3];     // Two dimentional array

            //Console.WriteLine(arr.Length);
            //Console.WriteLine(arr.Rank);
            //Console.WriteLine(arr.GetLength(0) );
            //Console.WriteLine(arr.GetLength(1));
            //Console.WriteLine(arr.GetUpperBound(0));

            //arr[0,0] arr[0,1] arr[0,2]

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j< arr.GetLength(1); j++)
                {
                    Console.Write($"Enter value for student index {i}, subject index{j} : ");     //String interpolation
                    arr[i, j] = int.Parse(Console.ReadLine());
                }
            }

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.WriteLine($"Array entered is for is arr : ");
                }
            }
        }

        static void Main4(string[] args)
        {
            //Jagged
            int[][] arr = new int[4][];

            //for (int i = 0;i < arr.GetLength(0); i++)
            //{
            //    arr[i] = new int[x];
            //}
            
            arr[0] = new int[3];    //arr[0][0] arr[0][1] arr[0][2]
            arr[1] = new int[4];    //arr[0][0] arr[0][1] arr[0][2] arr[0][3]
            arr[2] = new int[2];    //arr[0][0] arr[0][1] 
            arr[3] = new int[3];    //arr[0][0] arr[0][1] arr[0][2]


            for(int i = 0;i < arr.Length;i++)
            {
                for(int j = 0;j< arr[i].Length;j++)
                {
                    Console.WriteLine("Enter the value for subscript");
                }
            }
        }

        static void Main(string[] args)
        {
            Employee[] arrEmps = new Employee[5];

            //arrEmps[0] = new Employee();
            //arrEmps[1] = new Employee();
            //arrEmps[2] = new Employee();
            //arrEmps[3] = new Employee();
            //arrEmps[4] = new Employee();

            for (int i = 0; i < arrEmps.Length; i++)
            {
                arrEmps[i] = new Employee();
                //arrEmps.Name  //access the properties
            }
        }


        public class Employee
        {
            public int EmpNo { get; set; }
            public String Name { get; set; }
        }
    }
}
