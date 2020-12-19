using demoBackEndQlTp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoBackEndQlTp2.ViewModels
{
    public class ThanhPhoView
    {
        public int MaTp { get; set; }
        public string TenTp { get; set; }
        public List<QuanHuyenView> QuanHuyens { get; set; } 
    }
}
