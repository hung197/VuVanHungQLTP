using AutoMapper;
using demoBackEndQlTp2.Models;
using demoBackEndQlTp2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoBackEndQlTp2.Service
{
    public class Services
    {
        APIDbContext DbContext;
        IMapper mapper;
        public Services(APIDbContext _DbContext, IMapper _mapper)
        {
            DbContext = _DbContext;
            mapper = _mapper;
        }

        public List<GetAllView> GetAll()
        {
            var GetAllTable = from tp in DbContext.thanhPhos
                              select new GetAllView
                              {
                                  TenTp = tp.TenTp,
                                  MaTp = tp.MaTp,
                                  quanHuyens = (from qh in DbContext.quanHuyens
                                                where qh.MaTp == tp.MaTp

                                                select new QuanHuyen
                                                {
                                                    MaQuanHuyen = qh.MaQuanHuyen,
                                                    TenQuanHuyen = qh.TenQuanHuyen,
                                                    xaPhuongs = (from xp in DbContext.xaPhuongs
                                                                 where xp.MaQuanHuyen == qh.MaQuanHuyen
                                                                 select new XaPhuong
                                                                 {
                                                                     TenXaPhuong = xp.TenXaPhuong,
                                                                     MaXaPhuong = xp.MaXaPhuong
                                                                 }).ToList(),
                                                }).ToList(),
                              };
            return GetAllTable.ToList();
        }
    }
}
