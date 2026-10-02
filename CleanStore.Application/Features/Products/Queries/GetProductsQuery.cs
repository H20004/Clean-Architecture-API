using CleanStore.Domain.Entities;
using MediatR;

namespace CleanStore.Application.Features.Products.Queries;

public record GetProductsQuery : IRequest<List<Product>>;