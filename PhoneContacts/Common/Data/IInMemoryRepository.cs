using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneContacts.Common.Data
{
    public interface IInMemoryRepository<TData>
    {
        IEnumerable<TData> Get(Func<TData, bool> predicate = null);
        void Add(TData data);
    }
}
