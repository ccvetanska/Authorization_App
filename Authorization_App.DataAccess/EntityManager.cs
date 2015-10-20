using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Authorization_App.DataAccess
{
    public class EntityManager<T> : GenericEntityManager<int, T> where T : class, IEntity
    {
        public EntityManager(DbContext ctx)
            : base(ctx)
        {
        }
    }
}