using System;
using System.Threading.Tasks;

namespace School.WebApp.Interfaces
{
    public interface IRazorPage
    {
        void NeedRefresh();
        Task NeedInvokeAsync(Action action);
    }
}
