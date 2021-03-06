using System.Collections.Generic;

namespace OrderProcessor.ProductProviders
{
    public class BookProvider : IProductProvider
    {
        public string ProductType => nameof(ProductTypes.Book);

        public (List<string> Tasks, string Name) Execute(string productName)
        {
            List<string> tasks = new()
            {
                OPAConstants.CreatedADuplicatePackingSlipForTheRoyaltyDepartment,
                OPAConstants.GeneratedCommissionPaymentToTheAgent
            };
            return (tasks, default);
        }
    }
}