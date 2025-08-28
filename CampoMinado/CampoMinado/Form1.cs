using System.Runtime.InteropServices.Marshalling;
using static System.Windows.Forms.LinkLabel;

namespace CampoMinado
{
    public partial class Form1 : Form
    {

        int tamanhoBotao = 30;
        int espacamento = 2;
        int bombas = 0;

        int linhasCampoMinado = 0;
        int colunasCampoMinado = 0;

        int celulasReveladas = 0;

        //cria matriz campo logica onde vai ser gerado as bombas e numeros
        int[,] matrizCampoLogica;
        //cria matriz campo visual onde os botoes vao interagir 
        Button[,] matrizCampoVisual;

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void OcultarBotoes()
        {
            comboBox1.Visible = false;
        }

        private void DesocultarBotoes()
        {
            comboBox1.Visible = true;
        }

        private void VoltarResetBtns()
        {

            Button buttonVoltar = new Button();
            Button buttonResetar = new Button();

            //tag dos botoes de controle
            buttonVoltar.Tag = "BotoesDeControle";
            buttonResetar.Tag = "BotoesDeControle";

            //localizacao
            buttonVoltar.Location = new Point(12, 12);
            buttonResetar.Location = new Point(950, 12);

            //fonte
            buttonVoltar.Font = new Font(buttonVoltar.Font, FontStyle.Bold);
            buttonResetar.Font = new Font(buttonVoltar.Font, FontStyle.Bold);

            //nomes dos botoes
            buttonVoltar.Name = ("Voltar");
            buttonResetar.Name = ("Resetar");

            //texto dos botoes
            buttonVoltar.Text = ("Voltar");
            buttonResetar.Text = ("Resetar");

            buttonVoltar.Click += Evento_buttonVoltar;
            buttonResetar.Click += Evento_buttonResetar;

            Controls.Add(buttonVoltar);
            Controls.Add(buttonResetar);
        }

        private void GeraBombasENumeros(int linha, int coluna, int bombas)
        {
            int contBombas = 0;

            this.linhasCampoMinado = linha;
            this.colunasCampoMinado = coluna;

            //gera bombas
            int cordX, cordY;
            Random random = new Random();
            for (int i = 0; i < bombas; i++)
            {
                do
                {
                    cordX = random.Next(0, linha);
                    cordY = random.Next(0, coluna);
                } while (matrizCampoLogica[cordX, cordY] == -1);

                matrizCampoLogica[cordX, cordY] = -1;
            }

            //conta bombas
            for (int i = 0; i < linha; i++)
            {
                for (int j = 0; j < coluna; j++)
                {
                    int bombasVizinhas = 0;

                    // verifica se o campo nao é uma bomba
                    if (matrizCampoLogica[i, j] != -1)
                    {
                        // Percorre a área de 3x3 ao redor da célula atual
                        for (int x = i - 1; x <= i + 1; x++)
                        {
                            for (int y = j - 1; y <= j + 1; y++)
                            {
                                // checa se os campos em volta do verificado nao é vazio
                                if (x >= 0 && x < linha && y >= 0 && y < coluna)
                                {
                                    if (matrizCampoLogica[x, y] == -1)
                                    {
                                        bombasVizinhas++;
                                    }
                                }
                            }
                        }
                        matrizCampoLogica[i, j] = bombasVizinhas;
                    }
                }
            }
        }

        //gera numeros
        /*for (int i = 0; i < linha; i++){
            for (int j = 0; j < coluna; j++) {
                if (matrizCampoLogica[i, j] != -1)
                {
                    if (i >= 0 && i < linha && j >= 0 && linha < coluna)
                    {
                            if (matrizCampoLogica[i - 1, j - 1] == -1) // 1º pos
                            {
                                contBombas++;
                            }
                            else if (matrizCampoLogica[i - 1, j] == -1) // 2º pos
                            {
                                contBombas++;
                            }
                            else if (matrizCampoLogica[i - 1, j + 1] == -1) // 3º pos
                            {
                                contBombas++;
                            }
                            else if (matrizCampoLogica[i, j - 1] == -1) // 4º pos
                            {
                                contBombas++;
                            }
                            else if (matrizCampoLogica[i, j + 1] == -1) // 5º pos
                            {
                                contBombas++;
                            }
                            else if (matrizCampoLogica[i + 1, j - 1] == -1) // 6º pos
                            {
                                contBombas++;
                            }
                            else if (matrizCampoLogica[i + 1, j] == -1) // 7º pos
                            {
                                contBombas++;
                            }
                            else if (matrizCampoLogica[i + 1, j + 1] == -1) // 8º pos
                            {
                                contBombas++;
                            }
                    }
                }
                matrizCampoVisual[i,j].Text = contBombas.ToString();
            }
        }
    }*/

