using System.Collections.Generic;

namespace OrderProcessor.ProductProviders
{
    public class UpgradeMembershipProvider : IProductProvider
    {
        public string ProductType => nameof(ProductTypes.Upgrade);

        public (List<string> Tasks, string Name) Execute(string productName)
        {
            List<string> tasks = new()
            {
                OPAConstants.MembershipUpgraded,
                OPAConstants.MembershipUpgradeEmailSent
            };
            return (tasks, productName);
        }
    }
}