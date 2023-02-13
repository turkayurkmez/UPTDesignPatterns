namespace InterfaceSegregation
{
    public interface IProductRepository : IRepository<Product>
    {
        IList<Product> SearchByName(string name);
        IList<Product> SearchByPrice(double price);
    }
}
