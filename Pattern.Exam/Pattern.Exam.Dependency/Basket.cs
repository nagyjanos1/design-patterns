namespace Pattern.Exam.Domain
{
    public class Basket
    {
        public Guid Id { get; set; }
        public Account Account { get; set; }
        public List<Product> AddedProducts { get; set; } = new List<Product>();

        public Basket() { }

        public Basket(Account account)
        {
            Id = Guid.NewGuid();
            Account = account;
        }

        public void Add(Product product) 
        { 
            AddedProducts.Add(product); 
        }

        public void Remove(Guid productId)
        {
            var product = AddedProducts.FirstOrDefault(p => p.Id == productId);
            if (product == null)
                throw new Exception($"Nem létező termék! ProductId: {productId}");

            AddedProducts.Remove(product);
        }

        public List<Guid> GetProductIds()
        {
            return AddedProducts.Select(p => p.Id).Distinct().ToList();
        }
    }
}
