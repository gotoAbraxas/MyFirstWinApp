using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TESTAPP.common.component.Dynamic;

namespace TESTAPP
{
     enum AccountType
    {
        자유입출금,
        저축성예금,
        MMW,
        MMF,
        RP,
        직접입력,


    }

    public partial class SelectAccountTypeDialog : Form
    {
        public object Result { get; private set; }
        public SelectAccountTypeDialog()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            SetEnumToCombo<AccountType>(cb_AccountTypeList);
            cb_AccountTypeList.SelectedItem = AccountType.자유입출금;

        }

        private void bt_AccountSelect_Click(object sender, EventArgs e)
        {
            Result = cb_AccountTypeList.SelectedItem;

            this.Close();
        }


        private void bt_AccountCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
