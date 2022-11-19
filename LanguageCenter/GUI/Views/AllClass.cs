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
    public partial class AllClass : Form
    {
        public AllClass()
        {
            InitializeComponent();
        }

        private void ClassManage_Load(object sender, EventArgs e)
        {
            AllClass_Gridview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AllClass_Gridview.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
