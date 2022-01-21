using System;

namespace OctoPrint.API.Models
{
    public interface IResponse
    {
        public int Code { get; set; }
        public Type Type { get; set; }

        public T GetContent<T>();
    }
}
