using catalog.api.models;

namespace catalog.api.products.GetProductByCategory
{
    public record GetProductByCategoryQuery(string Category) : IQuery<GetProductByCategoryResult>;
    public record GetProductByCategoryResult(IEnumerable<product> Products);
    public class GetProductByCategoryQueryHandler(IDocumentSession session) : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery request, CancellationToken cancellationToken)
        {
            var products =await session.Query<product>().Where(x => x.Category.Contains(request.Category)).ToListAsync();

            return new GetProductByCategoryResult(products);
        }
    }
}
