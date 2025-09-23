using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;
using ReaLTaiizor.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcademicoAppV1
{
    public partial class FormAluno : MaterialForm
    {
        #region Variaveis
        string alunoFileName = "alunos.txt";
        bool isEditMode = false;
        int indexSelecionado = 0;
        #endregion

        #region Métodos
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

        private void Salvar()
        {
            var line = $"{txtMatricula.Text};" +
                $"{mtxtDataNascimento.Text};" +
                $"{txtNome.Text};" +
                $"{txtEndereco.Text};" +
                $"{txtBairro.Text};" +
                $"{txtCidade.Text};" +
                $"{txtSenha.Text};" +
                $"{cbEstado.Text};";

            if (!isEditMode)
            {
                using (StreamWriter sw = new StreamWriter(alunoFileName, true))
                {
                    sw.WriteLine(line);
                }
            }
            else
            {
                var fileLines = File.ReadAllLines(alunoFileName).ToList();
                fileLines[indexSelecionado] = line;
                File.WriteAllLines(alunoFileName, fileLines);
            }
        }

        private bool ValidaFormulario()
        {
            var erro = "";


            if (string.IsNullOrEmpty(txtMatricula.Text))
            {
                erro += "Matricula deve ser informada!\n";
            }
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                erro += "Nome deve ser informada!\n";
            }
            if (string.IsNullOrEmpty(mtxtDataNascimento.Text) || mtxtDataNascimento.Text.Contains("_"))
            {
                erro += "Data de nascimento deve ser informada!\n";
            }
            if (string.IsNullOrEmpty(txtEndereco.Text))
            {
                erro += "Endereço deve ser informada!\n";
            }
            if (string.IsNullOrEmpty(txtBairro.Text))
            {
                erro += "Bairro deve ser informada!\n";
            }
            if (string.IsNullOrEmpty(txtCidade.Text))
            {
                erro += "Cidade deve ser informada!\n";
            }
            if (string.IsNullOrEmpty(txtSenha.Text))
            {
                erro += "Senha deve ser informada!\n";
            }
            if (!string.IsNullOrEmpty(erro))
            {
                MessageBox.Show(erro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }
        private void CarregaListView()
        {
            listViewConsulta.View = View.Details;

            Cursor.Current = Cursors.WaitCursor;
            listViewConsulta.Items.Clear();
            listViewConsulta.Columns.Clear();
            listViewConsulta.Columns.Add("Matrícula");
            listViewConsulta.Columns.Add("Data Nasc.");
            listViewConsulta.Columns.Add("Nome");
            listViewConsulta.Columns.Add("Endereço");
            listViewConsulta.Columns.Add("Bairro");
            listViewConsulta.Columns.Add("Cidade");
            listViewConsulta.Columns.Add("Senha");
            listViewConsulta.Columns.Add("Estado");
            var fileLines = File.ReadAllLines(alunoFileName);

            foreach (var line in fileLines)
            {
                var campos = line.Split(";");
                listViewConsulta.Items.Add(new ListViewItem(campos));
            }
            listViewConsulta.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            Cursor.Current = Cursors.Default;
        }

        private void Editar()
        {

            if (listViewConsulta.SelectedIndices.Count > 0)
            {
                isEditMode = true;
                indexSelecionado = listViewConsulta.SelectedItems[0].Index;
                var item = listViewConsulta.SelectedItems[0];
                txtMatricula.Text = item.SubItems[0].Text;
                mtxtDataNascimento.Text = item.SubItems[1].Text;
                txtNome.Text = item.SubItems[2].Text;
                txtEndereco.Text = item.SubItems[3].Text;
                txtBairro.Text = item.SubItems[4].Text;
                txtCidade.Text = item.SubItems[5].Text;
                txtSenha.Text = item.SubItems[6].Text;
                cbEstado.Text = item.SubItems[7].Text;
                tabControlCadastro.SelectedIndex = 0;
                txtMatricula.Focus();
            }
            else
            {
                MessageBox.Show("Selecione algum registro!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Deletar()
        {
            if(listViewConsulta.SelectedItems.Count > 0)
            {
                if(MessageBox.Show("Deseja realmente deletar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var fileLines = File.ReadAllLines(alunoFileName).ToList();
                    fileLines.RemoveAt(indexSelecionado);
                    File.WriteAllLines(alunoFileName, fileLines);
                }
            }
        }
        #endregion

        #region Eventos

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
            if (MessageBox.Show("Informações não salvas serão perdidas!\n" +
                "Deseja realmente cancelar?", "Atenção",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                limparCampo();
                tabControlCadastro.SelectedIndex = 1;
                isEditMode = false;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidaFormulario())
            {
                Salvar();
                tabControlCadastro.SelectedIndex = 1;
            }
        }

        private void tabPageConsulta_Enter(object sender, EventArgs e)
        {
            CarregaListView();
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void listViewConsulta_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Editar();
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            Deletar();
            CarregaListView();
        }
        #endregion
    }
}
