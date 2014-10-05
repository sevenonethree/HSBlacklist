using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSBlacklist.Models.DataHandlers
{
    public interface IDataProcurer<T>
    {
        IEnumerable<T> GetData();
        T Find(Func<T,bool> predicate);
    }

    public class NullDataProcurer<T> : IDataProcurer<T>
    {
        public IEnumerable<T> GetData()
        {
            return null;
        }

        public T Find(Func<T, bool> predicate)
        {
            return default(T);
        }
    }
}
