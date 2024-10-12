using Microsoft.AspNetCore.Mvc;

namespace Lms.UI.Areas.Admin.ViewComponents;

public class HeaderViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View();
    }
}
