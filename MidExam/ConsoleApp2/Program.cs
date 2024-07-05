using static ConsoleApp2.TestCode;

namespace ConsoleApp2
{
    internal class TestCode
    {
        public class ProductException : Exception
        {
            public ProductException(string message) : base(message)
            {
            }
        }

        public class CategoryException : Exception
        {
            public CategoryException(string message) : base(message)
            {
            }
        }

        public class Product
        {
            private int productId;
            private string productName;
            private decimal price;
            private int categoryId;

            public int ProductId
            {
                get { return productId; }
                set
                {
                    if (value <= 0)
                        throw new ProductException("Product ID must not be less than 0.");
                    productId = value;
                }

            }
            public string ProductName 
            {
                get { return productName; }
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ProductException("ProductName cannot be null or empty.");
                    productName = value;
                }
            }
            public decimal Price
            {
                get { return price; }
                set
                {
                    if (value <= 0)
                        throw new ProductException("Price must be greater than 0.");
                    price = value;
                }
            }
            public int CategoryId
            {
                get { return categoryId; }
                set { categoryId = value; }
            }

            public override string ToString()
            {
                return $"ProductID: {ProductId}, Name: {ProductName}, Price: {Price}, CategoryID: {CategoryId}";
            }
        }

        public class Category
    {
            private int categoryId;
            private string categoryName;

            public int CategoryId
            {
                get { return categoryId; }
                set
                {
                    if (value <= 0)
                        throw new CategoryException("CategoryId must be greater than 0.");
                    categoryId = value;
                }
            }

