using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanguageCenter.GUI.childForms
{
    public partial class ClassManage : Form
    {
        public ClassManage()
        {
            InitializeComponent();
        }

        private void ClassManage_Load(object sender, EventArgs e)
        {
            classGridview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            classGridview.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
