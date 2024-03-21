using DesignPatterns.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Repository
{
    public class BeerRespository : IBeerRepository
    {
        private DesignPatternsContext _context;

        public BeerRespository(DesignPatternsContext context)
        {
            _context = context;
        }

        public void Add(Beer data) => _context.Add(data);

        public void Delete(int id)
        {
            var beer = _context.Beers.Find(id);
            _context.Remove(beer);
        }

        public IEnumerable<Beer> Get() => _context.Beers.ToList();

        public Beer Get(int id) => _context.Beers.Find(id);

        public void Save() => _context.SaveChanges();

        public void Update(Beer data) => _context.Entry(data).State = EntityState.Modified;
    }
}