            public string CategoryName
            {
                get { return categoryName; }
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new CategoryException("CategoryName cannot be null or empty.");
                    categoryName = value;
                }
            }
            public override string ToString()
            {
                return $"CategoryID: {CategoryId}, CategoryName: {CategoryName}";
            }
    }

        public static List<Product> Products = new List<Product>();
        public static List<Category> Categories= new List<Category>();
        public static void InitiateRecords()
    {
            Categories.Add(new Category { CategoryId = 1, CategoryName = "Electronics" });
            Categories.Add(new Category { CategoryId = 2, CategoryName = "Mobile devices" });
            Categories.Add(new Category { CategoryId = 3, CategoryName = "Accessories" });
            Categories.Add(new Category { CategoryId = 4, CategoryName = "Clothing" });
            Categories.Add(new Category { CategoryId = 5, CategoryName = "Sports" });

            Products.Add(new Product { ProductId = 101, ProductName = "Laptop", Price = 56000, CategoryId = 1 });
            Products.Add(new Product { ProductId = 102, ProductName = "Smartphone", Price = 15000, CategoryId = 2 });
            Products.Add(new Product { ProductId = 103, ProductName = "Tablet", Price = 10000, CategoryId = 1 });
            Products.Add(new Product { ProductId = 104, ProductName = "Monitor", Price = 500, CategoryId = 3 });
            Products.Add(new Product { ProductId = 105, ProductName = "Keyboard", Price = 1200, CategoryId = 3 });
            Products.Add(new Product { ProductId = 106, ProductName = "T-Shirt", Price = 600, CategoryId = 4 });
            Products.Add(new Product { ProductId = 107, ProductName = "Jeans", Price = 1200, CategoryId = 4 });
            Products.Add(new Product { ProductId = 108, ProductName = "Football", Price = 1200, CategoryId = 5 });
            Products.Add(new Product { ProductId = 109, ProductName = "Cricket Ball", Price = 1200, CategoryId = 5 });
            Products.Add(new Product { ProductId = 110, ProductName = "Cricket helmet", Price = 1200, CategoryId = 5 });

    }

        static void Main(string[] args)
        {
            //a. call InitiateRecords Method
            InitiateRecords();

            //b. Select all products and display using for each
            var allProductsQuery = from p in Products select p;
            var AllProductsLambda = Products.Select(p => p);

            Console.WriteLine("All products:");
            foreach (var p in allProductsQuery)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();

            Console.WriteLine("All products (lambda):");

            foreach (var p in AllProductsLambda)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();


            //c. Select ProductId and Product Name
            var productNamesQuery = from p in Products select new { p.ProductId, p.ProductName };
            var productNamesQueryLambda = Products.Select(p => new { p.ProductId, p.ProductName });

            Console.WriteLine("Product IDs and Names :");
            foreach (var item in productNamesQuery)
            {
                Console.WriteLine($"ID: {item.ProductId}, Name:{item.ProductName}");
            }
            Console.WriteLine();


            Console.WriteLine("Product IDs and Names (Lamda) :");
            foreach (var item in productNamesQueryLambda)
            {
                Console.WriteLine($"ID: {item.ProductId}, Name:{item.ProductName}");
            }
            Console.WriteLine();


            //d. Select Product price greater than 1000
            var expensiveproductQuery = from p in Products where p.Price > 1000 select p;
            var expensiveproductQueryLambda = Products.Where(p => p.Price > 1000);

            Console.WriteLine("Products greater than 1000 :");
            foreach (var p in expensiveproductQuery)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();


            Console.WriteLine("Products greater than 1000 (Lamda) :");
            foreach (var p in expensiveproductQueryLambda)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();


            //e. Select Products between 500 and 1500
            var midRangeproductQuery = from p in Products where p.Price >= 500 && p.Price <= 1500 select p;
            var midRangeproductQueryLambda = Products.Where(p => p.Price >= 500 && p.Price <= 1500);

            Console.WriteLine("Mid range Products between 500 and 1500 :");
            foreach (var p in midRangeproductQuery)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();


            Console.WriteLine("Mid range Products between 500 and 1500  (Lambda):");
            foreach (var p in midRangeproductQueryLambda)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();


            //f. Select Product by decending order
            var orderByproductDescQuery = from p in Products orderby p.ProductName descending select p;
            var orderByproductDescQueryLambda = Products.OrderByDescending(p => p.ProductName);

            Console.WriteLine("Products order by Product name :");
            foreach (var p in orderByproductDescQuery)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();


            Console.WriteLine("Products order by Product name  (Lambda):");
            foreach (var p in orderByproductDescQueryLambda)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();


            //g. Select Product by Both order
            var orderByproductBothQuery = from p in Products orderby p.Price ascending, p.ProductName descending select p;
            var orderByproductBothQueryLambda = Products.OrderByDescending(p => p.Price).ThenByDescending(p => p.ProductName);

            Console.WriteLine("Products order by Price (Ascending) and Product name (descending) :");
            foreach (var p in orderByproductBothQuery)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();


            Console.WriteLine("Products order by Price (Ascending) and Product name (descending) (Lambda):");
            foreach (var p in orderByproductBothQueryLambda)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();


            //h. Demonstrate join, select products only
            var productCategoryJoin = from p in Products
                                      join c in Categories
                                      on p.CategoryId equals c.CategoryId
                                      select p;
            var productCategoryJoinLambda = Products.Join(Categories, p => p.CategoryId, c => c.CategoryId, (p, c) => p);

            Console.WriteLine("Join Query [h. Select Products only] :");
            foreach (var p in productCategoryJoin)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();


            Console.WriteLine("Join Query [h. Select Products only] (Lambda):");
            foreach (var p in productCategoryJoinLambda)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();


            //i. Demonstrate join , select categories only
            var CategoryProductJoin = from p in Products
                                      join c in Categories
                                      on p.CategoryId equals c.CategoryId
                                      select c;
            var CategoryProductJoinLambda = Products.Join(Categories, p => p.CategoryId, c => c.CategoryId, (p,c) => c);

            Console.WriteLine("Join Query [i. select categories only]:");
            foreach (var c in CategoryProductJoin)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine();


            Console.WriteLine("Join Query [i. select categories only](Lambda):");
            foreach (var c in CategoryProductJoinLambda)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine();

            //k. Demonstrate join , few properties of both
            var selectedPropertiesJoin = from p in Products
                                         join c in Categories
                                         on p.CategoryId equals c.CategoryId
                                         select new { p.ProductId, p.ProductName, c.CategoryName };
            var selectedPropertiesJoinLambda = Products.Join(Categories, p => p.CategoryId, c => c.CategoryId, (p, c) => new { p.ProductId, p.ProductName, c.CategoryName });

            Console.WriteLine("Join Query [k. few properties of both]:");
            foreach (var p in selectedPropertiesJoin)
                Console.WriteLine(p);
            Console.WriteLine();


            Console.WriteLine("Join Query [k. few properties of both] (Lambda):");
            foreach (var p in selectedPropertiesJoinLambda)
                Console.WriteLine(p);
            Console.WriteLine();

        }

    }
}
