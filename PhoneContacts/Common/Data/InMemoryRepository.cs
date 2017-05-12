using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneContacts.Common.Data
{
    public class InMemoryRepository<TData> : IInMemoryRepository<TData>
    {
        private List<TData> _items;

        public InMemoryRepository()
        {
            _items = new List<TData>();
        }

        public void Add(TData data)
        {
            _items.Add(data);
        }

        public IEnumerable<TData> Get(Func<TData, bool> predicate = null)
        {
            return predicate == null ? _items : _items.Where(predicate);
        }
    }
}
