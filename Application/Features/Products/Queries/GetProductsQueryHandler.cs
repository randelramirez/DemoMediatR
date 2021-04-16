using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.Products.Queries
{
    public class GetProductsQueryHandler :  IRequestHandler<GetProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly IProductsService service;

        public GetProductsQueryHandler(IProductsService service) => this.service = service;

        public async Task<IEnumerable<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await this.service.GetAllAsync();
            return products.Select(p => new ProductDto() {Id = p.Id, Name = p.Name, Price = p.Price})
                .OrderBy(p => p.Name);
        }
    }
}