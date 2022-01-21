using System;

namespace OctoPrint.API.Models.Responses
{
    public class Response<T> : IResponse
    {
        public int Code { get; set; }
        public T Data { get; set; }
        public Type Type { get; set; } = typeof(T);
        public T1 GetContent<T1>()
        {
            return (T1)Convert.ChangeType(Data, typeof(T1));
        }
    }
}
