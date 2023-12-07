using Azure;
using ThucTap.Payloads.DataResponses;
using ThucTap.Payloads.DTOs.ProductDTOs;
using ThucTap.Payloads.Requests;
using ThucTap.Payloads.Requests.OrderRequests;
using ThucTap.Payloads.Requests.ReviewRequests;
using ThucTap.Payloads.Responses;

namespace ThucTap.Iservice
{
    public interface IProductService
    {
        IQueryable<ProductDTO> GetAll();
        IQueryable<ReviewDTO> GetReviews(int id);
        IQueryable<ProductDTO> GetMore(int id);
        Responses<TypeDTO> AddType(Request_AddType Request);
        Responses<ViewResponses> GetViews(int id_Product);
        Responses<ReviewDTO> AddReview(Request_Review request);
        IQueryable<OrderDTO> GetOrders();
        Responses<OrderDTO> NewOrder(Buy_OrderRequest request);
    }
}
