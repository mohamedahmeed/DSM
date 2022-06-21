using AutoMapper;
using DSM.TABLES.Guide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM.DTO
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<BranchDTO,Branch>().ReverseMap();
            CreateMap<ScreenDTO, ImagesScreen>().ReverseMap();

        }
    }
}
