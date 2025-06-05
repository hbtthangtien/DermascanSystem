using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DatabaseExtentions
{
    public static class SkinZoneSeedingData
    {
        public static void Seeding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SkinZone>(entity =>
            {
                List<SkinZone> list = new List<SkinZone>
                {
                    new SkinZone { Id = 1, Name = "Trán" },
                    new SkinZone { Id = 2, Name = "Má trái" },
                    new SkinZone { Id = 3, Name = "Má phải" },
                    new SkinZone { Id = 4, Name = "Cằm" },
                    new SkinZone { Id = 5, Name = "Mũi" },
                    new SkinZone { Id = 6, Name = "Vùng mắt" },
                    new SkinZone { Id = 7, Name = "Cổ" },
                    new SkinZone { Id = 8, Name = "Xương hàm" },
                    new SkinZone { Id = 9, Name = "Môi trên" },
                    new SkinZone { Id = 10, Name = "Toàn bộ mặt" }
                };
                entity.HasData(list);
            });
        }
    }

}
