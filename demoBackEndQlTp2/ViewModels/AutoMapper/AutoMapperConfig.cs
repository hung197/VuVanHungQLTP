using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoBackEndQlTp2.ViewModels.AutoMapper
{
    public class AutoMapperConfig:Profile
    {
        public static MapperConfiguration RegisterMappping()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ModelToView());
                cfg.AddProfile(new ViewToModel());
            });
        }
    }
}
