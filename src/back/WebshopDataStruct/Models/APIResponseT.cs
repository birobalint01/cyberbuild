using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopCommon.Models
{
    public class APIResponse<TData>
    {
        public int StatusCode { get; set; } = 0;
        public string? Message { get; set; }
        public TData Data { get; set; } = default(TData);
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
