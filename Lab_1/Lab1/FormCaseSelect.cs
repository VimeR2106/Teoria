using System;
using System.Windows.Forms;

namespace Lab1
{
    public partial class FormCaseSelect : Form
    {
        public FormCaseSelect()
        {
            InitializeComponent();
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            InputCase selected;
            if (radioCase1.Checked)
                selected = InputCase.AAndBGivenA;
            else if (radioCase2.Checked)
                selected = InputCase.BAndAGivenB;
            else
                selected = InputCase.JointAB;

            var inputForm = new FormInput(selected);
            inputForm.Show();
        }
    }
}
