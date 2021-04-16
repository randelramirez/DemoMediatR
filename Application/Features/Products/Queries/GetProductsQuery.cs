using System.Collections;
using System.Collections.Generic;
using MediatR;

namespace Application.Features.Products.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<ProductDto>>
    {
    }
}