        private void GerarCampo(int linhas, int colunas)
        {

            OcultarBotoes();

            matrizCampoLogica = new int[linhas, colunas];
            matrizCampoVisual = new Button[linhas, colunas];

            celulasReveladas = 0;

            //identifica quantas bombas tem q ter no campo
            if (linhas == 9 && colunas == 9)
            {
                bombas = 10;
            }
            else if (linhas == 16 && colunas == 16)
            {
                bombas = 40;
            }
            else
            {
                bombas = 99;
            }

            matrizCampoLogica = new int[linhas, colunas];
            matrizCampoVisual = new Button[linhas, colunas];

            GeraBombasENumeros(linhas, colunas, bombas);

            //calula largura e altura da para centralizar o campo na janela
            int larguraTotalGrade = (colunas * tamanhoBotao) + ((colunas - 1) * espacamento);
            int alturaTotalGrade = (linhas * tamanhoBotao) + ((linhas - 1) * espacamento);

            int cordX = (this.ClientSize.Width - larguraTotalGrade) / 2;
            int cordY = (this.ClientSize.Height - alturaTotalGrade) / 2;

            if (cordX < 0) cordX = 0;
            if (cordY < 0) cordY = 0;

            

            //cria os botoes(campo), ja colocando os botoes na sua localização certa
            for (int linha = 0; linha < linhas; linha++)
            {
                for (int coluna = 0; coluna < colunas; coluna++)
                {
                    Button buttonCampoMinado = new Button();

                    buttonCampoMinado.Tag = new Point(linha, coluna);

                    buttonCampoMinado.Name = $"{linha}_{coluna}";

                    buttonCampoMinado.Size = new Size(tamanhoBotao, tamanhoBotao);

                    int x = cordX + (coluna * (tamanhoBotao + espacamento));
                    int y = cordY + (linha * (tamanhoBotao + espacamento));

                    buttonCampoMinado.Location = new Point(x, y);

                    buttonCampoMinado.MouseUp += Evento_clickCampo;

                    //matrizCampoLogica[linha, coluna] = 0;
                    matrizCampoVisual[linha, coluna] = buttonCampoMinado;

                    Controls.Add(buttonCampoMinado);
                }
            }

            /*for (int linha = 0; linha < linhas; linha++)
            {
                for (int coluna = 0; coluna < colunas; coluna++)
                {
                    if (matrizCampoLogica[linha, coluna] == -1)
                    {
                        matrizCampoVisual[linha, coluna].Text = "💣";
                        matrizCampoVisual[linha, coluna].Font = new Font(matrizCampoVisual[linha, coluna].Font.FontFamily, 14, FontStyle.Bold);

                    }
                }
            }*/

            VoltarResetBtns();
        }

        private void checarVitoria() { 

            int totalCamposSemBombas = (linhasCampoMinado * colunasCampoMinado) - bombas;

            if (celulasReveladas == totalCamposSemBombas)
            {
                MessageBox.Show("Você venceu!!!");

                for (int i = 0; i < linhasCampoMinado; i++)
                {
                    for (int j = 0; j < colunasCampoMinado; j++)
                    {
                        matrizCampoVisual[i, j].Enabled = false;
                    }
                }
            }

            //lógica 2
            /*
            
            //precisa colocar parametros para funcionar

            int contBomba = 0;
            int contCampos = 0;
            
            for (int i = 0; i < linhasCampoMinado; i++ ) 
            {
                for (int j = 0; j < colunasCampoMinado; j++)
                {
                    if (matrizCampoLogica[i,j] == -1 && matrizCampoVisual[i,j].Text == "🚩")
                    {
                        contBomba++;
                    }
                    else
                    {
                        continue;
                    }
                    if(matrizCampoVisual[i, j].Enabled == false)
                    {
                        contCampos++;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            if (contBomba == bombas && contCampos == ((linhasCampoMinado * colunasCampoMinado) - bombas))
            {
                MessageBox.Show("Você venceu!!!");
            }*/
        }

        private void Evento_buttonVoltar(object sender, EventArgs e)
        {
            DesocultarBotoes();

            // Lógica para remover os botões do tabuleiro e de controle
            var botoesParaRemover = this.Controls.Cast<Control>()
                // Remove os botões do tabuleiro (que têm a Tag de coordenada Point)
                .Where(c => c is Button && c.Tag is Point).ToList();

            // Também remove os botões de controle pelo nome ou Tag
            botoesParaRemover.AddRange(this.Controls.Cast<Control>()
                .Where(c => c is Button && (c.Name == "Voltar" || c.Name == "Resetar")).ToList());

            foreach (var botao in botoesParaRemover)
            {
                this.Controls.Remove(botao);
                botao.Dispose();
            }
        }

