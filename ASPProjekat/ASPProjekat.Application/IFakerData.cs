using System;
using System.Collections.Generic;
using System.Text;

namespace ASPProjekat.Application
{
    public interface IFakerData
    {
        void AddArticles();
        void AddOrders();
        void AddUsers();
        void AddCategories();
        void AddPrices();
        void AddOrderLines();
        void AddCart();
        void AddUseCases();
    }
}
