using Prueba_Técnica.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Técnica.Controllers
{
    public class CompanyController
    {
        public static List <Company> GetCompaniesList ()
        {
            DbDataModel db = new DbDataModel();
            var companies = db.Companies.ToList();
            return companies;
        }

        public static void SaveCompany (Company company)
        {
            DbDataModel db = new DbDataModel();
            db.Companies.Add(company);
            db.SaveChanges();
        }

        public static void EditCompany (Company company, int? id)
        {
            DbDataModel db = new DbDataModel();
            Company companyWithId = db.Companies.Find(id);

            companyWithId.Name = company.Name;
            companyWithId.Code = company.Code;
            companyWithId.Address = company.Address;
            companyWithId.Phone = company.Phone;
            companyWithId.City = company.City;  
            companyWithId.Country = company.Country;
            companyWithId.Department = company.Department;
            companyWithId.DateModified = company.DateModified;

            db.SaveChanges();

        }

        public static Company GetCompanyById (int? id)
        {
            DbDataModel db = new DbDataModel();
            Company companyWithId = db.Companies.Find(id);
            return companyWithId;
        }

        public static void DeleteCompanyById (int? id)
        {
            DbDataModel db = new DbDataModel();
            Company companyWithId = db.Companies.Find(id);
            db.Companies.Remove(companyWithId);
            db.SaveChanges();
        }

        public static List <Company> FilterCompanyByName (string name)
        {
            DbDataModel db = new DbDataModel();
            return db.Companies.Where(item => item.Name.Contains(name)).ToList();
        }
    }
}
