using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication3.Models.ViewModels
{
    public class CompareMoviesVM
    {
        public List<SelectListItem> MovieIds { get; set; } = new List<SelectListItem>();
        public int? SelectedMovie1Id { get; set; }
        public int? SelectedMovie2Id { get; set; }
        public Movie SelectedMovie1 { get; set; }
        public Movie SelectedMovie2 { get; set; }
    }
}
