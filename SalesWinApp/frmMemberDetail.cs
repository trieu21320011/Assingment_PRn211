using BusinessObject;
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
    public partial class frmMemberDetail : Form
    {
        public MemberRepository MemberRepository;

        public bool InsertOrUpdate { get; set; }

        public Member MemberInfo { get; set; }

        public frmMemberDetail()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmMemberDetail_Load(object sender, EventArgs e)
        {
            if (InsertOrUpdate == true)
            {
                txtID.Text = MemberInfo.MemberId.ToString();
                txtID.ReadOnly = true;
                txtEmail.Text = MemberInfo.Email.ToString();
                txtCompany.Text = MemberInfo.CompanyName.ToString();
                txtCountry.Text = MemberInfo.Country.ToString();
                txtCity.Text = MemberInfo.City.ToString();
                txtPassword.Text = MemberInfo.Password.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtID.Text.Trim()) ||
                    String.IsNullOrEmpty(txtEmail.Text.Trim()) ||
                    String.IsNullOrEmpty(txtCompany.Text.Trim()) ||
                    String.IsNullOrEmpty(txtCity.Text.Trim()) ||
                    String.IsNullOrEmpty(txtCountry.Text.Trim()) ||
                    String.IsNullOrEmpty(txtPassword.Text.Trim())) 
                {
                    throw new Exception("Fields can't empty!");
                }
                var member = new Member
                {
                    MemberId = Int32.Parse(txtID.Text),
                    Email = txtEmail.Text,
                    CompanyName = txtCompany.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                    Password = txtPassword.Text
                };
                if (InsertOrUpdate == false)
                {
                    MemberRepository.InsertMember(member);
                    Close();
                }
                else
                {
                    MemberRepository.UpdateMember(member);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a new member" : "Update a member");
            }
        }
    }
}
