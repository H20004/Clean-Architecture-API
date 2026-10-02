using CleanStore.Application.Common.Interfaces;
using CleanStore.Application.Features.Products.Commands;
using CleanStore.Domain.Entities;
using MediatR;

namespace CleanStore.Application.Features.Products.Handlers;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
{
    private readonly IRepository<Product> _repository;

    public CreateProductCommandHandler(IRepository<Product> repository)
    {
        _repository = repository;
    }

    public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            CategoryId = request.CategoryId
        };

        await _repository.AddAsync(product);

        return product;
    }
}