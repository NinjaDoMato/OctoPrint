using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoPrint.API.Models
{
    public interface IResponse
    {
        public int Code { get; set; }
        public Type Type { get; set; }

        public T GetContent<T>();
    }
}
