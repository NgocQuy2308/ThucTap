using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Net.WebSockets;
using ThucTap.Entity;
using ThucTap.Iservice;
using ThucTap.Payloads.Converters.ProductConverters;
using ThucTap.Payloads.DataResponses;
using ThucTap.Payloads.DTOs.ProductDTOs;
using ThucTap.Payloads.Requests;
using ThucTap.Payloads.Requests.OrderRequests;
using ThucTap.Payloads.Requests.ReviewRequests;
using ThucTap.Payloads.Responses;
using ThucTap.services.implements;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ThucTap.services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly ProductConverter productDTO;
        private readonly ReviewConverter reviewDTO;
        private readonly OrderConverter orderDTO;
        private readonly Responses<ReviewDTO> _responseOj;
        private readonly Responses<ViewResponses> _responseView;
        private readonly Responses<OrderDTO> _responseOrder;
        public ProductService()
        {
            productDTO = new ProductConverter();
            reviewDTO = new ReviewConverter();
            _responseOj = new Responses<ReviewDTO>();
            _responseView = new Responses<ViewResponses>();
            orderDTO = new OrderConverter();
            _responseOrder = new Responses<OrderDTO>();
        }

        public Responses<ReviewDTO> AddReview(Request_Review request)
        {
            Product_review _Review = new Product_review 
            {
                User_id = request.User_id,
                Created_at = DateTime.Now,
                Update_at = DateTime.Now,
                Content_rated = request.Content_rated,
                Content_seen = null,
                Point_evaluation = request.Point_evaluation,
                Product_id = request.Product_id,
                Status = 0,
            };
            _dbContext.Product_Reviews.Add(_Review);
            _dbContext.SaveChanges();
            return _responseOj.ResponseSuccess("Cảm ơn đánh giá của bạn", reviewDTO.EntityToDTO(_Review));
        }

        public Responses<TypeDTO> AddType(Request_AddType Request)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ProductDTO> GetAll()
        {
            var result = _dbContext.Products.Select(x=>productDTO.EntityToDTO(x))
                                            .AsQueryable();
            return result;
        }

        public IQueryable<ProductDTO> GetMore(int id)
        {
            //var query = _dbContext.Products.FirstOrDefault(x=>x.Product_id == id);
            //var idProduct = query.Product_type_id;
            //var query1 = _dbContext.Products.Where(x => x.Product_type_id == idProduct)
            //                                .Select(x=>productDTO.EntityToDTO(x));
            //var topView = _dbContext.Products.OrderByDescending(x => x.Number_of_view)
            //                                 .Select(x => productDTO.EntityToDTO(x))
            //                                 .Take(5);
            //var result = query1.Union(topView).AsQueryable();
            //return result;
            var sanPham = _dbContext.Products.SingleOrDefault(x => x.Product_id == id);
            var query = _dbContext.Products.Include(x => x.Product_Type)
                                           .Where(x => x.Product_type_id == sanPham.Product_type_id)
                                           .OrderByDescending(x => x.Number_of_view)
                                           .Select(x => productDTO.EntityToDTO(x));
            return query;
        }

        public IQueryable<OrderDTO> GetOrders()
        {
            var result = _dbContext.Orders.Select(x => orderDTO.EntityToDTO(x));
            return result;
        }

        public IQueryable<ReviewDTO> GetReviews(int id)
        {
            var result = _dbContext.Product_Reviews.Where(x => x.Product_id == id)
                                                   .Select(x => reviewDTO.EntityToDTO(x))
                                                   .AsQueryable();
            return result;
        }

        public Responses<ViewResponses> GetViews(int id_Product)
        {

            var product = _dbContext.Products.SingleOrDefault(x => x.Product_id == id_Product);
            var order = _dbContext.Order_Details.Count(x => x.Product_id == product.Product_id);
            ViewResponses result = new ViewResponses 
            {
                Number_of_buy = order,
                Number_of_view = product.Number_of_view,
            };
            return _responseView.ResponseSuccess("Thành Công", result);
        }

        private List<Order_detail> details(int order_Id, List<Buy_OrderDetailRequest> request)
        {
            var order = _dbContext.Orders.FirstOrDefault(x=>x.Order_id == order_Id);
            if (order == null)
            {
                return null;
            }
            List<Order_detail> order_Details = new List<Order_detail>();
            foreach (var item in request)
            {
                Order_detail detail = new Order_detail();
                var product = _dbContext.Orders.FirstOrDefault(x => x.Order_id == order_Id);
                if (product == null)
                {
                    throw new Exception("Hóa Đơn này không tồn tại");
                }
                detail.Order_id = order_Id;
                detail.Update_at = DateTime.Now;
                detail.Created_at = DateTime.Now;
                detail.Quantity = item.Quantity;
                detail.Product_id = item.Product_id;
                var priceProduct = _dbContext.Products.FirstOrDefault(x=>x.Product_id == item.Product_id);
                detail.Price_total = priceProduct.Price * item.Quantity;
                order_Details.Add(detail);
            }
            _dbContext.Order_Details.AddRange(order_Details);
            _dbContext.SaveChanges();
            return order_Details;
        } 

        public Responses<OrderDTO> NewOrder(Buy_OrderRequest request)
        {
            var khachHang = _dbContext.Users.FirstOrDefault(x => x.User_id == request.User_Id);
            if (khachHang == null)
            {
                return _responseOrder.ResponseError(StatusCodes.Status404NotFound, "Không tìm thấy khách hàng", null);
            }
            Order order = new Order();
            order.User_id = request.User_Id;
            if (request.Payment_Id == 4)
            {
                order.Order_status_id = 4;
            }
            order.Order_status_id = 3;
            order.Address = null;
            order.Email = null;
            order.Original_price = 0;
            order.Actual_price = 0;
            order.Full_name = (request.Name_Customer == null) ? khachHang.User_name : request.Name_Customer;
            order.Phone = null;
            order.Payment_id = request.Payment_Id;
            order.Update_at = DateTime.Now;
            order.Created_at = DateTime.Now;
            order.Details = null;
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
            order.Details = details(order.Order_id, request.detailRequests);
            _dbContext.Update(order);
            _dbContext.SaveChanges();
            double actual_Price = 0;
            order.Details.ToList().ForEach(x =>
            {
                actual_Price += x.Price_total;
            });
            order.Actual_price = actual_Price;
            order.Original_price = actual_Price;
            _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();
            return _responseOrder.ResponseSuccess("Thêm hóa đơn thành công", orderDTO.EntityToDTO(order));
        }
    }
}
