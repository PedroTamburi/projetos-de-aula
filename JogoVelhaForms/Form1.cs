using System.Media;

namespace Projeto1_JogoVelha
{
    public partial class Form1 : Form
    {
        private static Random computerPlayerRandom = new Random();
        private PlayerType playerType;
        private int computerChoice;
        private string player;
        private Color playerColor;
        private int counter = 0;
        private bool isMatchStarted = false;
        private bool matchEnded = false;
        private string winner = "";
        private int contX = 0;
        private int contO = 0;

        private readonly Dictionary<Keys, Button> buttons = new Dictionary<Keys, Button>();
        private readonly Button[] buttonsList = new Button[9];

        public Form1()
        {
            this.KeyPreview = true;

            InitializeComponent();

            player = "X";
            playerColor = Color.Red;

            label2.Text = $"Jogador da Vez: {player}";

            // Start game with Human oponent
            playerType = PlayerType.Human;
            button11.BackColor = Color.DodgerBlue;
            button12.BackColor = Color.White;

            buttonsList[0] = button1;
            buttonsList[1] = button2;
            buttonsList[2] = button3;
            buttonsList[3] = button4;
            buttonsList[4] = button5;
            buttonsList[5] = button6;
            buttonsList[6] = button7;
            buttonsList[7] = button8;
            buttonsList[8] = button9;

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

        private void button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn != null && btn.Text == "")
            {
                SetButton(btn);

                if (playerType.Equals(PlayerType.Computer))
                {
                    do
                    {
                        computerChoice = computerPlayerRandom.Next(0, 9);

                        btn = buttonsList[computerChoice];

                    } while (btn.Text != "");


                    if (isMatchStarted)
                    {
                        SetButton(btn);
                    }
                }
            }
        }

        private void NextPlayer()
        {
            if (player == "X")
            {
                player = "O";
                playerColor = Color.Blue;
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
            isMatchStarted = false;
            winner = "";

            player = "X";
            playerColor = Color.Red;
            label2.Text = $"Jogador da Vez: {player}";

            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Button? btn;

            if (buttons.TryGetValue(e.KeyCode, out btn)
                && btn != null && btn.Text == "")
            {
                SetButton(btn);
            }
        }

        private void SetButton(Button btn)
        {
            btn.Text = player;
            btn.ForeColor = playerColor;
            counter++;
            isMatchStarted = true;
            CheckWinner();

            if (isMatchStarted)
                NextPlayer();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (isMatchStarted)
            {
                MessageBox.Show("Você deve esperar a partida acabar para selecionar tipo de oponente!");
                return;
            }

            playerType = playerType.Equals(PlayerType.Human) ?
                PlayerType.Computer : PlayerType.Human;

            button11.BackColor = Color.DodgerBlue;
            button12.BackColor = Color.White;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (isMatchStarted)
            {
                MessageBox.Show("Você deve esperar a partida acabar para selecionar tipo de oponente!");
                return;
            }

            playerType = playerType.Equals(PlayerType.Computer) ?
                PlayerType.Human : PlayerType.Computer;

            button11.BackColor = Color.White;
            button12.BackColor = Color.DodgerBlue;
        }
    }
}
