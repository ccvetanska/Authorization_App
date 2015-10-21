using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Authorization_App.Model;

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