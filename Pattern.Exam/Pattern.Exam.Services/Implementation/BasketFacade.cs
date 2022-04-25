using Pattern.Exam.Domain;
using Pattern.Exam.Services.Interfaces;

namespace Pattern.Exam.Services.Implementation
{
    public class BasketFacade : IBasketFacade
    {
        private readonly IAccountService _accountService;
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;

        public BasketFacade(IAccountService accountService, IProductService productService, IBasketService basketService)
        {
            _accountService = accountService;
            _productService = productService;
            _basketService = basketService;
        }

        public async Task<Basket> CreateAsync(Guid accountId)
        {
            var account = await _accountService.GetAsync(accountId);
            if (account == null)
            {
                throw new Exception(nameof(accountId));
            }

            var basket = new Basket(account);

            await _basketService.SaveAsync(basket);

            return basket;
        }

        public async Task AddAsync(Guid accountId, Guid productId)
        {
            var basket = await _basketService.GetAsync(accountId);
            if (basket == null)
            {
                basket = await CreateAsync(accountId);
            }

            var product = await _productService.GetAsync(productId);
            if (product == null)
            {
                throw new Exception(nameof(productId));
            }

            basket.Add(product);

            await _basketService.SaveAsync(basket);
        }

        public async Task RemoveAsync(Guid accountId, Guid productId)
        {
            var basket = await _basketService.GetAsync(accountId);
            if (basket == null)
            {
                throw new Exception(nameof(accountId));
            }

            basket.Remove(productId);

            await _basketService.SaveAsync(basket);
        }

        public async Task<Basket> GetAsync(Guid accountId)
        {
            return await _basketService.GetAsync(accountId);
        }
    }
}
