using CleanStore.Domain.Entities;
using MediatR;

namespace CleanStore.Application.Features.Products.Commands;

public record CreateProductCommand(
    string Name,
    string Description,
    decimal Price,
    int CategoryId
) : IRequest<Product>;