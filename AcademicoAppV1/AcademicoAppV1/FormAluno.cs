using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcademicoAppV1
{
    public partial class FormAluno : MaterialForm
    {
        string alunoFileName = "alunos.txt";
        bool isEditMode = false;

        public FormAluno()
        {
            InitializeComponent();
        }

        private void limparCampo()
        {
            isEditMode = false;
            foreach (var control in tabPageCadastro.Controls)
            {
                if (control is MaterialTextBoxEdit textBox)
                    textBox.Clear();
                if (control is MaterialMaskedTextBox maskedTextBox)
                    maskedTextBox.Clear();
            }
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            limparCampo();

            //mudando par apag cadastro
            tabControlCadastro.SelectedIndex = 0;
            //campo matricula recebe foco de teclado
            txtMatricula.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Informações não salvas serão perdidas!\n"+
                "Deseja realmente cancelar?", "Atenção",
                MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                limparCampo();
                tabControlCadastro.SelectedIndex = 1;
            }
        }
    }
}
