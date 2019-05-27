using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
	public class FullMovieModel
	{
		public Movie  Movie{get;set;}
		public List<Genre> Genres { get; set; }
		
	}
}
