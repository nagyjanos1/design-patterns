using Ardalis.GuardClauses;
using Pattern.Exam.Domain;
using Pattern.Exam.Domain.States;
using Pattern.Exam.Domain.Strategies;
using Pattern.Exam.Domain.Strategies.Interfaces;
using Pattern.Exam.Services.Interfaces;

namespace Pattern.Exam.Services.Implementation
{
    public class OrderFacade : IOrderFacade
    {
        private readonly IAccountService _accountService;
        private readonly IBasketService _basketService;
        private readonly IOrderService _orderService;

        public OrderFacade(
            IAccountService accountService, 
            IBasketService basketService,
            IOrderService orderService)
        {
            _accountService = accountService;
            _basketService = basketService;
            _orderService = orderService;
        }

        public async Task<Order> CreateAsync(Guid accountId)
        {
            var basket = await _basketService.GetAsync(accountId);
            Guard.Against.Null(basket);

            var account = await _accountService.GetAsync(accountId);
            Guard.Against.Null(account);

            var strategy = GetStrategy(account.State);

            var calculator = new BasketCostCaluclator(strategy);

            var order = new Order
            {
                Id = Guid.NewGuid(),
                Account = account,
                CreateDate = DateTime.UtcNow,
                Products = basket.AddedProducts,
                TotalCost = calculator.GetBasketTotalCost(basket)
            };

            await _orderService.SaveAsync(order);

            return order;
        }

        private ICustomerCost GetStrategy(AccountState state)
        {
            return state is LoyalState ? new LoyalCustomerCost() : new NormalCustomerCost();
        }
    }
}
