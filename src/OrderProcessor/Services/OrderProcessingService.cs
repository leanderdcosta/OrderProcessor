using OrderProcessor.ProductProviders;
using System;
using System.Collections.Generic;

namespace OrderProcessor.Services
{
    public class OrderProcessingService : IOrderProcessingService
    {
        public (List<string> Tasks, string Name) ProcessOrder(ProductTypes productType, string productName)
        {
            List<string> tasks = new List<string>();
            IProductProvider provider = null;

            switch (productType)
            {
                case ProductTypes.PhysicalProduct:
                    provider = new PhysicalProductProvider();
                    return provider.Execute(productName);
                case ProductTypes.Book:
                    provider = new BookProvider();
                    return provider.Execute(productName);
                case ProductTypes.Membership:
                    provider = new MembershipProvider();
                    return provider.Execute(productName);
                case ProductTypes.Upgrade:
                    provider = new UpgradeMembershipProvider();
                    return provider.Execute(productName);
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