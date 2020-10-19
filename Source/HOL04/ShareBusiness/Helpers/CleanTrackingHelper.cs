namespace ShareBusiness.Helpers
{
    using EntityModel.Models;
    using Microsoft.EntityFrameworkCore;
    public class CleanTrackingHelper
    {
        public static void Clean<T>(SchoolContext context) where T : class
        {
            foreach (var fooXItem in context.Set<T>().Local)
            {
                context.Entry(fooXItem).State = EntityState.Detached;
            }
        }
    }
}
