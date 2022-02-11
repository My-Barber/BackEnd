using Microsoft.EntityFrameworkCore;
using Mybarber.Models;
using Mybarber.Persistencia;
using Mybarber.Repositories.Interface;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Mybarber.Repositories
{
    public class HTMLRepository : IHTMLRepository
    {
        private readonly Context _context;

        public HTMLRepository(Context context)
        {
            _context = context;
        }



        public async Task<HTML> GetHTMLAsyncById(int idHTML)
        {
           
                IQueryable<HTML> query = _context.HTML.Include(it=>it.HTMLContent);


                query = query.AsNoTracking()
                    .OrderBy(html => html.IdHTML)
                    .Where(html => html.IdHTML == idHTML);

                return await query.FirstOrDefaultAsync();
            }
           
        }
    }
