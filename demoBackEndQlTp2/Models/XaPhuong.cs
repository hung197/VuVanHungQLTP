using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace demoBackEndQlTp2.Models
{
    public class XaPhuong
    {
        [Key]
        public int MaXaPhuong { get; set; }
        public string TenXaPhuong { get; set; }
        public int MaQuanHuyen { get; set; }
        [ForeignKey("MaQuanHuyen")]
        public QuanHuyen QuanHuyen { get; set; }

    }
}
