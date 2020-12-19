using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoBackEndQlTp2.ViewModels
{
    public class XaPhuongView
    {
        public int MaXaPhuong { get; set; }
        public string TenXaPhuong { get; set; }
        public int MaQuanHuyen { get; set; }
        public QuanHuyenView QuanHuyen { get; set; } 
    }
}
