namespace catalog.api.products.deleteProduct
{  
    
   // public record deleteProductRequest(Guid Id);
    public record deleteProductResponse(bool IsSuccess);
    public class deleteProducEndpoint :ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("api/products/{id}",
                async (Guid Id, ISender sender) =>
                {
                   // var command = request.Adapt<deleteProductCommand>();

                    var result = await sender.Send(new deleteProductCommand(Id));

                    var response = result.Adapt<deleteProductResponse>();

                    return Results.Ok(response);
                })
                .WithName("deleteProduct")
                .Produces<deleteProductResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .ProducesProblem(StatusCodes.Status404NotFound)
                .WithSummary("Delete Product")
                .WithDescription("Delete Product");
        }
    }

}
