using AutoMapper;
using demoBackEndQlTp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoBackEndQlTp2.ViewModels
{
    public class ViewToModel:Profile
    {
        public ViewToModel()
        {
            CreateMap<ThanhPhoView, ThanhPho>();
            CreateMap<QuanHuyenView, QuanHuyen>();
            CreateMap<XaPhuongView, XaPhuong>();
        }
    }
}
