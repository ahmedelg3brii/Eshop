﻿namespace catalog.api.products.createProduct
{
    public record CreateProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price);

    public record CreateProductResponse(Guid Id);

    public class CreateProductEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/api/products", async (CreateProductRequest request, ISender mediator) =>
            {
                var command = request.Adapt<CreateProductCommand>();
                var result = await mediator.Send(command);
                var response = result.Adapt<CreateProductResponse>();
                 return Results.Created($"/products/{response.Id}", response);

            
            })
             .WithName("CreateProduct")
             .Produces<CreateProductResponse>(StatusCodes.Status201Created)//
             .ProducesProblem(StatusCodes.Status400BadRequest)
             .WithSummary("Create Product")
             .WithDescription("Create Product");
        }
    }

}
