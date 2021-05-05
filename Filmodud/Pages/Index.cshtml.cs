using Filmodud.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMovie.Pages.Movies
{

    public class IndexModel : PageModel
    {
        private readonly Index _context;

        public IndexModel(Index context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }

        //public async Task OnGetAsync()
        //{

        //    IQueryable<string> genreQuery = from m in _context.context
        //                                    orderby m.Genre
        //                                    select m.Genre;

        //    var movies = from m in _context.context
        //                 select m;

        //    if (!string.IsNullOrEmpty(SearchString))
        //    {
        //        movies = movies.Where(s => s.Title.Contains(SearchString));
        //    }

        //    if (!string.IsNullOrEmpty(MovieGenre))
        //    {
        //        movies = movies.Where(x => x.Genre == MovieGenre);
        //    }
        //    Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
        //    Movie = await movies.ToListAsync();
        //}
    }
}