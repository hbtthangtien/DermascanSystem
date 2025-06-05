using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DatabaseExtentions
{
    public static class SubscriptionSeedingData
    {
        public static void Seeding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubscriptionPlan>(entity =>
            {
                List<SubscriptionPlan> plans = new List<SubscriptionPlan>
                {
                    new SubscriptionPlan
                    {
                        Id = 1,
                        Name = "Gói miễn phí",
                        Description = "Dùng thử phân tích da mặt trong 3 ngày, không lưu trữ kết quả, có quảng cáo.",
                        Price = 0,
                        BillingCycle =BillingCycle.OneTime,
                        GracePeriodDays = 0,
                        ResultRetentionDays = 0,
                        FreeUsageLimitPerWeek = 1
                    },
                    new SubscriptionPlan
                    {
                        Id = 2,
                        Name = "Gói cơ bản",
                        Description = "Dùng thử 15 ngày, không lưu kết quả, có quảng cáo, kèm món quà nhỏ tri ân khách hàng.",
                        Price = 19000,
                        BillingCycle = BillingCycle.OneTime,
                        GracePeriodDays = 0,
                        ResultRetentionDays = 0,
                        FreeUsageLimitPerWeek = 2
                    },
                    new SubscriptionPlan
                    {
                        Id = 3,
                        Name = "Gói Premium",
                        Description = "Phân tích da mặt trong 1 tháng, có lưu kết quả, bỏ quảng cáo, giảm giá 10% cho khách hàng lần đầu.",
                        Price = 59000,
                        BillingCycle = BillingCycle.Monthly,
                        GracePeriodDays = 3,
                        ResultRetentionDays = 30,
                        FreeUsageLimitPerWeek = 5
                    },
                    new SubscriptionPlan
                    {
                        Id = 4,
                        Name = "Gói Pro",
                        Description = "Phân tích da mặt trong 3 tháng, có lưu kết quả, nhắc nhở điểm danh, bỏ quảng cáo, giảm giá 15%, tặng quà (nước tẩy trang/sữa rửa mặt).",
                        Price = 299000,
                        BillingCycle = BillingCycle.Quarterly,
                        GracePeriodDays = 5,
                        ResultRetentionDays = 90,
                        FreeUsageLimitPerWeek = 7
                    }
                };

                entity.HasData(plans);
            });
        }
    }
}
