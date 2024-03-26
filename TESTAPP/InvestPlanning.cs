using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TESTAPP.account.service;
using TESTAPP.domain.account;

namespace TESTAPP
{
    public partial class InvestPlanning : Form
    {

        private AccountService accountService;

        public decimal Amounts { get; set; }
        public int Period { get; set; }
        public List<long> AccountIds { get; set; }
        public InvestPlanning()
        {

            InitializeComponent();
        }

        private void InvestPlanning_Load(object sender, EventArgs e)
        {
            ServiceInit();
            GetAccountList();
        }

        private void ServiceInit()
        {
            accountService = new AccountService();
        }

        private void GetAccountList()
        {
            accountService.GetAccountByIds(1L, AccountIds);
            // 일단 여까진 옴 ... 
        }
    }
}
