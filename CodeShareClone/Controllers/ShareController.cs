using CodeShareClone.Models;
using Microsoft.AspNetCore.Mvc;

public class ShareController : Controller
{
    private readonly AppDbContext _context;
    public ShareController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Create()
    {
        var code = new Code
        {
            Content = ""
        };

        _context.Codes.Add(code);
        _context.SaveChanges();

        return RedirectToAction(nameof(ViewCode), new { id = code.Id });
    }

    public IActionResult Listele()
    {
        var codes = _context.Codes
            .OrderByDescending(x => x.Id)
            .ToList();

        return View(codes);
    }

    [HttpGet]
    public IActionResult Sil(Guid id)
    {
        var code = _context.Codes.FirstOrDefault(x => x.Id == id);
        if (code == null)
            return NotFound();
        return View(code);
    }

    [HttpPost, ActionName("Sil")]
    public IActionResult SilOnayla(Guid id)
    {
        var code = _context.Codes.FirstOrDefault(x => x.Id == id);
        if (code == null)
            return NotFound();

        _context.Remove(code);
        _context.SaveChanges();

        return RedirectToAction("Listele");
    }

    [HttpGet("/Share/{id:guid}")]
    public IActionResult ViewCode(Guid id)
    {
        var code = _context.Codes.FirstOrDefault(x => x.Id == id);
        if (code == null)
            return NotFound();
        return View(code);
    }
}
