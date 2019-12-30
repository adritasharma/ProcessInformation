using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ProcessInfo.Service.ServiceModels
{
    public class FilteredResultModel<T>
    {
        public int TotalDataCount { get; set; }
        public int FilteredDataCount { get; set; }
        public T Data { get; set; }
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
