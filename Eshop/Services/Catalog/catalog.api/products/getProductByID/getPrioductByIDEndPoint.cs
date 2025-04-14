namespace catalog.api.products.getProductByID
{
    public record getProductByIDResponce(product Product);
    public class getPrioductByIDEndPoint:ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/products/{id}", async (ISender mediator, Guid id) =>
            {
                var query = await mediator.Send(new GetProductByIDQuery(id));
                var result = query.Adapt<getProductByIDResponce>();
                return Results.Ok(result);
            })
            .Produces<getProductByIDResponce>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Product By ID")
            .WithDescription("Get Product By ID");
        }
    }
    
}
