using System.Media;

namespace Projeto1_JogoVelha
{
    public partial class Form1 : Form
    {
        private static Random random = new Random();
        private string player;
        private Color playerColor;
        private int counter = 0;
        private bool matchEnded = false;
        private string winner = "";
        private int contX = 0;
        private int contO = 0;
        Button[] vetorBotoes = new Button[9];
        private readonly List<Keys> numpadKeyCodes = new List<Keys>()
        {
            Keys.NumPad1,
            Keys.NumPad2,
            Keys.NumPad3,
            Keys.NumPad4,
            Keys.NumPad5,
            Keys.NumPad6,
            Keys.NumPad7,
            Keys.NumPad8,
            Keys.NumPad9
        };
        private readonly Dictionary<Keys, Button> buttons = new Dictionary<Keys, Button>();

        public Form1()
        {
            InitializeComponent();

            //player = random.Next(0, 2) == 1 ? "X" : "O";
            player = "X";
            playerColor = player == "X" ? Color.Red : Color.Blue;

            label2.Text = $"Jogador da Vez: {player}";

            vetorBotoes[0] = button1;
            vetorBotoes[1] = button2;
            vetorBotoes[2] = button3;
            vetorBotoes[3] = button4;
            vetorBotoes[4] = button5;
            vetorBotoes[5] = button6;
            vetorBotoes[6] = button7;
            vetorBotoes[7] = button8;
            vetorBotoes[8] = button9;

            buttons.Add(Keys.NumPad7, button1);
            buttons.Add(Keys.NumPad8, button2);
            buttons.Add(Keys.NumPad9, button3);
            buttons.Add(Keys.NumPad4, button4);
            buttons.Add(Keys.NumPad5, button5);
            buttons.Add(Keys.NumPad6, button6);
            buttons.Add(Keys.NumPad1, button7);
            buttons.Add(Keys.NumPad2, button8);
            buttons.Add(Keys.NumPad3, button9);

        }

        private void pcPlay()
        {
            List<Button> camposVazios = new List<Button>();

            for(int i = 0; i < 9; i++) 
            {
                if (vetorBotoes[i].Text == "") 
                {
                    camposVazios.Add(vetorBotoes[i]);
                }
            }

            if (camposVazios.Count > 0) 
            {
                int indiceAleatorio = random.Next(0, camposVazios.Count);

                Button botaoEscolhido = camposVazios[indiceAleatorio];

                botaoEscolhido.PerformClick();
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn != null && btn.Text == "")
            {
                SetButton(btn);
            }
        }

        private void NextPlayer()
        {
            if (player == "X")
            {
                player = "O";
                playerColor = Color.Blue;
                pcPlay();
            }
            else
            {
                player = "X";
                playerColor = Color.Red;
            }

            label2.Text = $"Jogador da Vez: {player}";

        }

        private void CheckWinner()
        {
            if (button1.Text != "" && button1.Text == button2.Text && button2.Text == button3.Text)
            {
                matchEnded = true;
                winner = button1.Text;
            }
            else if (button4.Text != "" && button4.Text == button5.Text && button5.Text == button6.Text)
            {
                matchEnded = true;
                winner = button4.Text;
            }
            else if (button7.Text != "" && button7.Text == button8.Text && button8.Text == button9.Text)
            {
                matchEnded = true;
                winner = button7.Text;
            }
            else if (button1.Text != "" && button1.Text == button4.Text && button4.Text == button7.Text)
            {
                matchEnded = true;
                winner = button1.Text;
            }
            else if (button2.Text != "" && button2.Text == button5.Text && button5.Text == button8.Text)
            {
                matchEnded = true;
                winner = button2.Text;
            }
            else if (button3.Text != "" && button3.Text == button6.Text && button6.Text == button9.Text)
            {
                matchEnded = true;
                winner = button3.Text;
            }
            else if (button1.Text != "" && button1.Text == button5.Text && button5.Text == button9.Text)
            {
                matchEnded = true;
                winner = button1.Text;
            }
            else if (button3.Text != "" && button3.Text == button5.Text && button5.Text == button7.Text)
            {
                matchEnded = true;
                winner = button3.Text;
            }
            else if (counter == 9)
            {
                matchEnded = true;
                winner = "";
            }

            if (matchEnded && winner != "")
            {
                MessageBox.Show($"Jogador: {player} ganhou!");
                if (winner == "X")
                {
                    contX++;
                    labelX.Text = $"X = {contX}";
                }
                else
                {
                    contO++;
                    labelO.Text = $"O = {contO}";
                }
                EndMatch();
            }
            else if (matchEnded && winner == "")
            {
                MessageBox.Show("Jogo deu velha!");
                EndMatch();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            EndMatch();
        }


        private void EndMatch()
        {
            counter = 0;
            matchEnded = false;
            winner = "";

            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";

            player = "X";
            playerColor = Color.Red;
            label2.Text = $"Jogador da Vez: {player}";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Button btn;

            if (numpadKeyCodes.Contains(e.KeyCode))
            {

                buttons.TryGetValue(e.KeyCode, out btn);

                if (btn != null && btn.Text == "")
                {
                    SetButton(btn);
                }
            }
        }

        private void SetButton(Button btn)
        {
            btn.Text = player;
            btn.ForeColor = playerColor;
            counter++;
            CheckWinner();
            if (!matchEnded)
            {
                NextPlayer();
            }
        }
    }
}
