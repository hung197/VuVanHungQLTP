using AutoMapper;
using demoBackEndQlTp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoBackEndQlTp2.ViewModels
{
    public class ModelToView:Profile
    {
        public ModelToView()
        {
            CreateMap<ThanhPho, ThanhPhoView>();
            CreateMap<QuanHuyen, QuanHuyenView>();
            CreateMap<XaPhuong, XaPhuongView>();
        }
    }
}
