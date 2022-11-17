using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
        private void checkInput(string memberID, string company, string city, string country, string email)
        {
            IMemberRepository memberRepository = new MemberRepository();
            
            if(IsValidEmail(email) == false)
            {
                throw new Exception("Not format email");
            }
            foreach (var c in company)
            {
                if (!(Char.IsLetter(c) || Char.IsWhiteSpace(c)))
                {
                    throw new Exception("Company is not allowed with special characters or digits");
                }
            }
            if (!(company.Length > 0 && company.Length <= 50))
            {
                throw new Exception("Company is in the range 0-50 charaters");
            }
            foreach (var c in city)
            {
                if (!(Char.IsLetter(c) || Char.IsWhiteSpace(c)))
                {
                    throw new Exception("City is not allowed with special characters or digits");
                }
            }
            if (!(city.Length > 0 && city.Length <= 50))
            {
                throw new Exception("Company is in the range 0-50 charaters");
            }
            foreach (var c in country)
            {
                if (!(Char.IsLetter(c) || Char.IsWhiteSpace(c)))
                {
                    throw new Exception("Country is not allowed with special characters or digits");
                }
            }
            if (!(country.Length > 0 && country.Length <= 50))
            {
                throw new Exception("Company is in the range 0-50 charaters");
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
                    checkInput(txtID.Text.Trim(), txtCompany.Text.Trim(), txtCity.Text.Trim(), txtCountry.Text.Trim(), txtEmail.Text.Trim());
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

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
