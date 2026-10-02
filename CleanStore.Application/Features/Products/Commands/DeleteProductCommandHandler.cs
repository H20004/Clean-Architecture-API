using CleanStore.Application.Common.Interfaces;
using CleanStore.Application.Features.Products.Commands;
using CleanStore.Domain.Entities;
using MediatR;

namespace CleanStore.Application.Features.Products.Commands;

public class DeleteProductCommandHandler
    : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IRepository<Product> _repository;

    public DeleteProductCommandHandler(IRepository<Product> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        DeleteProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id);

        if (product is null)
        {
            return false;
        }

        await _repository.DeleteAsync(product);

        return true;
    }
}