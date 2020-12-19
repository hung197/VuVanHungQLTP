using demoBackEndQlTp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoBackEndQlTp2.ViewModels
{
    public class QuanHuyenView
    {
        public int MaQuanHuyen { get; set; }
        public string TenQuanHuyen { get; set; }
        public int MaTp { get; set; }
        public ThanhPho ThanhPho { get; set; }
        public List<XaPhuongView> xaPhuongs { get; set; }
    }
}
