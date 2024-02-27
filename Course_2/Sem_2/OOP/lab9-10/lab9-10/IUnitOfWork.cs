using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    public interface IUnitOfWork
    {
        IRepository<Author> AuthorRepository { get; }
        IRepository<Book> BookRepository { get; }

        void Commit();

        void RejectChanges();
        void Dispose();
    }
}
