using Discount.gRPC.Protos;

namespace Basket.Api.gRPCServices;

public class DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discountProtoServiceClient)
{
    public async Task<CouponModel> GetDiscount(string productName)
    {
        var discountRequest = new GetDiscountRequest { ProductName = productName };
        return await discountProtoServiceClient.GetDiscountAsync(discountRequest);
    }
}
