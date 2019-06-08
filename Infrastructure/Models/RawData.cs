using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class RawData
    {
        public int Id { get; set; }
        public int? X { get; set; }
        public int? Y { get; set; }
        public int? Z { get; set; }
        public DateTime Day { get; set; }
        public string ApplicationUserID { get; set; }
    }
}
