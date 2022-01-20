using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoPrint.API.Models.Responses
{
    public class Response<T> : IResponse
    {
        public int Code { get; set; }
        public T Data { get; set; }
        public T GetContent<T>()
        {
            return (T)Convert.ChangeType(Data, typeof(T));
        }
    }
}
