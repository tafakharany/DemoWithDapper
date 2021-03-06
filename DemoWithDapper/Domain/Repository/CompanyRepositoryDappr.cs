using Dapper;
using DemoWithDapper.Contracts;
using DemoWithDapper.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWithDapper.Domain.Repository
{
    public class CompanyRepositoryDappr : ICompanyRepository
    {
        #region Fields
        private readonly IDbConnection _db;
        #endregion
        #region Ctors
        public CompanyRepositoryDappr(IConfiguration configuration)
        {
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        #endregion
        public Company AddNewCompany(Company company)
        {
            var com = "Insert Into Companies(Name,Address,City,State,PostalCode) Values(@Name, @Address, @City, @State, @PostalCode);"
                        + "SELECT CAST(SCOPE_IDENTITY() as int);";

            var id = _db.Query<int>(com, new
            {
                @Name = company.Name,
                @Address = company.Address,
                @City = company.City,
                @State = company.State,
                @PostalCode = company.PostalCode
            }).Single();
            company.CompanyId = id;
            return company;
        }

        public List<Company> GetAll()
        {
            var com = "Select * From Companies";
            return _db.Query<Company>(com).ToList();
        }

        public Company GetById(int id)
        {
            var com = "Select * From Companies Where CompanyId = @companyId";
                return _db.Query<Company>(com, new { @companyId = id}).Single();
        }

        public void RemoveCompany(int id)
        {
            var com = "DELETE From Companies Where CompanyId=@CompanyId";
            _db.Execute(com, new { CompanyId = id });
        }

        public Company UpdateCompany(Company company)
        {
            var com = "UPDATE Companies Set Name = @Name, Address = @Address, City = @City, " +
                "State = @state, PostalCode = @PostalCode Where CompanyId = @CompanyId";
            _db.Execute(com, company);
            return company;
        }
    }
}
