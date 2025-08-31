namespace Termo
{
    public partial class Form1 : Form
    {
        private Button[,] matrizLogica = new Button[5, 5];
        private HashSet<Keys> charPermitidos = new HashSet<Keys>();
        private string palavraEscolhida = "";
        private char[] palavraAtual = new char[5];

        int linhaAtual = 0;
        int colunaAtual = 0;
        public Form1()
        {
            this.KeyPreview = true;

            InitializeComponent();
            CarregarBotoes();
            CarregarCharPermitidos();
            SelecionarPalavra();
            LimparPalavraAtual();
        }

        private void SelecionarPalavra()
        {
            string[] linhas = File.ReadAllLines("C:\\Users\\pedro\\OneDrive\\Área de Trabalho\\POE\\Termo\\palavras_filtradas_CincoLetras.txt");

            Random random = new Random();
            int IndiceAleatorio = random.Next(0, linhas.Length);

            palavraEscolhida = linhas[IndiceAleatorio];
            palavraEscolhida = linhas[IndiceAleatorio].ToUpper();

            //MessageBox.Show($"Palavra escolhida: {palavraEscolhida}");
        }

        private void LimparPalavraAtual()
        {
            for (int i = 0; i < 5; i++)
            {
                palavraAtual[i] = '\0'; // char nulo
            }
        }

        // Método para capturar enter
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && colunaAtual == 5)
            {
                if (linhaAtual < 5)
                {
                    CompararPalavras();
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void CarregarCharPermitidos()
        {
            for (int i = (int)Keys.A; i <= (int)Keys.Z; i++)
            {
                charPermitidos.Add((Keys)i);
            }
            charPermitidos.Add(Keys.Back);
            charPermitidos.Add(Keys.Enter);
            charPermitidos.Add(Keys.NumPad0 + 13);
        }

        private void CarregarBotoes()
        {
            List<Button> botoesMatriz = new List<Button>();

            foreach (Control control in this.Controls)
            {
                if (control is Button && control.Tag != null && control.Tag.ToString() == "buttonMatriz")
                {
                    botoesMatriz.Add((Button)control);
                }
            }

            botoesMatriz = botoesMatriz.OrderBy(b => b.Location.Y).ThenBy(b => b.Location.X).ToList();

            int contador = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                        matrizLogica[i, j] = botoesMatriz[contador];
                        contador++;
                }
            }
        }

        private void CompararPalavras()
        {
            char[] palavraCorretaTemp = palavraEscolhida.ToCharArray();
            bool acertou = true;

            for (int i = 0; i < 5; i++)
            {
                if (palavraAtual[i] == palavraCorretaTemp[i])
                {
                    matrizLogica[linhaAtual, i].BackColor = Color.Green;
                    palavraCorretaTemp[i] = '\0';
                }
                else
                {
                    acertou = false;
                }
            }

            if (!acertou)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (matrizLogica[linhaAtual, i].BackColor != Color.Green)
                    {
                        bool letraEncontrada = false;
                        for (int j = 0; j < 5; j++)
                        {
                            if (palavraAtual[i] == palavraCorretaTemp[j])
                            {
                                matrizLogica[linhaAtual, i].BackColor = Color.Yellow;
                                palavraCorretaTemp[j] = '\0';
                                letraEncontrada = true;
                                break;
                            }
                        }

                        if (!letraEncontrada)
                        {
                            matrizLogica[linhaAtual, i].BackColor = Color.Gray;
                        }
                    }
                }
            }

            if (acertou)
            {
                MessageBox.Show("Parabéns! Você acertou!");
            }
            else
            {
                linhaAtual++;
                if (linhaAtual >= 5)
                {
                    MessageBox.Show($"Fim de jogo! A palavra era: {palavraEscolhida}");
                }
            }

            colunaAtual = 0;
            LimparPalavraAtual();
        }

        private void eventoTeclar(object sender, KeyEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"Tecla pressionada: {e.KeyCode}");

            if (!charPermitidos.Contains(e.KeyCode) || linhaAtual >= 5)
                return;

            // apertar backspace
            if (e.KeyCode == Keys.Back)
            {
                if(colunaAtual > 0)
                {
                    colunaAtual--;
                    Button botaoAtual = matrizLogica[linhaAtual, colunaAtual];
                    botaoAtual.Text = "";
                    palavraAtual[colunaAtual] = '\0';
                }
                e.Handled = true;
                return;
            }

            // apertar enter
            /*if(e.KeyCode == Keys.Enter)
            {
                System.Diagnostics.Debug.WriteLine($"Enter detectado! Coluna atual: {colunaAtual}");
                if (colunaAtual == 5)
                {
                    CompararPalavras();
                    linhaAtual++;
                    colunaAtual = 0;
                    LimparPalavraAtual();
                    System.Diagnostics.Debug.WriteLine($"Passando para linha: {linhaAtual}");
                }
                e.Handled = true;
                return;
            }*/

            if (colunaAtual < 5) 
            {
                Button botaoAtual = matrizLogica[linhaAtual, colunaAtual];
                char letra = e.KeyCode.ToString()[0];
                botaoAtual.Text = letra.ToString();
                palavraAtual[colunaAtual] = letra;
                colunaAtual++;
                e.Handled = true;
            }
        }
    }
}
