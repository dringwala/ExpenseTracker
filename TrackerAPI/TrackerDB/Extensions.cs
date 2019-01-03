using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerDB
{
    public static class Extensions
    {
        public static void AttachAsModified<T>(this DbSet<T> dbSet, T entity, DbContext ctx) where T : class
        {
            EntityEntry<T> entityEntry = ctx.Entry(entity);
            if (entityEntry.State == EntityState.Detached)
            {
                // attach the entity
                dbSet.Attach(entity);
            }

            // transition the entity to the modified state
            entityEntry.State = EntityState.Modified;
        }
    }
}
