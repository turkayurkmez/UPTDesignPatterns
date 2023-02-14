namespace InterfaceSegregation
{
    public class ProductRepository : IProductRepository
    {
        public void Create(Product item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public IList<Product> SearchByName(string name)
        {
            throw new NotImplementedException();
        }

        public IList<Product> SearchByPrice(double price)
        {
            throw new NotImplementedException();
        }

        public void Update(Product item)
        {
            throw new NotImplementedException();
        }
    }
}
