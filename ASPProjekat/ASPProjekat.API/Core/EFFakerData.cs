using ASPProjekat.Application;
using ASPProjekat.Domain;
using ASPProjekat.EFDataAccess;
using Bogus;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProjekat.API.Core
{
    public class EFFakerData : IFakerData
    {
        private readonly ASPProjekatContext _context;

        public EFFakerData(ASPProjekatContext context)
        {
            _context = context;
        }

        public void AddUsers()
        {
            var quantity = 20;
            var doubleQuantity = quantity * 2;
            var usersFaker = new Faker<User>();

            usersFaker.RuleFor(user => user.FirstName, f => f.Name.FirstName());
            usersFaker.RuleFor(user => user.LastName, f => f.Name.LastName());
            usersFaker.RuleFor(user => user.Username, f => f.Internet.UserName());
            usersFaker.RuleFor(user => user.Email, f => f.Internet.Email());
            usersFaker.RuleFor(user => user.Password, f => f.Internet.Password());

            usersFaker.RuleFor(user => user.IsAdmin, f => f.Random.Bool());
            usersFaker.RuleFor(user => user.CreatedAt, f => f.Date.Recent());
            usersFaker.RuleFor(user => user.IsDeleted, f => false);
            usersFaker.RuleFor(user => user.DeletedAt, f => null);
            usersFaker.RuleFor(user => user.ModifiedAt, f => null);
            usersFaker.RuleFor(user => user.IsActive, f => true);


            var users = usersFaker.Generate(doubleQuantity);

            while (users.DistinctBy(u => u.Username).ToList().Count < 20 && users.DistinctBy(u => u.Email).ToList().Count < 20)
            {
                users = usersFaker.Generate(doubleQuantity);
            }

            var uniqueUsers = users.DistinctBy(u => u.Username).ToList().GetRange(0, quantity);

            _context.Users.AddRange(uniqueUsers);
            _context.SaveChanges();
        }

        public void AddCategories()
        {
            var quantity = 15;
            var doubleQuantity = quantity * 2;
            var categoriesFaker = new Faker<Category>();

            categoriesFaker.RuleFor(category => category.Name, f => f.Commerce.ProductAdjective());
            categoriesFaker.RuleFor(user => user.CreatedAt, f => f.Date.Recent());
            categoriesFaker.RuleFor(user => user.IsDeleted, f => false);
            categoriesFaker.RuleFor(user => user.DeletedAt, f => null);
            categoriesFaker.RuleFor(user => user.ModifiedAt, f => null);
            categoriesFaker.RuleFor(user => user.IsActive, f => true);


            var categories = categoriesFaker.Generate(doubleQuantity);

            var uniqueCategories = categories.DistinctBy(category => category.Name)
                                                    .ToList();

            _context.Categories.AddRange(uniqueCategories);
            _context.SaveChanges();
        }

        public void AddArticles()
        {
            var quantity = 20;
            var doubleQuantity = quantity * 2;
            var articlesFaker = new Faker<Article>();

            articlesFaker.RuleFor(user => user.Name, f => f.Commerce.ProductName());

            var cIds = _context.Categories.Select(u => u.Id).ToList();
            articlesFaker.RuleFor(user => user.CategoryId, f => f.PickRandom(cIds));

            articlesFaker.RuleFor(user => user.OnStock, f => f.Random.Int(0,1000));
            articlesFaker.RuleFor(user => user.OnSale, f => f.Random.Bool());
            articlesFaker.RuleFor(user => user.Picture, f => null);

            articlesFaker.RuleFor(user => user.CreatedAt, f => f.Date.Recent());
            articlesFaker.RuleFor(user => user.IsDeleted, f => false);
            articlesFaker.RuleFor(user => user.DeletedAt, f => null);
            articlesFaker.RuleFor(user => user.ModifiedAt, f => null);
            articlesFaker.RuleFor(user => user.IsActive, f => true);


            var articles = articlesFaker.Generate(doubleQuantity);

            while (articles.DistinctBy(u => u.Name).ToList().Count < 20)
            {
                articles = articlesFaker.Generate(doubleQuantity);
            }

            var uniqueArticles = articles.DistinctBy(u => u.Name).ToList().GetRange(0, quantity);

            _context.Articles.AddRange(uniqueArticles);
            _context.SaveChanges();
        }

        public void AddCart()
        {
            var quantity = 2;
            var doubleQuantity = quantity * 2;
            var cFaker = new Faker<Cart>();

            cFaker.RuleFor(cart => cart.Quantity, f => f.Random.Int(1, 3));

            var articleIds = _context.Articles.Select(article => article.Id).ToList();
            cFaker.RuleFor(cart => cart.ArticleId, f => f.PickRandom(articleIds));

            var userIds = _context.Users.Select(user => user.Id).ToList();
            cFaker.RuleFor(cart => cart.UserId, f => f.PickRandom(userIds));

            var carts = cFaker.Generate(doubleQuantity);

            while (carts.DistinctBy(c => c.UserId).ToList().Count < 2)
            {
                carts = cFaker.Generate(doubleQuantity);
            }

            var cartsAll = carts.DistinctBy(c => c.Id).ToList();

            _context.Cart.AddRange(cartsAll);
            _context.SaveChanges();
        }

        public void AddOrders()
        {
            var quantity = 10;
            var doubleQuantity = 2 * quantity;
            var ordersFaker = new Faker<Order>();

            ordersFaker.RuleFor(order => order.OrderDate, f => f.Date.Recent(5));
            ordersFaker.RuleFor(o => o.Address, f => f.Address.FullAddress());

            var orderStatus = new[] { OrderStatus.Recieved, OrderStatus.Canceled, OrderStatus.Delivered, OrderStatus.Shipped };
            ordersFaker.RuleFor(o => o.OrderStatus, f => f.PickRandom(orderStatus));

            var userIds = _context.Users.Select(u => u.Id).ToList();
            ordersFaker.RuleFor(user => user.UserId, f => f.PickRandom(userIds));

            ordersFaker.RuleFor(user => user.CreatedAt, f => f.Date.Recent());
            ordersFaker.RuleFor(user => user.IsDeleted, f => false);
            ordersFaker.RuleFor(user => user.DeletedAt, f => null);
            ordersFaker.RuleFor(user => user.ModifiedAt, f => null);
            ordersFaker.RuleFor(user => user.IsActive, f => true);

            var orders = ordersFaker.Generate(doubleQuantity);
            _context.Orders.AddRange(orders);
            _context.SaveChanges();
        }

        public void AddOrderLines()
        {
            var quantity = 10;
            var doubleQuantity = 2 * quantity;
            var ordersFaker = new Faker<OrderLine>();

            ordersFaker.RuleFor(o => o.Name, f => f.Name.Random.Words());
            ordersFaker.RuleFor(o => o.Quantity, f => f.Random.Int(3,20));
            ordersFaker.RuleFor(o => o.Price, f => f.Random.Decimal());

            var userIds = _context.Articles.Select(a => a.Id).ToList();
            ordersFaker.RuleFor(o => o.ArticleId, f => f.PickRandom(userIds));

            var orderIds = _context.Orders.Select(o => o.Id).ToList();
            ordersFaker.RuleFor(o => o.OrderId, f => f.PickRandom(orderIds));


            var orders = ordersFaker.Generate(doubleQuantity);
            _context.OrderLines.AddRange(orders);
            _context.SaveChanges();
        }

        public void AddPrices()
        {
            var quantity = _context.Articles.Count();
            var doubleQuantity = 2 * quantity;
            var pricesFaker = new Faker<Price>();

            pricesFaker.RuleFor(o => o.OldPrice, f => f.Random.Decimal(100, 1000));
            pricesFaker.RuleFor(o => o.NewPrice, f => f.Random.Decimal(100, 1000));

            var articleIds = _context.Articles.Select(u => u.Id).ToList();
            pricesFaker.RuleFor(user => user.ArticleId, f => f.PickRandom(articleIds));

            var prices = pricesFaker.Generate(doubleQuantity);
            _context.Prices.AddRange(prices);
            _context.SaveChanges();
        }

        public void AddUseCases()
        { 

            var quantity = _context.Articles.Count();
            var doubleQuantity = 2 * quantity;
            var uFaker = new Faker<UserUseCase>();

            var users = _context.Users.ToList();
            var userAdminIds = _context.Users.Where(u => u.IsAdmin == true).Select(u => u.Id).ToList();
            var userIds = _context.Users.Where(u => u.IsAdmin == false).Select(u => u.Id).ToList();

            var count = userAdminIds.Count * 18 + userIds.Count * 10;


            uFaker.RuleFor(o => o.UserId, f => f.PickRandom(users.Select(x => x.Id)));
            uFaker.RuleFor(o => o.UseCaseId, f => f.Random.Int(1,18));

            uFaker.RuleFor(user => user.CreatedAt, f => f.Date.Recent());
            uFaker.RuleFor(user => user.IsDeleted, f => false);
            uFaker.RuleFor(user => user.DeletedAt, f => null);
            uFaker.RuleFor(user => user.ModifiedAt, f => null);
            uFaker.RuleFor(user => user.IsActive, f => true);

            var userUseCases = uFaker.Generate(count);



            _context.UserUseCase.AddRange(userUseCases);
            _context.SaveChanges();
        }


    }
}
