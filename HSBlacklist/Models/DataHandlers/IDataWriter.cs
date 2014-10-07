using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSBlacklist.Models.DataHandlers
{
    public interface IDataWriter<T>
    {
        T WriteData(T data);
    }

    public class NullDataWriter<T> : IDataWriter<T>
    {
        public T WriteData(T data)
        {
            return default(T);
        }
    }

}