        private void Evento_buttonResetar(object sender, EventArgs e)
        {
            IniciarNovoJogo(linhasCampoMinado, colunasCampoMinado);
        }

        /*private void Evento_buttonVoltar(object sender, EventArgs e)
        {
            DesocultarBotoes();

            List<Control> botoesParaRemover = new List<Control> { };

            foreach (Control control in this.Controls)
            {
                if (control is Button && control.Tag != null
                    && control.Tag.ToString() == "CampoMinadoBotao"
                    || control.Name == "Voltar"
                    || control.Name == "Resetar")
                {
                    botoesParaRemover.Add(control);
                }
            }

            foreach (Control buttonCampoMinado in botoesParaRemover)
            {
                this.Controls.Remove(buttonCampoMinado);
                buttonCampoMinado.Dispose();
            }
        }*/

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int linhas, colunas;

            int indice = comboBox1.SelectedIndex;

            if (indice == 0) // Fácil 
            {
                linhas = 9;
                colunas = 9;
            }
            else if (indice == 1) // Médio
            {
                linhas = 16;
                colunas = 16;
            }
            else // Difícil
            {
                linhas = 16;
                colunas = 30;
            }

            OcultarBotoes();
            GerarCampo(linhas, colunas);
        }

        private void Evento_clickCampo(object sender, MouseEventArgs e) 
        {

            Button botaoClicado = (Button)sender;

            Point coord = (Point)botaoClicado.Tag;
            int linhaClicada = coord.X;
            int colunaClicada = coord.Y;
            int valorCampo = matrizCampoLogica[linhaClicada, colunaClicada];

            //se o botao ja foi desativado, n acontece nada e se o campo tem a bandeira nao acontece nada
            if (botaoClicado.Enabled == false)
            {
                return;
            }

            //click esquerdo
            if (e.Button == MouseButtons.Left)
            {

                if (botaoClicado.Text == "🚩")
                {
                    return;
                }

                if (valorCampo == -1)
                {
                    MessageBox.Show("Você perdeu!");

                    for (int i = 0; i < linhasCampoMinado; i++)
                    {
                        for (int j = 0; j < colunasCampoMinado; j++)
                        {
                            matrizCampoVisual[i, j].Enabled = false;
                            if (matrizCampoLogica[i, j] == -1)// se é bomba
                            {
                                matrizCampoVisual[i, j].Text = "💣";
                                matrizCampoVisual[i, j].Font = new Font(matrizCampoVisual[i, j].Font.FontFamily, 14, FontStyle.Bold);
                            }
                            else // se é numero
                            {
                                matrizCampoVisual[i, j].Text = matrizCampoLogica[i, j].ToString();
                            }
                        }
                    }
                }
                else{
                    botaoClicado.Text = valorCampo.ToString(); ;
                    botaoClicado.Enabled = false;

                    celulasReveladas++;

                    if (valorCampo == 0)
                    {
                        revelarAdjacentes(linhaClicada, colunaClicada);
                    }
                    checarVitoria();
                }
            }

            //Click direito
            else if (e.Button == MouseButtons.Right) 
            {
                if (botaoClicado.Enabled == true)
                {
                    if (string.IsNullOrEmpty(botaoClicado.Text))
                    {
                        botaoClicado.Text = "🚩";
                    }
                    else
                    {
                        botaoClicado.Text = "";
                    }
                }
            }
        }

        private void revelarAdjacentes(int linha, int coluna) {

            for (int x = linha - 1; x <= linha + 1; x++) 
            {
                for (int y = coluna - 1; y <= coluna + 1; y++) 
                {
                    if (x >= 0 && x < linhasCampoMinado && y >= 0 && y < colunasCampoMinado)
                    {
                        Button vizinho = matrizCampoVisual[x, y];
                        int valorVizinho = matrizCampoLogica[x, y];

                        if (vizinho.Enabled == true && valorVizinho != -1)
                        {
                            vizinho.Text = valorVizinho.ToString();
                            vizinho.Enabled = false;

                            celulasReveladas++;

                            if (valorVizinho == 0)
                            {
                                revelarAdjacentes(x, y);
                            }
                        }
                    }
                }
            }
        }

        private void IniciarNovoJogo(int linhas, int colunas)
        {
            
            limparBotoes();

            celulasReveladas = 0;

            GerarCampo(linhas, colunas);
        }

        private void limparBotoes()
        {
            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                Control control = this.Controls[i];
                if ((control is Button && control.Tag is Point) || (control.Name == "Voltar" || control.Name == "Resetar"))
                {
                    this.Controls.Remove(control);
                    control.Dispose();
                }
            }
        }
    }
}
