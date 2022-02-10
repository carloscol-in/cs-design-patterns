using DesignPatterns.Models;
using DesignPatterns.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.UnitOfWorkPattern
{
    public class UnitOfWork : IUnitOfWork
    {
        private DesignPatternsContext _context;
        private IRepository<Beer>? _beers;
        private IRepository<Brand>? _brands;

        public IRepository<Beer> Beers
        {
            get
            {
                if (_beers == null)
                    _beers = new Repository<Beer>(_context);
                return _beers;
            }
        }

        public IRepository<Brand> Brands
        {
            get
            {
                if (_brands == null)
                    _brands = new Repository<Brand>(_context);
                return _brands;
            }
        }

        public UnitOfWork(DesignPatternsContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
