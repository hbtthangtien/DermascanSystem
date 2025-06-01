using Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extentions
{
    public static class AuditExtension
    {
        public static T MarkCreated<T>(this T entity, string? createdBy) where T : IAuditable
        {
            var now = DateTime.Now;
            entity.CreatedAt = now;
            entity.UpdatedAt = now;
            entity.UpdatedBy = createdBy;
            return entity;
        }

        public static T MarkUpdated<T>(this T entity, string? updatedBy) where T : IAuditable
        {
            entity.UpdatedAt = DateTime.Now;
            entity.UpdatedBy = updatedBy;
            return entity;
        }
    }
}
