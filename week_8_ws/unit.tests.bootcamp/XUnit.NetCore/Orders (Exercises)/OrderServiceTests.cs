namespace xUnit.NetCore.Orders
{
    using System;
    using ProductionCode.Orders;
    using ProductionCode.Orders.Models;
    using Xunit;

    public class OrderServiceTests
    {
        [Fact]
        public void TestOrderServiceValidOrder_ThrowsWhenAmountIsNegative()
        {
            //
            // Arrange
            //
            var order = new Order();
            order.OrderId = 123456;
            order.Amount = -1;
            order.ClientId = 200;
            order.ClientName = "Bob's FoodMart";
            order.BookedDate = new DateTime(2019, 01, 12);
            order.CreatedDate = new DateTime(2019, 01, 01);
            order.CurrencyIsoCode = "USD";
            order.Adjustments.Add(new Adjustment
                {Amount = -20, OrderId = 123456, AdjustmentId = 1, CreatedDate = new DateTime(2019, 01, 01)});

            var orderService = new OrderService();

            //
            // Act
            //
            var ex = Assert.Throws<Exception>(() => orderService.ValidateOrder(order));

            //
            // Assert
            //
            Assert.Equal("Order amount cannot be negative", ex.Message);
        }

        [Fact]
        public void TestOrderServiceValidOrder_ThrowsWhenAmountWithAdjustmentsIsNegative()
        {
            //
            // Arrange
            //
            var order = new Order();
            order.OrderId = 123456;
            order.Amount = 100;
            order.ClientId = 200;
            order.ClientName = "Bob's FoodMart";
            order.BookedDate = new DateTime(2019, 01, 12);
            order.CreatedDate = new DateTime(2019, 01, 01);
            order.CurrencyIsoCode = "USD";
            order.Adjustments.Add(new Adjustment
                {Amount = -120, OrderId = 123456, AdjustmentId = 1, CreatedDate = new DateTime(2019, 01, 01)});

            var orderService = new OrderService();

            //
            // Act
            //
            var ex = Assert.Throws<Exception>(() => orderService.ValidateOrder(order));

            //
            // Assert
            //
            Assert.Equal("Order adjustments make total amount negative", ex.Message);
        }

        [Fact]
        public void TestOrderServiceValidOrder_ThrowsWhenOrderIsDeleted()
        {
            //
            // Arrange
            //
            var order = new Order();
            order.OrderId = 123456;
            order.Amount = 100;
            order.ClientId = 200;
            order.ClientName = "Bob's FoodMart";
            order.BookedDate = new DateTime(2019, 01, 12);
            order.CreatedDate = new DateTime(2019, 01, 01);
            order.CurrencyIsoCode = "USD";
            order.Adjustments.Add(new Adjustment
                {Amount = -20, OrderId = 123456, AdjustmentId = 1, CreatedDate = new DateTime(2019, 01, 01)});
            order.IsDeleted = true;

            var orderService = new OrderService();

            //
            // Act
            //
            var ex = Assert.Throws<Exception>(() => orderService.ValidateOrder(order));

            //
            // Assert
            //
            Assert.Equal("Order has been deleted", ex.Message);
        }

    }
}
