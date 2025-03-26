using BuildingBlocks.CQRS;
using catalog.api.models;


namespace catalog.api
{

    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
    : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);

    public class createProductHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {

        
        public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
          var products = new product
          {
              Id = Guid.NewGuid(),
              Name = request.Name,
              Category = request.Category,  
              Description = request.Description,
              ImageFile = request.ImageFile,
              Price = request.Price
          };

            return new CreateProductResult(products.Id);
        }
    }
}
