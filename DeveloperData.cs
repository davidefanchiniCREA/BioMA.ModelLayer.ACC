using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRA.ModelLayer.ACC
{
    public partial class DeveloperData : Form
    {
        public DeveloperData(APIdefinition aPIdefinition)
        {
            InitializeComponent();
            ad = aPIdefinition;
            LoadDeveloperData();
        }

        private APIdefinition ad;

        private void LoadDeveloperData()
        {
            txtNameLastname.Text = ad.AuthorNameLastname;
            txtEmail.Text = ad.Email;
            txtInstitution.Text = ad.Institution;
            txtURL.Text = ad.URL;
        }

        private void btnExitDeveloperData_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSaveDeveloperData_Click(object sender, EventArgs e)
        {
            ad.AuthorData.Tables[0].Rows[0][0] = txtNameLastname.Text;
            ad.AuthorData.Tables[0].Rows[0][1] = txtEmail.Text;
            ad.AuthorData.Tables[0].Rows[0][2] = txtInstitution.Text;
            ad.AuthorData.Tables[0].Rows[0][3] = txtURL.Text;
            string path = String.Empty;
            ad.AuthorData.WriteXml(path + APIdefinition.AuthorSettings);
            Close();
        }
    }
}
