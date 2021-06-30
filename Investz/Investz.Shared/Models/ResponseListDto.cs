using System.Collections.Generic;

namespace Investz.Shared.Models
{
    public class ResponseListDto<TEntity> : ResponseSingleDto<TEntity>
    {
        public IList<TEntity> EntityList;
    }
}
