using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MoviesController : Controller
    {
       

        private readonly ApplicationDbContext _db;



        public MoviesController(ApplicationDbContext db)
        {
            _db = db;
        }


		public IActionResult AddMovie()
		{
			FullMovieModel fullMovieModel = new FullMovieModel();


			fullMovieModel.Genres = _db.Genres.ToList();
			//fullMovieModel.Actors = _db.Actors.ToList();
			return View(fullMovieModel);
		}

		public IActionResult NewGenre()
		{
			return View();
		}

		[BindProperty]
		public Genre genre { get; set; }

		public async Task<IActionResult> NewGenreCreate()
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			_db.Genres.Add(genre);
			await _db.SaveChangesAsync();

			return RedirectToAction("Index");
		}



		public IActionResult Index(string sortOrder,string searching)
        {

			ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
			ViewBag.NameSearchParm = String.IsNullOrEmpty(searching) ? searching : "";
			ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
			var movies = from s in _db.Movies select s;
			switch (sortOrder)
			{
				case "name_desc":
					movies = movies.OrderByDescending(s => s.Title);
					break;
				case "Date":
					movies = movies.OrderBy(s => s.Release);
					break;
				case "date_desc":
					movies = movies.OrderByDescending(s => s.Release);
					break;
				default:
					movies = movies.OrderBy(s => s.Title);
					break;
			}

			if(!String.IsNullOrEmpty(searching))
			{
				movies = movies.Where(s => s.Title.Contains(searching));
			}

			return View(movies.ToList());
		}

        [BindProperty]
        public Movie Movie { get; set; }
	//	public List<Actor> Actors { get; set; }

		public async Task<IActionResult> Create()
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _db.Movies.Add(Movie);
		//	_db.Actors.Add(Movie.Actors);
			await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int Id)
        {
            //Movie movie = new Movie();
			FullMovieModel movie = new FullMovieModel();
            movie.Movie = _db.Movies.Find(Id);
			movie.Genres = _db.Genres.ToList();
			return View(movie);
        }

        public async Task<IActionResult> EditConfirm(Movie movie) 
        {
            if (ModelState.IsValid)
            {
                _db.Entry(movie).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }


            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Details(int id) 
        {
            var movie = await _db.Movies.FindAsync(id);
            return View(movie);

        }


        public async Task<IActionResult> Delete(int id) //delete
        {
            var movie = await _db.Movies.FindAsync(id);
            return View(movie);

        }


        public async Task<IActionResult> DeleteConfirmed(int id) //delete
        {
            var movie = await _db.Movies.FindAsync(id);
            if (movie != null)
            {
                _db.Movies.Remove(movie);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }



    }
}