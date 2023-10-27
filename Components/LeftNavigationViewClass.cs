using Microsoft.AspNetCore.Mvc;

namespace Ostim.Component
{
    public class LeftNavigationViewClass : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
