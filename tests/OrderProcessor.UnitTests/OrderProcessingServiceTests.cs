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
        public void ProcessOrder_WhenPhysicalProduct_GeneratesPackingSlipForShipping()
        {
            var tasks = _orderProcessingService.ProcessOrder(ProductTypes.PhysicalProduct);

            Assert.Single(tasks);
            Assert.Equal(OPAConstants.GeneratedAPackingSlipForShipping, tasks[0]);
        }

        [Fact]
        public void ProcessOrder_WhenBook_CreateDuplicateSlipForRoyalDept()
        {
            var tasks = _orderProcessingService.ProcessOrder(ProductTypes.Book);

            Assert.Single(tasks);
            Assert.Equal(OPAConstants.CreatedADuplicatePackingSlipForTheRoyaltyDepartment, tasks[0]);
        }

        [Fact]
        public void ProcessOrder_WhenMembershipActivated_ActivateAndEmail()
        {
            var tasks = _orderProcessingService.ProcessOrder(ProductTypes.Membership);

            Assert.Equal(2, tasks.Count);
            Assert.Equal(OPAConstants.ActivatedMembership, tasks[0]);
            Assert.Equal(OPAConstants.MembershipEmailSent, tasks[1]);
        }

        [Fact]
        public void ProcessOrder_WhenMembershipUpgraded_UpgradeAndEmail()
        {
            var tasks = _orderProcessingService.ProcessOrder(ProductTypes.Upgrade);

            Assert.Equal(2, tasks.Count);
            Assert.Equal(OPAConstants.MembershipUpgraded, tasks[0]);
            Assert.Equal(OPAConstants.MembershipUpgradeEmailSent, tasks[1]);
        }
    }
}