using System.Collections.Generic;

namespace OrderProcessor.Services
{
    public interface IOrderProcessingService
    {
        List<string> ProcessOrder(ProductTypes productType);
    }
}