using System.Collections.Generic;

namespace OrderProcessor.ProductProviders
{
    public class MembershipProvider : IProductProvider
    {
        public string ProductType => nameof(ProductTypes.Membership);

        public (List<string> Tasks, string Name) Execute(string productName)
        {
            List<string> tasks = new()
            {
                OPAConstants.ActivatedMembership,
                OPAConstants.MembershipEmailSent
            };
            return (tasks, productName);
        }
    }
}