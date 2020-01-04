using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace app
{
    public interface IGetDataService
    {

        // Task<IDictionary<int, Book>> GetBooksAsync(IEnumerable<int> authorIds, CancellationToken cancellationToken);
        Task<ILookup<int, Book>> GetBooksAsync(IEnumerable<int> authorIds);
    }

    public class GetDataService : IGetDataService
    {

        public readonly ApplicationDbContext db;


        public GetDataService(ApplicationDbContext _db)
        {
            db = _db;
        }

        public async Task<ILookup<int, Book>> GetBooksAsync(IEnumerable<int> authorIds)
        {
            var books = await db.Books.Where(b => authorIds.Contains(b.AuthorId)).ToListAsync();
            return books.ToLookup(b => b.AuthorId);
        }



    }




}