﻿using FluentValidation;

namespace catalog.api
{

    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
    : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is required");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
    public class createProductHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
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

            session.Store(products);
            await session.SaveChangesAsync(cancellationToken);

            return new CreateProductResult(products.Id);
        }
    }
}
