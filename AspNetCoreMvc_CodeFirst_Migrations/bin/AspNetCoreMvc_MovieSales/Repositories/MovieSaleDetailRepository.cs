using AspNetCoreMvc_MovieSales.Data;
using AspNetCoreMvc_MovieSales.Interfaces;
using AspNetCoreMvc_MovieSales.Models;

namespace AspNetCoreMvc_MovieSales.Repositories
{
    public class MovieSaleDetailRepository : IMovieSaleDetailRepository
    {
        private readonly MovieDbContext _context;
        public MovieSaleDetailRepository(MovieDbContext context)
        {
            _context = context;
        }
        public void Add(MovieSaleDetail movieSaleDetail)
        {
            _context.MovieSaleDetails.Add(movieSaleDetail); //ara katmana ekler.
            _context.SaveChanges(); //veritabanıyla eşleştirir.
        }

        public bool AddRange(List<SepetDetay> sepet, int movieSaleId)
        {
            throw new NotImplementedException();
        }

        public List<MovieSaleDetail> GetAll()
        {
            return _context.MovieSaleDetails.ToList();
        }
    }
}
