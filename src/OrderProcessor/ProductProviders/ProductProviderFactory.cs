using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace OrderProcessor.ProductProviders
{
    public class ProductProviderFactory
    {
        private readonly IReadOnlyDictionary<string, IProductProvider> _productProviders;

        public ProductProviderFactory()
        {
            var productProviderType = typeof(IProductProvider);
            _productProviders = productProviderType.Assembly.ExportedTypes
                .Where(x => productProviderType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(x => Activator.CreateInstance(x))
                .Cast<IProductProvider>()
                .ToImmutableDictionary(x => x.ProductType, x => x);
        }

        public IProductProvider GetProviderByProductType(string productType)
        {
            return _productProviders.GetValueOrDefault(productType);
        }
    }
}