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
        // TODO: 11.1 Fetch all authors and return list, include Books for each author and return the view with authors
        // Refer to similar listing for Members
        // throw new NotImplementedException("AuthorsController.Authors is not implemented");
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
        // TODO: 11.2 Check if model is valid then add author to context and save changes, then redirect to Authors action
        if (ModelState.IsValid)
        {
            context.Authors.Add(author);
            context.SaveChanges();
            return RedirectToAction("Authors");
        }
        // TODO: 11.3 Return the view with author if model is not valid, errors will be auto populated by the framework
        
        return View(author);
        // DO NOT MODIFY BELOW THIS LINE
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        // DO NOT MODIFY ABOVE THIS LINE
        // TODO: 11.4 Check if author exists, remove author from context and save changes, then redirect to Authors action
        // Checking author exists
        var author = context.Authors.Find(id);
        if (author != null)
        {
            // Removing author from context and saving changes
            context.Authors.Remove(author);
            context.SaveChanges();
            return RedirectToAction("Authors");
        }
        // TODO: 11.5 Return NotFound() if author does not exist
        // Returning NotFound() if author does not exist
        return NotFound();
        // DO NOT MODIFY BELOW THIS LINE
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        // DO NOT MODIFY ABOVE THIS LINE
        // TODO: 11.6 Find author by id, return NotFound() if author does not exist, otherwise return the view with author
       
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
        // TODO: 11.7 Check if model is valid then update author in context and save changes, then redirect to Authors action
        
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