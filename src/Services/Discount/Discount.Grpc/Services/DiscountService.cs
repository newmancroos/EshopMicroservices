using Discount.Grpc.Data;
using Discount.Grpc.Models;
using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Services
{
    public class DiscountService(DiscountContext dbContext, ILogger<DiscountService> logger) : DiscountProtoService.DiscountProtoServiceBase
    {
        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            
            var coupon = await dbContext
                .Coupones.FirstOrDefaultAsync(x => x.ProductName == request.ProductName);

            if (coupon == null) 
            {
                coupon = new Coupon { ProductName = "No Discount", Amount = 0, Description = "No Discount Description" };
            }

            logger.LogInformation("Discount is retrived for productName : {productName}", coupon.ProductName);
            var couponModel = coupon.Adapt<CouponModel>();

            return couponModel;
        }

        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var coupon = request.Coupon.Adapt<Coupon>();
            if (coupon == null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid Request Object"));
            }

            dbContext.Coupones.Add(coupon);
            await dbContext.SaveChangesAsync();

            logger.LogInformation("Discount is successfully created. Product Name : {ProductName}", coupon.ProductName);
            var response = coupon.Adapt<CouponModel>();
            return response;
        }

        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var coupon = request.Coupon.Adapt<Coupon>();
            if (coupon == null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid Request Object"));
            }

            dbContext.Coupones.Update(coupon);
            await dbContext.SaveChangesAsync();

            logger.LogInformation("Discount is successfully updated. Product Name : {ProductName}", coupon.ProductName);
            var response = coupon.Adapt<CouponModel>();
            return response;
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var coupon =await dbContext.Coupones.FirstOrDefaultAsync(x => x.ProductName == request.ProductName);
            if (coupon == null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid Request Object"));
            }

            dbContext.Remove(coupon);
            await dbContext.SaveChangesAsync();
            logger.LogInformation("Discount is successfully deleted. Product Name : {ProductName}", coupon.ProductName);
            return new DeleteDiscountResponse { Success=true};
        }
    }
}
