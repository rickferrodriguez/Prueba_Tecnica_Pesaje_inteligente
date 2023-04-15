using Prueba_Técnica.Controllers;
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
    public partial class FormCompanyList : Form
    {
        public FormCompanyList()
        {
            InitializeComponent();
        }

        private void getCompaniesList ()
        {
            if (textBoxFilter.Text != "")
            {
                var filteredList = CompanyController.FilterCompanyByName(textBoxFilter.Text);
                dataGridCompany.DataSource = filteredList;
                dataGridCompany.Columns[0].Visible = false;
                dataGridCompany.Refresh();
            }
            else
            {
                var list = CompanyController.GetCompaniesList();
                dataGridCompany.DataSource = list;
                dataGridCompany.Columns[0].Visible = false;
                dataGridCompany.Refresh();
            }
        }

        private void dataGridCompany_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void FormCompanyList_Load(object sender, EventArgs e)
        {
            getCompaniesList();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridCompany.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridCompany.SelectedRows[0].Cells[0].Value);
                FormCompanyEditor comp = new FormCompanyEditor(id);
                comp.ShowDialog();
                getCompaniesList();
            }
            else
            {
                MessageBox.Show("Debe seleccionar UNA fila");
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormCompanyEditor comp = new FormCompanyEditor(null);
            comp.ShowDialog();
            getCompaniesList();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridCompany.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridCompany.SelectedRows[0].Cells[0].Value);
                CompanyController.DeleteCompanyById(id);
                getCompaniesList();
            }
            else
            {
                MessageBox.Show("Debe seleccionar UNA fila");
            }

        }

        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
            getCompaniesList();
        }
    }
}
