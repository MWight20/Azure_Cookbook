using AutoMapper;
using My_Cookbook.Dtos;
using My_Cookbook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace My_Cookbook.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Recipe, RecipeDto>();
            Mapper.CreateMap<RecipeDto, Recipe>();


        }
    }
}