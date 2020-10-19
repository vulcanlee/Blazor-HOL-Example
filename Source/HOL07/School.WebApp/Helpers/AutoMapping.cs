namespace School.WebApp.Helpers
{
    using AutoMapper;
    using EntityModel.Models;
    using School.WebApp.AdapterModels;

    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Department, DepartmentAdapterModel>();
            CreateMap<DepartmentAdapterModel, Department>();
            CreateMap<Course, CourseAdapterModel>();
            CreateMap<CourseAdapterModel, Course>();
            CreateMap<Outline, OutlineAdapterModel>();
            CreateMap<OutlineAdapterModel, Outline>();
        }
    }
}
