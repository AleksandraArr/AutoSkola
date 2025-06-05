using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public interface IEntity
    {
        string TableName { get; }
        string Values { get; }
        string UpdateText { get; }
        string WhereCondition { get; }
        string IdColumn { get; }

        void SetId(int id);

        List<IEntity> GetReaderList(SqlDataReader reader);
    }
}
