
namespace catalog.api.products.getProduct
{

    public record GetProductQuery():IQuery<getProductResult>;

    public record getProductResult(IEnumerable<product> Products);
    internal class getpProductHandler(IDocumentSession session ) : IQueryHandler<GetProductQuery, getProductResult>
    {
        public async Task<getProductResult> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            //logger.LogInformation("Getting all products");
            var products =await session.Query<product>().ToListAsync();
            return new getProductResult(products);
        }
    }
}
