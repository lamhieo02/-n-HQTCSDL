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
    public partial class TeacherSchedule : Form
    {
        public TeacherSchedule()
        {
            InitializeComponent();
        }

        private void ClassManage_Load(object sender, EventArgs e)
        {
            TeacherSchedule_GridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            TeacherSchedule_GridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
