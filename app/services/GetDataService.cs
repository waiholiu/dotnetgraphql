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

        Task<ILookup<int, SalesInvoice>> GetSalesInvoicesAsync(IEnumerable<int> bookIds);

        Task<IDictionary<int, Author>> GetAuthorsByIdAsync(IEnumerable<int> authorIds, CancellationToken cancellationToken);
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

         public async Task<ILookup<int, SalesInvoice>> GetSalesInvoicesAsync(IEnumerable<int> bookIds)
        {
            var salesInvoices = await db.SalesInvoices.Where(b => bookIds.Contains(b.BookId)).ToListAsync();
            return salesInvoices.ToLookup(b => b.BookId);
        }

        public async Task<IDictionary<int, Author>> GetAuthorsByIdAsync(IEnumerable<int> authorIds, CancellationToken cancellationToken){
            return await db.Authors.Where(a => authorIds.Contains(a.Id)).ToDictionaryAsync(a => a.Id, a => a);
        }



    }




}