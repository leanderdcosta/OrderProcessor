using System.Collections.Generic;

namespace OrderProcessor.ProductProviders
{
    class UpgradeMembershipProvider : IProductProvider
    {
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