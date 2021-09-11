using System;
using System.Collections.Generic;

namespace OrderProcessor.Services
{
    public class OrderProcessingService : IOrderProcessingService
    {
        public (List<string> Tasks, string Name) ProcessOrder(ProductTypes productType, string productName)
        {
            List<string> tasks = new List<string>();

            switch (productType)
            {
                case ProductTypes.PhysicalProduct:
                    tasks.Add(OPAConstants.GeneratedAPackingSlipForShipping);
                    tasks.Add(OPAConstants.GeneratedCommissionPaymentToTheAgent);
                    break;
                case ProductTypes.Book:
                    tasks.Add(OPAConstants.CreatedADuplicatePackingSlipForTheRoyaltyDepartment);
                    tasks.Add(OPAConstants.GeneratedCommissionPaymentToTheAgent);
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
                    tasks.Add(OPAConstants.GeneratedPackingSlip);
                    if (productName.Equals(OPAConstants.LearningToSki, StringComparison.OrdinalIgnoreCase))
                    {
                        tasks.Add(OPAConstants.FreeFirstAidVideoAddedToThePackingSlip);
                    }
                    break;
                default:
                    break;
            }

            return (tasks, productName);
        }
    }
}