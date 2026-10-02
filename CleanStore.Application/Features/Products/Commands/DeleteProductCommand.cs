using MediatR;

namespace CleanStore.Application.Features.Products.Commands;

public record DeleteProductCommand(int Id) : IRequest<bool>;