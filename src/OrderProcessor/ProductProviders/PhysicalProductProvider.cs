using System.Collections.Generic;

namespace OrderProcessor.ProductProviders
{
    public class PhysicalProductProvider : IProductProvider
    {
        public string ProductType => nameof(ProductTypes.PhysicalProduct);

        public (List<string> Tasks, string Name) Execute(string productName)
        {
            List<string> tasks = new()
            {
                OPAConstants.GeneratedAPackingSlipForShipping,
                OPAConstants.GeneratedCommissionPaymentToTheAgent
            };
            return (tasks, productName);
        }
    }
}