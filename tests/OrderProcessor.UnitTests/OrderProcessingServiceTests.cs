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
        public void ProcessOrder_WhenPhysicalProduct_GeneratesPackingSlipForShippingAndGeneratesCommission()
        {
            var product = _orderProcessingService.ProcessOrder(ProductTypes.PhysicalProduct);
            var tasks = product.Tasks;

            Assert.Equal(2, tasks.Count);
            Assert.Equal(OPAConstants.GeneratedAPackingSlipForShipping, tasks[0]);
            Assert.Equal(OPAConstants.GeneratedCommissionPaymentToTheAgent, tasks[1]);
        }

        [Fact]
        public void ProcessOrder_WhenBook_CreateDuplicateSlipForRoyalDeptAndGeneratesCommission()
        {
            var product = _orderProcessingService.ProcessOrder(ProductTypes.Book);
            var tasks = product.Tasks;

            Assert.Equal(2, tasks.Count);
            Assert.Equal(OPAConstants.CreatedADuplicatePackingSlipForTheRoyaltyDepartment, tasks[0]);
            Assert.Equal(OPAConstants.GeneratedCommissionPaymentToTheAgent, tasks[1]);
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
            string videoName = "General";

            var product = _orderProcessingService.ProcessOrder(ProductTypes.Video, videoName);
            var tasks = product.Tasks;

            Assert.Single(tasks);
            Assert.Equal(OPAConstants.GeneratedPackingSlip, tasks[0]);
        }

        [Theory]
        [InlineData(OPAConstants.LearningToSki)]
        [InlineData("learning to ski")]
        public void ProcessOrder_WhenVideoLearningToSki_AddFreeVideo(string videoName)
        {
            var product = _orderProcessingService.ProcessOrder(ProductTypes.Video, videoName);
            var tasks = product.Tasks;

            Assert.Equal(2, tasks.Count);
            Assert.Equal(product.Name, OPAConstants.LearningToSki, ignoreCase: true);
            Assert.Equal(OPAConstants.GeneratedPackingSlip, tasks[0]);
            Assert.Equal(OPAConstants.FreeFirstAidVideoAddedToThePackingSlip, tasks[1]);
        }
    }
}