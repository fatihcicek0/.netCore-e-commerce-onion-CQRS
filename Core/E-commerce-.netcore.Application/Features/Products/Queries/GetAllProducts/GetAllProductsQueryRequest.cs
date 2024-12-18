using MediatR;


namespace E_commerce_.netcore.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryRequest:IRequest<IList<GetAllProductsQueryResponse>>
    {

    }
}
