using DemoWithDapper.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWithDapper.Contracts
{
    public interface ICompanyRepository
    {
        List<Company> GetAll();
        Company GetById(int id);
        Company AddNewCompany(Company company);
        Company UpdateCompany(Company company);
        void RemoveCompany(int id);
    }
}
