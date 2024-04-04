using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Solucion.Data;
using Solucion.Models;
namespace Solucion.Controllers
{
    public class UsersController : Controller
    {
        public readonly BaseContext _context;

        public UsersController(BaseContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(){
            return View(await _context.Users.ToListAsync());
        }
        public async Task<IActionResult> Details(int id){

            return View(await _context.Users.FirstOrDefaultAsync(m=> m.Id == id));
        }
        
        public async Task<IActionResult> Delete(int id){
             var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user); 
            await _context.SaveChangesAsync(); 
            return RedirectToAction("Index"); 
        }
        public IActionResult Create(){
            return View();
        }
        [HttpPost]
        public  IActionResult Create(User user){
             _context.Users.Add(user);
             _context.SaveChanges();
             return RedirectToAction("Index");
        }
         public async Task<IActionResult> Edit(int? id){
            return View(await _context.Users.FirstOrDefaultAsync(m=> m.Id == id));
        }
        [HttpPost]
        public  IActionResult Edit(int id, User user){
             _context.Users.Update(user);
             _context.SaveChanges();
             return RedirectToAction("Index");
        }
    }
}