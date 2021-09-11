using OrderProcessor.ProductProviders;
using System.Collections.Generic;

namespace OrderProcessor.Services
{
    public class OrderProcessingService : IOrderProcessingService
    {
        private readonly ProductProviderFactory _productProviderFactory;

        public OrderProcessingService()
        {
            _productProviderFactory = new ProductProviderFactory();
        }

        public (List<string> Tasks, string Name) ProcessOrder(ProductTypes productType, string productName = null)
        {
            IProductProvider provider = _productProviderFactory.GetProviderByProductType(productType.ToString());
            return provider.Execute(productName);
        }
    }
}