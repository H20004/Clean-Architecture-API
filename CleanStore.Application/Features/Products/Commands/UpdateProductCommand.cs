using MediatR;

namespace CleanStore.Application.Features.Products.Commands;

public record UpdateProductCommand(
    int Id,
    string Name,
    string Description,
    decimal Price,
    int CategoryId
) : IRequest<bool>;