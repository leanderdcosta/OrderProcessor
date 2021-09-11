using System.Collections.Generic;

namespace OrderProcessor.ProductProviders
{
    public interface IProductProvider
    {
        (List<string> Tasks, string Name) Execute(string productName);
    }
}