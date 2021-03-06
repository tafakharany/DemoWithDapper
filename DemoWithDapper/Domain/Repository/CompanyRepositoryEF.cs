using DemoWithDapper.Contracts;
using DemoWithDapper.Domain.Data;
using DemoWithDapper.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWithDapper.Domain.Repository
{
    public class CompanyRepositoryEF : ICompanyRepository
    {
        #region DI
        private readonly AppDbContext _context;
        #endregion

        #region ctors
        public CompanyRepositoryEF(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region CRUD
        
        private bool CompanyExists(int id)
        {
            return _context.Companies.Any(e => e.CompanyId == id);
        }

        public Company AddNewCompany(Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
            return company;
        }
        

        public Company GetById(int id)
        {
            return _context.Companies.FirstOrDefault(c => c.CompanyId == id);
        }

        public List<Company> GetAll()
        {
            return _context.Companies.ToList();
        }

        public Company UpdateCompany(Company company)
        {
            _context.Companies.Update(company);
            _context.SaveChanges();
            return company;
        }

        public void RemoveCompany(int id)
        {
            var company = _context.Companies.FirstOrDefault(c => c.CompanyId == id);
            _context.Companies.Remove(company);
            _context.SaveChanges();
            return;
        }
        #endregion
    }
}
