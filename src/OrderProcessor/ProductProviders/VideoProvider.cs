using System;
using System.Collections.Generic;

namespace OrderProcessor.ProductProviders
{
    public class VideoProvider : IProductProvider
    {
        public (List<string> Tasks, string Name) Execute(string productName)
        {
            List<string> task = new List<string>();

            task.Add(OPAConstants.GeneratedPackingSlip);
            if (productName.Equals(OPAConstants.LearningToSki, StringComparison.OrdinalIgnoreCase))
            {
                task.Add(OPAConstants.FreeFirstAidVideoAddedToThePackingSlip);
            }
            return (task, productName);
        }
    }
}