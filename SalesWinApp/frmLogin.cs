using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesWinApp
{
    public partial class frmLogin : Form
    {
        MemberRepository MemberRepository = new MemberRepository();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var memberLogin = MemberRepository.CheckLogin(txtEmail.Text, txtPassword.Text);

            if (memberLogin != null && memberLogin.Email.Equals("admin@fstore.com"))
            {
                frmMain frm = new frmMain()
                {
                    EmailLogin = txtEmail.Text
                };
                this.Hide();
                frm.Show();
            }
            else if (memberLogin != null && !memberLogin.Email.Equals("admin@fstore.com"))
            {
                frmMain frm = new frmMain()
                {
                    EmailLogin = txtEmail.Text
                };
                this.Hide();
                frm.Show();
            }
            else if (memberLogin == null)
            {
                MessageBox.Show("Incorrect email or password");
            }
            else
            {
                MessageBox.Show("Something error in login method");
            }


        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
