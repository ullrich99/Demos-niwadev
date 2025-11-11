using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NiwadevApi.Data;
using NiwadevApi.Logic;
using NiwadevApi.Models;
using Xunit;
namespace NiwADevTests
{
    public class UnitTest1
    {
        private string dbConnection = "Server=127.0.0.1;Database=niwadev;User=root;Password=";
        #region mainline test
        [Fact]
        public void BaseTest()
        {
            Assert.True(true);
        }
        #endregion
        #region input tests
        [Fact]
        public void CheckValidCustomerName()
        {
            Assert.True(InputLogic.CheckName("chevy Chase"));
        }
        [Fact]
        public void CheckInvalidCustomerNameHyphens()
        {
            Assert.False(InputLogic.CheckName("chevy-Chase"));
        }
        [Fact]
        public void CheckInvalidCustomerNameNumbers()
        {
            Assert.False(InputLogic.CheckName("chevy-C23hase"));
        }
        #endregion
        #region Order Tests
        [Fact]
        public void CheckProduct()
        {
            DbContextOptionsBuilder<NiwadevApiContext> o = new DbContextOptionsBuilder<NiwadevApiContext>().UseMySQL(dbConnection);
            NiwadevApiContext context = new NiwadevApiContext(o.Options);
            Assert.True( OrderLogic.ProductExists(context, 1));
        }
        [Fact]
        public void CheckProductDoesntExist()
        {
            DbContextOptionsBuilder<NiwadevApiContext> o = new DbContextOptionsBuilder<NiwadevApiContext>().UseMySQL(dbConnection);
            NiwadevApiContext context = new NiwadevApiContext(o.Options);
            Assert.False(OrderLogic.ProductExists(context, -1));
        }
        [Fact]
        public void CheckPriceCalculation()
        {
           
            Order newOrder = new Order() 
            {
                Consumption = 12
            };
            newOrder.Product = new Product()
            {
                PricePerKwh = 2,
                BasePrice = 10
            };
            float price = OrderLogic.CalculatePrice(newOrder);
            Assert.True( price == 12);
        }
        [Fact]
        public void CheckPriceCalculationDoesntExist() 
        {
            Order newOrder = new Order()
            {
                Consumption = 12
            };
            float price = OrderLogic.CalculatePrice(newOrder);
            Assert.False(price == 12);
        }
        #endregion
    }
}