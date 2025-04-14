using catalog.api.models;

namespace catalog.api.products.getProduct
{
    public record GetProductsResponse(IEnumerable<product> Products);
    public class getpProductEndpoint :ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/products", async ( ISender mediator) =>
            {
                var query = await mediator.Send(new GetProductQuery());
                var result = query.Adapt<GetProductsResponse>();    
                return Results.Ok(result);

            })
            .WithName("GetProducts")
            .Produces<GetProductsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Products")
            .WithDescription("Get Products");
        }
    }

}
