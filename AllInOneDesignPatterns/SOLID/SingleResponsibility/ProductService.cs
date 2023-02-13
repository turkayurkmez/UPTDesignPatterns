namespace SingleResponsibility
{
    public class ProductService
    {
        public int AddProduct(Product product)
        {
            var connectionString = "Data Source=(localdb)\\Mssqllocaldb;Initial Catalog=Northwind;Integrated Security=True";

            var commandText = "INSERT into Products (ProductName, UnitPrice) values (@name,@price)";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@name", product.Name },
                { "@price", product.Price }
            };
            var affectedRows = new DbHelper(connectionString).Execute(commandText, parameters);
            return affectedRows;

        }
    }
}
