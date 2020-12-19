using demoBackEndQlTp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoBackEndQlTp2.ViewModels
{
    public class GetAllView
    {
        public int MaTp { get; set; }
        public string TenTp { get; set; }
        public int MaQuanHuyen { get; set; }
        public string TenQuanHuyen { get; set; }
        public List <QuanHuyen> quanHuyens { get; set; }
        public int MaXaPhuong { get; set; }
        public List<XaPhuong> xaPhuong { get; set; }
        public string TenXaPhuong { get; set; }

    }
}
