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
            ProductName = request.Coupon.ProductName,
            Description = request.Coupon.Description,
            Amount = request.Coupon.Amount
        };

        await repository.CreateDiscount(coupon);
        logger.LogInformation("Discount created for product: {ProductName}", coupon.ProductName);
        return new CouponModel
        {
            ProductName = coupon.ProductName,
            Amount = coupon.Amount,
            Description = coupon.Description
        };
    }

    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        var coupon = new Coupon
        {
            Id = request.Coupon.Id,
            ProductName = request.Coupon.ProductName,
            Description = request.Coupon.Description,
            Amount = request.Coupon.Amount
        };
        var updated = await repository.UpdateDiscount(coupon);

        if (!updated)
        {
            logger.LogError("Discount not found for product: {ProductName}", request.Coupon.ProductName);
            throw new RpcException(new Status(StatusCode.NotFound, $"Discount not found for product: {request.Coupon.ProductName}"));
        }

        logger.LogInformation("Discount updated for product: {ProductName}", request.Coupon.ProductName);
        return new CouponModel
        {
            ProductName = coupon.ProductName,
            Amount = coupon.Amount,
            Description = coupon.Description
        };
    }

    public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        var deleted = await repository.DeleteDiscount(request.ProductName);
        var response = new DeleteDiscountResponse
        {
            Success = deleted
        };

        return response;
    }
}