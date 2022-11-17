using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesWinApp
{
    public partial class frmMember : Form
    {

        MemberRepository memberRepository = new MemberRepository();

        BindingSource source;

        public bool InsertOrUpdate { get; set; }

        public Member MemberInfo { get; set; }

        public string EmailLogin { get; set; }

        public frmMember()
        {
            InitializeComponent();
        }

        private void frmMember_Load(object sender, EventArgs e)
        {
            LoadMemberList();
        }

        private void ClearText()
        {
            txtId.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtCountry.Text = string.Empty;
            txtCompany.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

        public void LoadMemberList()
        {
            var members = memberRepository.GetMembers();
            try
            {
                source = new BindingSource();
                source.DataSource = members;

                txtId.DataBindings.Clear();
                txtEmail.DataBindings.Clear();
                txtCountry.DataBindings.Clear();
                txtCompany.DataBindings.Clear();
                txtCity.DataBindings.Clear();
                txtPassword.DataBindings.Clear();

                txtId.DataBindings.Add("Text", source, "MemberId");
                txtEmail.DataBindings.Add("Text", source, "Email");
                txtCountry.DataBindings.Add("Text", source, "CompanyName");
                txtCompany.DataBindings.Add("Text", source, "City");
                txtCity.DataBindings.Add("Text", source, "Country");
                txtPassword.DataBindings.Add("Text", source, "Password");

                dgvMemberList.DataSource = null;
                dgvMemberList.DataSource = source;
                dgvMemberList.Columns.Remove("Orders");
                if (members.Count() == 0)
                {
                    ClearText();
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load member List");
            }
        }

        private Member GetMemberInfo()
        {
            Member member = null;
            try
            {
                member = new Member
                {
                    MemberId = Int32.Parse(txtId.Text),
                    Email = txtEmail.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                    Password = txtPassword.Text,
                    CompanyName = txtCompany.Text
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Member");
            }
            return member;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmMemberDetail frmMemberDetail = new frmMemberDetail()
            {
                Text = "Add Member",
                InsertOrUpdate = false,
                MemberRepository = memberRepository
            };
            if (frmMemberDetail.ShowDialog() == DialogResult.OK)
            {
                LoadMemberList();
                source.Position = source.Count - 1;
            }
            else
            {
                LoadMemberList();
            }
        }

        private void dgvMemberList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmMemberDetail frmMemberDetail = new frmMemberDetail()
            {
                Text = "Update Member",
                InsertOrUpdate = true,
                MemberInfo = GetMemberInfo(),
                MemberRepository = memberRepository
            };
            if (frmMemberDetail.ShowDialog() == DialogResult.OK)
            {
                LoadMemberList();
                source.Position = source.Count - 1;
            }
            else
            {
                LoadMemberList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var member = GetMemberInfo();
                
                DialogResult dialogResult = MessageBox.Show($"Do you want to delete member {member.MemberId} ?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    memberRepository.DeleteMember(member.MemberId);
                    LoadMemberList();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete a member");
            }
        }

        private void dgvMemberList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvMemberList.Columns[e.ColumnIndex].Index == 5 && e.Value != null)
            {
                dgvMemberList.Rows[e.RowIndex].Tag = e.Value;
                e.Value = new String('*', e.Value.ToString().Length);
            }
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            LoadMemberList();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
