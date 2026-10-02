using CleanStore.Application.Features.Products.Queries;
using CleanStore.Application.Common.Interfaces;
using CleanStore.Domain.Entities;
using MediatR;

namespace CleanStore.Application.Features.Products.Queries;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<Product>>
{
    private readonly IRepository<Product> _repository;

    public GetProductsQueryHandler(IRepository<Product> repository)
    {
        _repository = repository;
    }

    public async Task<List<Product>> Handle(
        GetProductsQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}