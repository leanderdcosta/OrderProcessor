using OrderProcessor.Services;
using Xunit;

namespace OrderProcessor.UnitTests
{
    public class OrderProcessingServiceTests
    {
        private IOrderProcessingService _orderProcessingService;

        public OrderProcessingServiceTests()
        {
            _orderProcessingService = new OrderProcessingService();
        }

        [Fact]
        public void Test_PhysicalProduct()
        {
            _orderProcessingService.ProcessOrder();
            
            Assert.True(true);
        }
    }
}