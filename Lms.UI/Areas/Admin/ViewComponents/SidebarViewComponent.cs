﻿
using Microsoft.AspNetCore.Mvc;

namespace Lms.UI.Areas.Admin.ViewComponents
{
    public class SidebarViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
