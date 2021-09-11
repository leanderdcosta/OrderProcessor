using System.Collections.Generic;

namespace OrderProcessor.Services
{
    public interface IOrderProcessingService
    {
        (List<string> Tasks, string Name) ProcessOrder(ProductTypes productType, string productName = null);
    }
}