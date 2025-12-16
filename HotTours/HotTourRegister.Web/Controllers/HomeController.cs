using System.Diagnostics;
using Entities;
using Microsoft.AspNetCore.Mvc;
using HotTourRegister.Web.Models;
using Services.Contracts;

namespace HotTourRegister.Web.Controllers;

/// <summary>
/// Контроллер
/// </summary>
public class HomeController : Controller
{
    private readonly ITourManager tourManager;

    /// <summary>
    /// Конструктор
    /// </summary>
    public HomeController(ITourManager  tourManager)
    {
        this.tourManager = tourManager;
    }

    /// <summary>
    /// Получить список всех туров
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var model = new MainModel
        {
            Tours = await tourManager.GetAll(cancellationToken),
            Statistics = await tourManager.GetStatistics(cancellationToken)
        };
        return View(model);
    }

    /// <summary>
    /// Страница политики
    /// </summary>
    [HttpGet]
    public IActionResult Privacy()
    {
        return View();
    }

    /// <summary>
    /// Получить станицу обновления туров
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> EditStudentPage(Guid tourId, CancellationToken cancellationToken)
    {
        var student = await tourManager.GetById(tourId, cancellationToken);
        if (student is null)
        {
            return NotFound();
        }
        return View(nameof(AddTourPage),student);
    }

    /// <summary>
    /// Получить станицу добавления туров
    /// </summary>
    [HttpGet]
    public IActionResult AddTourPage()
    {
        return View();
    }

    /// <summary>
    /// Удалить тур
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Delete(Guid tourId, CancellationToken cancellationToken)
    {
        await tourManager.Delete(tourId, cancellationToken);
        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Обновить тур
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Update(Tour tour, CancellationToken cancellationToken)
    {
        await tourManager.Update(tour, cancellationToken);
        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Создать тур
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create(Tour tour, CancellationToken cancellationToken)
    {
        await tourManager.Add(tour, cancellationToken);
        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Ошибка новичка
    /// </summary>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
