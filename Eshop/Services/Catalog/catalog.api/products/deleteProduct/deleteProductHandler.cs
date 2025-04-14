using catalog.api.Exceptions;

namespace catalog.api.products.deleteProduct
{

    public record deleteProductCommand(Guid Id):ICommand<deleteProductResult>;
    public record deleteProductResult(bool IsSuccess);

    internal class deleteProductHandler (IDocumentSession session): ICommandHandler<deleteProductCommand, deleteProductResult>
    {
        public async Task<deleteProductResult> Handle(deleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<product>(request.Id, cancellationToken);

            if (product is null)
            {
                throw new ProductNotFoundException(request.Id);
            }

            session.Delete(product);
            await session.SaveChangesAsync(cancellationToken);

            return new deleteProductResult(true);
        }
    }

}
