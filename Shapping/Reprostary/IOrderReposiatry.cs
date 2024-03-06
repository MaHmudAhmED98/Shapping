﻿using Shapping.Model;

namespace Shapping.Reprostary
{
    public interface IOrderReposiatry
    {
        public bool AddOrder(Order order);
        public bool RemoveOrder(Order order);
        public bool UpdateOrder(Order order);
        Order? GetOrderById(int orderId);
        public  Task<double> GetCostByShippingTypeAsync(TypeOfDelevery shippingType);
        public bool SaveChanges();
        //report
        IEnumerable<Order> GetAll(int pageNumer, int pageSize);
        int CountAll();
        IEnumerable<Order> SearchByDateAndStatus(int pageNumer, int pageSize, DateTime fromDate, DateTime toDate, Status status);
        int CountOrdersByDateAndStatus(DateTime fromDate, DateTime toDate, Status status);
        //home
        List<int> CountOrdersForEmployeeByStatus();
        List<int> CountOrdersForMerchantByStatus(int merchantId);
        List<int> CountOrdersForRepresentativeByStatus(int representativeId);
        //show orders
        IEnumerable<Order> GetOrdersForEmployee(string searchText, int statusId, int pageNumer, int pageSize);
        IEnumerable<Order> GetOrdersForMerchant(string searchText, int merchantId, int statusId, int pageNumer, int pageSize);
        IEnumerable<Order> GetOrdersForRepresentative(int representativeId, int statusId, int pageNubmer, int pageSize, string searchText);
        //count for pagination
        int GetCountOrdersForEmployee(int statusId, string searchText);
        int GetCountOrdersForMerchant(int merchantId, int statusId, string searchText);
        int GetCountOrdersForRepresentative(int representativeId, int statusId, string searchText);
    }
}
