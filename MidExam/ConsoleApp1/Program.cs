namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //a. call InitiateRecords Method
            var products = InitiateRecords();
            var categories = InitiateCategories();

            //b. Select all products and display using for each
            var allProductsQuery = from p in products select p;

            var AllProductsLambda = products.Select(p => p);

            Console.WriteLine("All products:");
            foreach (var p in allProductsQuery)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine("All products (lambda):");

            foreach (var p in AllProductsLambda)
            {
                Console.WriteLine(p);
            }

            //c. Select ProductId and Product Name
            var productNamesQuery = from p in products select new { p.ProductId, p.ProductName };
            var productNamesQueryLambda = products.Select(p => new { p.ProductId, p.ProductName });

            Console.WriteLine("Product IDs and Names :");
            foreach (var item in productNamesQuery)
            {
                Console.WriteLine($"ID: {item.ProductId}, Name:{item.ProductName}");
            }

            Console.WriteLine("Product IDs and Names (Lamda) :");
            foreach (var item in productNamesQueryLambda)
            {
                Console.WriteLine($"ID: {item.ProductId}, Name:{item.ProductName}");
            }

            //d. Select Product price greater than 1000
            var expensiveproductQuery = from p in products where p.Price > 1000 select p;
            var expensiveproductQueryLambda = products.Where(p => p.Price > 1000);

            Console.WriteLine("Products greater than 1000 :");
            foreach (var p in expensiveproductQuery)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine("Products greater than 1000 (Lamda) :");
            foreach (var p in expensiveproductQueryLambda)
            {
                Console.WriteLine(p);
            }

            //e. Select Products between 500 and 1500
            var midRangeproductQuery = from p in products where p.Price >= 500 && p.Price <= 1500 select p;
            var midRangeproductQueryLambda = products.Where(p => p.Price >= 500 && p.Price <= 1500);

            Console.WriteLine("Mid range Products between 500 and 1500 :");
            foreach (var p in midRangeproductQuery)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine("Mid range Products between 500 and 1500  (Lambda):");
            foreach (var p in midRangeproductQueryLambda)
            {
                Console.WriteLine(p);
            }

            //f. Select Product by decending order
            var orderByproductDescQuery = from p in products orderby p.ProductName descending select p;
            var orderByproductDescQueryLambda = products.OrderByDescending(p => p.ProductName);

            Console.WriteLine("Products order by Product name :");
            foreach (var p in orderByproductDescQuery)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine("Products order by Product name  (Lambda):");
            foreach (var p in orderByproductDescQueryLambda)
            {
                Console.WriteLine(p);
            }

            //g. Select Product by Both order
            var orderByproductBothQuery= from p in products orderby p.Price ascending, p.ProductName descending select p;
            var orderByproductBothQueryLambda = products.OrderByDescending(p => p.Price).ThenByDescending(p=>p.ProductName);

            Console.WriteLine("Products order by Price (Ascending) and Product name (descending) :");
            foreach (var p in orderByproductBothQuery)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine("Products order by Price (Ascending) and Product name (descending) (Lambda):");
            foreach (var p in orderByproductBothQueryLambda)
            {
                Console.WriteLine(p);
            }

            //h. Demonstrate join, select products only
            var productCategoryJoin = from p in products 
                                      join c in categories
                                      on p.CategoryId equals c.CategoryId
                                      select p;
            var productCategoryJoinLambda = products.Join(categories,p=>p.CategoryId, c=> c.CategoryId, (p,c) =>p);

            Console.WriteLine("Join Query :");
            foreach (var p in productCategoryJoin)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine("Join Query (Lambda):");
            foreach (var p in productCategoryJoinLambda)
            {
                Console.WriteLine(p);
            }

            //i. Demonstrate join , select categories only
            var CategoryProductJoin = from c in categories 
                                      join p in products
                                      on c.CategoryId equals p.CategoryId
                                      select c;
            var CategoryProductJoinLambda = categories.Join(products, c => c.CategoryId, p => p.CategoryId, (c,p) => c);

            Console.WriteLine("Join Query :");
            foreach (var c in CategoryProductJoin)
            {
                Console.WriteLine(c);
            }

            Console.WriteLine("Join Query (Lambda):");
            foreach (var c in CategoryProductJoinLambda)
            {
                Console.WriteLine(c);
            }


            //k. Demonstrate join , few properties of both
            var selectedPropertiesJoin = from p in products
                                         join c in categories
                                         on p.CategoryId equals c.CategoryId
                                         select new {p.ProductId, p.ProductName, c.CategoryName};
            var selectedPropertiesJoinLambda = products.Join(categories, p => p.CategoryId, c => c.CategoryId, (p, c) => new {p.ProductId, p.ProductName, c.CategoryName});

            Console.WriteLine("Join Query :");
            foreach (var p in selectedPropertiesJoin)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine("Join Query (Lambda):");
            foreach (var p in selectedPropertiesJoinLambda)
            {
                Console.WriteLine(p);
            }
        }

        static List<Product> InitiateRecords()
        {
            return new List<Product>
            {
                new Product {ProductId=101, ProductName="Laptop", Price=56000, CategoryId=1},
                new Product {ProductId=102, ProductName="Smartphone", Price=15000, CategoryId=2},
                new Product {ProductId=103, ProductName="Tablet", Price=10000, CategoryId=1},
                new Product {ProductId=104, ProductName="Monitor", Price=500, CategoryId=3},
                new Product {ProductId=105, ProductName="Keyboard", Price=1200, CategoryId=3},
                new Product {ProductId=106, ProductName="T-Shirt", Price=600, CategoryId=4},
                new Product {ProductId=107, ProductName="Jeans", Price=1200, CategoryId=4},
                new Product {ProductId=108, ProductName="Football", Price=1200, CategoryId=5},
                new Product {ProductId=109, ProductName="Cricket Ball", Price=1200, CategoryId=5},
                new Product {ProductId=110, ProductName="Cricket helmet", Price=1200, CategoryId=5}
            };
        }

        static List<Category> InitiateCategories()
        {
            return new List<Category>
            {
                new Category {CategoryId=1, CategoryName="Electronics"},
                new Category {CategoryId=2, CategoryName="Mobile devices"},
                new Category {CategoryId=3, CategoryName="Accessories"},
                new Category {CategoryId=4, CategoryName="Clothing"},
                new Category {CategoryId=5, CategoryName="Sports"}
            };
        }
        public class Product
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public decimal Price { get; set; }
            public int CategoryId { get; set; }

            public override string ToString()
            {
                return $"ProductID: {ProductId}, Name: {ProductName}, Price: {Price}, CategoryID: {CategoryId}";
            }
        }

        public class Category
        {
            public int CategoryId { get; set; }
            public string CategoryName { get; set; }
            public override string ToString()
            {
                return $"CategoryID: {CategoryId}, CategoryName: {CategoryName}";
            }

        }
    }
}
