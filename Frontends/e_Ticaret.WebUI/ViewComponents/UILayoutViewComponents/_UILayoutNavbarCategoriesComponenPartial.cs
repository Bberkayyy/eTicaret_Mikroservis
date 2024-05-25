using e_Ticaret.WebUI.Services.CatalogServices.CategoryServices;
using e_Ticaret.WebUIDtos.CatalogDtos.CategoryDtos;
using e_Ticaret.WebUIDtos.CatalogDtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace e_Ticaret.WebUI.ViewComponents.UILayoutViewComponents;

public class _UILayoutNavbarCategoriesComponenPartial : ViewComponent
{
    private readonly ICategoryService _categoryService;

    public _UILayoutNavbarCategoriesComponenPartial(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        IEnumerable<ResultCategoryDto>? values = await _categoryService.GetAllCategoryAsync();
        return View(values);
    }
}
