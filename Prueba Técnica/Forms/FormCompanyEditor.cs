using Prueba_Técnica.Controllers;
using Prueba_Técnica.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba_Técnica.Forms
{
    public partial class FormCompanyEditor : Form
    {

        private bool isEdit = false;
        private int? Id;

        public FormCompanyEditor(int? id)
        {
            InitializeComponent();
            if (id != null)
            {
                Id = id;
                GetCompanyByIdEdit(Id);
                isEdit = true;
            }

            if (isEdit)
            {
                labelTypeOfView.Text = "Editando Empresa";
            } else
            {

                labelTypeOfView.Text = "Creando nueva Empresa";
            }
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            string CompanyName = textBoxName.Text;
            string Country = textBoxCountry.Text;
            string Code = textBoxCode.Text;
            string Address = textBoxAddress.Text;
            string Phone = textBoxPhone.Text;
            string City = textBoxCity.Text;
            string Department = textBoxState.Text;


            if (isEdit && ValidateFields(CompanyName, Code))
            {
                Company company = new Company(CompanyName, Convert.ToInt32(Code), Address, Phone, City, Department, Country, DateTime.Now, DateTime.Now);
                CompanyController.EditCompany(company, Id);
                this.Close();
            } else if(!isEdit && ValidateFields(CompanyName, Code) )
            {
                Company company = new Company(CompanyName, Convert.ToInt32(Code), Address, Phone, City, Department, Country, DateTime.Now, DateTime.Now);
                CompanyController.SaveCompany(company);
                this.Close();
            }

        }

        private void GetCompanyByIdEdit (int? id)
        {
            Company companyById = CompanyController.GetCompanyById(id);
            textBoxName.Text = companyById.Name;
            textBoxCountry.Text = companyById.Country;
            textBoxCode.Text = companyById.Code.ToString();
            textBoxAddress.Text = companyById?.Address;
            textBoxPhone.Text = companyById.Phone;
            textBoxCity.Text = companyById != null ? companyById.City : "";
            textBoxState.Text = companyById.Department;
        }


        private void saveNewCompany ()
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close ();
        }

        private void FormCompanyEditor_Load(object sender, EventArgs e)
        {

        }

        private bool ValidateFields (string name, string code)
        {
            if (name == "" || code == "" || code == null) {
                MessageBox.Show("Diligenciar codigo y nombre");
                return false;
            }

            return true;
        }
    }
}
