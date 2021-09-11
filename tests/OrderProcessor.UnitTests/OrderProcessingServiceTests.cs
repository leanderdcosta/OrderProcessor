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
            var product = _orderProcessingService.ProcessOrder(ProductTypes.PhysicalProduct);
            var tasks = product.Tasks;

            Assert.Single(tasks);
            Assert.Equal(OPAConstants.GeneratedAPackingSlipForShipping, tasks[0]);
        }

        [Fact]
        public void ProcessOrder_WhenBook_CreateDuplicateSlipForRoyalDept()
        {
            var product = _orderProcessingService.ProcessOrder(ProductTypes.Book);
            var tasks = product.Tasks;

            Assert.Single(tasks);
            Assert.Equal(OPAConstants.CreatedADuplicatePackingSlipForTheRoyaltyDepartment, tasks[0]);
        }

        [Fact]
        public void ProcessOrder_WhenMembershipActivated_ActivateAndEmail()
        {
            var product = _orderProcessingService.ProcessOrder(ProductTypes.Membership);
            var tasks = product.Tasks;

            Assert.Equal(2, tasks.Count);
            Assert.Equal(OPAConstants.ActivatedMembership, tasks[0]);
            Assert.Equal(OPAConstants.MembershipEmailSent, tasks[1]);
        }

        [Fact]
        public void ProcessOrder_WhenMembershipUpgraded_UpgradeAndEmail()
        {
            var product = _orderProcessingService.ProcessOrder(ProductTypes.Upgrade);
            var tasks = product.Tasks;

            Assert.Equal(2, tasks.Count);
            Assert.Equal(OPAConstants.MembershipUpgraded, tasks[0]);
            Assert.Equal(OPAConstants.MembershipUpgradeEmailSent, tasks[1]);
        }

        [Fact]
        public void ProcessOrder_WhenVideo_GeneratePackingSlip()
        {
            var product = _orderProcessingService.ProcessOrder(ProductTypes.Video, "General");
            var tasks = product.Tasks;

            Assert.Single(tasks);
            Assert.Equal(OPAConstants.GeneratedPackingSlip, tasks[0]);
        }

        [Fact]
        public void ProcessOrder_WhenVideoLearningToSki_AddFreeVideo()
        {
            var product = _orderProcessingService.ProcessOrder(ProductTypes.Video, OPAConstants.LearningToSki);
            var tasks = product.Tasks;

            Assert.Equal(2, tasks.Count);
            Assert.Equal(product.Name, OPAConstants.LearningToSki);
            Assert.Equal(OPAConstants.GeneratedPackingSlip, tasks[0]);
            Assert.Equal(OPAConstants.FreeFirstAidVideoAddedToThePackingSlip, tasks[1]);
        }
    }
}