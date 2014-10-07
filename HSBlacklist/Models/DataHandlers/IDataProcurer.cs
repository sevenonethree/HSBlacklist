using System;
using System.Collections.Generic;

namespace HSBlacklist.Models.DataHandlers
{
    public interface IDataProcurer<T>
    {
        IEnumerable<T> GetData();
        T Find(Func<T,bool> condition);
        IEnumerable<T> Search(Func<T, bool> condition);
    }

    public class NullDataProcurer<T> : IDataProcurer<T>
    {
        public IEnumerable<T> GetData()
        {
            return null;
        }

        public T Find(Func<T, bool> condition)
        {
            return default(T);
        }


        public IEnumerable<T> Search(Func<T, bool> condition)
        {
            return null;
        }
    }
}
