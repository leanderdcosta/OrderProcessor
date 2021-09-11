
using System.Collections.Generic;

namespace OrderProcessor.Services
{
    public class OrderProcessingService : IOrderProcessingService
    {
        public List<string> ProcessOrder(ProductTypes productType)
        {
            List<string> tasks = new List<string>();

            switch (productType)
            {
                case ProductTypes.PhysicalProduct:
                    tasks.Add(OPAConstants.GeneratedAPackingSlipForShipping);
                    break;
                case ProductTypes.Book:
                    tasks.Add(OPAConstants.CreatedADuplicatePackingSlipForTheRoyaltyDepartment);
                    break;
                case ProductTypes.Membership:
                    tasks.Add(OPAConstants.ActivatedMembership);
                    tasks.Add(OPAConstants.MembershipEmailSent);
                    break;
                case ProductTypes.Upgrade:
                    tasks.Add(OPAConstants.MembershipUpgraded);
                    tasks.Add(OPAConstants.MembershipUpgradeEmailSent);
                    break;
                case ProductTypes.Video:
                    break;
                default:
                    break;
            }

            return tasks;
        }
    }
}