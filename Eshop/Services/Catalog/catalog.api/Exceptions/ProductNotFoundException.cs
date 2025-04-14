using BuildingBlocks.Exceptions;

namespace catalog.api.Exceptions;

public class ProductNotFoundException : NotFoundException
{
    public ProductNotFoundException(Guid Id) : base("Product", Id)
    {
    }
}