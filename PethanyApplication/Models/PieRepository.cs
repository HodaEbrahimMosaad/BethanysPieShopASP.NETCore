using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PethanyApplication.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext _appDbContext;

        public PieRepository(AppDbContext _context)
        {
            _appDbContext = _context;
        }
        public IEnumerable<Pie> AllPies()
        {
            return _appDbContext.Pies.Include(c => c.Category);
        }

        public IEnumerable<Pie> PiesOfTheWeek()
        {
            return _appDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek == true);
        }

        public Pie GetPieById(int pieId)
        {
            return _appDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        }
    }
}
