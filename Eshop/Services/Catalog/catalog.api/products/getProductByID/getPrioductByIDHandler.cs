
namespace catalog.api.products.getProductByID
{

    public record GetProductByIDQuery(Guid Id):IQuery<getProductByIDResult>;
    public record getProductByIDResult(product Product);
    public class getPrioductByIDHandler(IDocumentSession session) : IQueryHandler<GetProductByIDQuery, getProductByIDResult>
    {
        public async Task<getProductByIDResult> Handle(GetProductByIDQuery request, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<product>(request.Id);
            return new getProductByIDResult(product);
        }
    }
}
