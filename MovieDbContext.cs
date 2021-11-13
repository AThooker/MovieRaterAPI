using Microsoft.EntityFrameworkCore;
using MovieRaterApi.Models;

namespace MovieRaterApi
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options){}
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rating> Ratings { get; set; }
    }
}