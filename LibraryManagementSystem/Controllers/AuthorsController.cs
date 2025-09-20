using LibraryManagementSystem.Data;
using LibraryManagementSystem.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers;

public class AuthorsController(LibraryContext context) : Controller
{
    public IActionResult Authors()
    {
        // DO NOT MODIFY ABOVE THIS LINE

        // Fetching all authors and return list, including Books for each author and returning the view with authors
        
        var authors = context.Authors
            .Include(a => a.Books)
            .ToList();
        return View(authors);
        // DO NOT MODIFY BELOW THIS LINE
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Author author)
    {
        // DO NOT MODIFY ABOVE THIS LINE
        // Checking if model is valid then adding author to context and saving changes, then redirecting to Authors action
        if (ModelState.IsValid)
        {
            context.Authors.Add(author);
            context.SaveChanges();
            return RedirectToAction("Authors");
        }
        // Returning the view with author if model is not valid, errors will be auto populated by the framework
        
        return View(author);
        // DO NOT MODIFY BELOW THIS LINE
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        // DO NOT MODIFY ABOVE THIS LINE

        // Checking author exists
        var author = context.Authors.Find(id);
        if (author != null)
        {
            // Removing author from context and saving changes
            context.Authors.Remove(author);
            context.SaveChanges();
            return RedirectToAction("Authors");
        }
        // Returning NotFound() if author does not exist
        return NotFound();
        // DO NOT MODIFY BELOW THIS LINE
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        // DO NOT MODIFY ABOVE THIS LINE

        // Finding author by id
        var author = context.Authors.Find(id);
        if (author == null)
        {
            // Returning NotFound() if author does not exist
            return NotFound();
        }
        
        // Returning the view with author
        return View(author);
        // DO NOT MODIFY BELOW THIS LINE
    }

    [HttpPost]
    public IActionResult Update(Author author)
    {
        // DO NOT MODIFY ABOVE THIS LINE
        
        // Checking if model is valid then updating author in context and saving changes
        if (ModelState.IsValid)
        {
            context.Authors.Update(author);
            context.SaveChanges();
            return RedirectToAction("Authors");
        }
        
        // Returning view with validation errors if model is not valid
        return View(author);
        // DO NOT MODIFY BELOW THIS LINE
    }
}