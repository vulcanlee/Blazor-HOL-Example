using System.Linq;
using System.Threading.Tasks;

namespace School.WebApp.Services
{
    using EntityModel.Models;
    using Microsoft.EntityFrameworkCore;
    using ShareBusiness.Helpers;

    public class CourseService : ICourseService
    {
        private readonly SchoolContext context;

        public CourseService(SchoolContext context)
        {
            this.context = context;
        }

        public Task<IQueryable<Course>> GetAsync()
        {
            return Task.FromResult(context.Course
                .AsNoTracking()
                .Include(x => x.Department)
                .AsQueryable());
        }

        public async Task<Course> GetAsync(int id)
        {
            Course item = await context.Course
                .AsNoTracking()
                .Include(x => x.Department)
                .FirstOrDefaultAsync(x => x.CourseId == id);
            return item;
        }

        public async Task<bool> AddAsync(Course paraObject)
        {
            CleanTrackingHelper.Clean<Course>(context);
            await context.Course
                .AddAsync(paraObject);
            await context.SaveChangesAsync();
            CleanTrackingHelper.Clean<Course>(context);
            return true;
        }

        public async Task<bool> UpdateAsync(Course paraObject)
        {
            CleanTrackingHelper.Clean<Course>(context);
            Course item = await context.Course
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.CourseId == paraObject.CourseId);
            if (item == null)
            {
                return false;
            }
            else
            {
                CleanTrackingHelper.Clean<Course>(context);
                context.Entry(paraObject).State = EntityState.Modified;
                await context.SaveChangesAsync();
                CleanTrackingHelper.Clean<Course>(context);
                return true;
            }

        }

        public async Task<bool> DeleteAsync(Course paraObject)
        {
            Course item = await context.Course
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.CourseId == paraObject.CourseId);
            if (item == null)
            {
                return false;
            }
            else
            {
                CleanTrackingHelper.Clean<Course>(context);
                context.Entry(paraObject).State = EntityState.Deleted;
                await context.SaveChangesAsync();
                CleanTrackingHelper.Clean<Course>(context);
                return true;
            }
        }
    }
}
