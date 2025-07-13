using Discount.gRPC.Protos;
using Discount.gRPC.Repositories;
using Grpc.Core;

namespace Discount.gRPC.Services;

public class DiscountService(IDiscountRepository repository, ILogger<DiscountService> logger) : DiscountProtoService.DiscountProtoServiceBase
{
    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        var coupon = await repository.GetDiscount(request.ProductName);
        if (coupon is null)
        {
            logger.LogError("Discount not found for product: {ProductName}", request.ProductName);
            throw new RpcException(new Status(StatusCode.NotFound, $"Discount not found for product: {request.ProductName}"));
        }
        logger.LogInformation("Discount retrieved for product: {ProductName}", request.ProductName);
        return new CouponModel
        {
            ProductName = coupon.ProductName,
            Amount = coupon.Amount,
            Description = coupon.Description
        };
    }

    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        var coupon = new Coupon
        {
            ProductName = request.ProductName,
            Description = request.Description,
            Amount = request.Amount
        };
    }
}
