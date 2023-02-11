﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Introduction_to_LINQ_and_ASP.NET_MVC_Lab02.Data;
using Introduction_to_LINQ_and_ASP.NET_MVC_Lab02.Models;

namespace Introduction_to_LINQ_and_ASP.NET_MVC_Lab02.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.PageTitle = "All Movies";
            return View(Context.Movies);
        }

        public IActionResult InGenre(string genre)
        {
            List<string> geners = Enum.GetNames(typeof(Genre)).ToList();

            if (Enum.GetNames(typeof(Genre)).Contains(genre))
            {
                //Genre foundGenre = (Genre)Enum.Parse(typeof(Genre), genre);

                HashSet<Movie> moviesInGenre = Context.Movies.Where(s =>
                {

                    return s.Genre.ToString().ToLower() == genre.ToLower();
                }).ToHashSet();

                ViewBag.MovieCount = moviesInGenre.Count;
                ViewBag.PageTitle = genre;

                return View("Index", moviesInGenre);

            } else
            {
                return NotFound();
            }
        }

        public IActionResult InBudget(int lower, int upper)
        {
            ViewBag.PageTitle = $"Movies in Budget between ${lower} to ${upper}";
            if (lower < 0 || upper < 0 || lower > upper)
            {
                ViewBag.Message = "Cannot have a negative budget";
                return View();
            } else
            {
                HashSet<Movie> movies = Context.Movies.Where(s =>
                {
                    return s.Budget >= lower && s.Budget <= upper;
                }).ToHashSet();
                ViewBag.MovieCount = movies.Count;
                return View("Index", movies);
            }
        }

        public IActionResult FromNineties()
        {
            ViewBag.PageTitle = "Movies from the Nineties";
            HashSet<Movie> movies = Context.Movies.Where(s =>
            {
                return s.ReleaseDate >= new DateTime(1990, 1, 1) && s.ReleaseDate <= new DateTime(2000, 1, 1);
            }).ToHashSet();
            ViewBag.MovieCount = movies.Count;
            return View("Index", movies);
        }

        public decimal GetOverallRating(Movie movie)
        {
            HashSet<Rating> ratings = movie.GetRatings();

            if (ratings.Any())
            {
                return decimal.Round(ratings.Average(r => (decimal)r.Value), 2);
            }
            else
            {
                return 0;
            }
        }

        public IActionResult Info(int Id)
        {
            try
            {
                Movie movie = Context.Movies.First(x =>
                {
                    return x.Id == Id;
                });

                ViewBag.AverageRating = GetOverallRating(movie);

                return View("Details", movie);
            } catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpPost] 
        public IActionResult AddRating(int rating, string comment, int Id)
        {
            Movie movie = Context.GetMovieById(Id);
            User user = Context.GetCurrentUser();

            if (movie.GetRatings().Any(r => r.User == user))
            {
                return RedirectToAction("Info", "Movie", new { id = movie.Id });
            }

            Rating newRating = new Rating(rating, user, movie, comment);
            
            movie.GetRatings().Add(newRating);
            Context.Ratings.Add(newRating);
            return RedirectToAction("Info", "Movie", new { id = movie.Id });
        }
        
       
    }
}