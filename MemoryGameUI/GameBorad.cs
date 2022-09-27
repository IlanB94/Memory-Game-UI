using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MemoryGameUI
{
    class GameBoard : Form
    {
        private PlayerSettings m_PlayerSetting;
        private PlayAgainForm m_PlayAgainForm = new PlayAgainForm();

        private Player m_PlayerOne;
        private Player m_PlayerTwo;

        private Card[] m_ArrayOfCards;

        private int m_FirstCardIndex = -1;
        private int m_SecondCardIndex = -1;

        private int m_TotalAmountOfCards;
        private int m_NumberOfColumn;
        private int m_NumberOfRows;
        private int m_TotalAmountOfMatchCards = 0;
        private int m_CounterOfPickedCards = 0;

        private bool m_PlayerOneTurn = true;
        private bool m_Winner = false;
        private bool m_PlayAgain = false;

        private char[] m_RandomCharArray;

        private Label m_LabelCurrentPlayer = new Label();
        private Label m_LabelPlayerOne = new Label();
        private Label m_LabelPlayerTwo = new Label();


        public GameBoard(PlayerSettings i_LoginForm)
        {
            m_PlayerSetting = i_LoginForm;

            this.Text = "Memory Game";
            this.Size = new Size(m_PlayerSetting.NumberOfColumn * 115, m_PlayerSetting.NumberOfRows * 140);
            this.Location = new Point(0, 0);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;

            gameBoardManager();
        }

        private void gameBoardManager()
        {
            fillingTheCardArray();
            printCardOnBoard();
            settingPlayersDetail();
        }


        private void gameProcess()
        {
            if (m_PlayerOneTurn)
            {
                m_LabelCurrentPlayer.BackColor = Color.LightGreen;
                if (m_CounterOfPickedCards == 2)
                {

                    if (!checkMatchedValues())
                    {
                        notMatchMassage();

                        m_ArrayOfCards[m_FirstCardIndex].Text = "";
                        m_ArrayOfCards[m_FirstCardIndex].BackColor = Color.WhiteSmoke;
                        m_ArrayOfCards[m_SecondCardIndex].Text = "";
                        m_ArrayOfCards[m_SecondCardIndex].BackColor = Color.WhiteSmoke;
                    }

                    m_ArrayOfCards[m_FirstCardIndex].IsRevealed = false;
                    m_ArrayOfCards[m_SecondCardIndex].IsRevealed = false;

                    m_LabelCurrentPlayer.BackColor = Color.LightSkyBlue;
                    m_PlayerOneTurn = false;
                    m_CounterOfPickedCards = 0;

                }
            }
            else
            {
                m_LabelCurrentPlayer.BackColor = Color.LightSkyBlue;
                if (m_CounterOfPickedCards == 2)
                {

                    if (!checkMatchedValues())
                    {
                        notMatchMassage();

                        m_ArrayOfCards[m_FirstCardIndex].Text = "";
                        m_ArrayOfCards[m_FirstCardIndex].BackColor = Color.WhiteSmoke;
                        m_ArrayOfCards[m_SecondCardIndex].Text = "";
                        m_ArrayOfCards[m_SecondCardIndex].BackColor = Color.WhiteSmoke;
                    }

                    m_ArrayOfCards[m_FirstCardIndex].IsRevealed = false;
                    m_ArrayOfCards[m_SecondCardIndex].IsRevealed = false;

                    m_LabelCurrentPlayer.BackColor = Color.LightGreen;
                    m_PlayerOneTurn = true;
                    m_CounterOfPickedCards = 0;
                }
            }

            if (m_TotalAmountOfMatchCards >= m_TotalAmountOfCards / 2)
            {
                m_Winner = true;
            }
        }


        private void settingPlayersDetail()
        {
            m_PlayerOne = new Player(m_PlayerSetting.FirstPlayerName);
            m_PlayerTwo = new Player(m_PlayerSetting.SecondPlayerName);

            settingLabels();

            this.Controls.Add(m_LabelCurrentPlayer);
            this.Controls.Add(m_LabelPlayerOne);
            this.Controls.Add(m_LabelPlayerTwo);

        }

        private void settingLabels()
        {
            m_LabelCurrentPlayer.Location = new Point(m_ArrayOfCards[m_ArrayOfCards.Length - m_NumberOfColumn].Location.X, m_ArrayOfCards[m_ArrayOfCards.Length - m_NumberOfColumn].Location.Y + 100);
            m_LabelCurrentPlayer.Width = 150;

            m_LabelPlayerOne.BackColor = Color.LightGreen;
            m_LabelPlayerOne.Location = new Point(m_LabelCurrentPlayer.Location.X, m_LabelCurrentPlayer.Location.Y + 30);
            m_LabelPlayerOne.Width = 150;

            m_LabelPlayerTwo.BackColor = Color.LightSkyBlue;
            m_LabelPlayerTwo.Location = new Point(m_LabelPlayerOne.Location.X, m_LabelPlayerOne.Location.Y + 30);
            m_LabelPlayerTwo.Width = 150;

            updateCurrentScore();
        }

        private void updateCurrentScore()
        {
            if (m_PlayerOneTurn)
            {
                m_LabelCurrentPlayer.Text = String.Format("player turn - {0}", m_PlayerOne.PlayerName);
            }
            else
            {
                m_LabelCurrentPlayer.Text = String.Format("player turn - {0}", m_PlayerTwo.PlayerName);
            }

            m_LabelPlayerOne.Text = String.Format("{0}, score: {1}", m_PlayerOne.PlayerName, m_PlayerOne.PlayerScore);

            m_LabelPlayerTwo.Text = String.Format("{0}, score: {1}", m_PlayerTwo.PlayerName, m_PlayerTwo.PlayerScore);
        }



        private void fillingTheCardArray()
        {
            int setRowAndColumn = m_PlayerSetting.ChoosenBoardSize;

            m_NumberOfRows = m_PlayerSetting.NumberOfRows;
            m_NumberOfColumn = m_PlayerSetting.NumberOfColumn;

            m_TotalAmountOfCards = m_NumberOfRows * m_NumberOfColumn;

            m_ArrayOfCards = new Card[m_TotalAmountOfCards];

            m_RandomCharArray = randomizeArrayValueMaker(m_NumberOfRows, m_NumberOfColumn);

            char[] mixedRandomCharArray = fillCellsValue(m_RandomCharArray);


            for (int i = 0; i < m_TotalAmountOfCards; i++)
            {
                m_ArrayOfCards[i] = new Card();
                m_ArrayOfCards[i].Width = 75;
                m_ArrayOfCards[i].Height = 75;
                m_ArrayOfCards[i].CardLocation = i;
                m_ArrayOfCards[i].CardValue = mixedRandomCharArray[i].ToString();
                int boarderSize = 15;
                m_ArrayOfCards[i].Font = new Font(m_ArrayOfCards[i].Font.FontFamily, boarderSize);
                m_ArrayOfCards[i].FlatStyle = FlatStyle.Flat;
                m_ArrayOfCards[i].FlatAppearance.BorderColor = Color.Black;
                m_ArrayOfCards[i].FlatAppearance.BorderSize = 3;
                this.m_ArrayOfCards[i].Click += new EventHandler(pickedCard_Click);

                //Show the value of the card
                //m_ArrayOfCards[i].Text = m_ArrayOfCards[i].CardValue;
            }
        }

        private void printCardOnBoard()
        {
            for (int i = 0; i < m_TotalAmountOfCards; i++)
            {
                if (i == 0)
                {
                    m_ArrayOfCards[i].Location = new Point(20, 20);
                }
                else
                {
                    if (i % m_NumberOfColumn == 0)
                    {
                        m_ArrayOfCards[i].Location = new Point(m_ArrayOfCards[0].Location.X, m_ArrayOfCards[i - m_NumberOfColumn].Location.Y + 100);
                    }
                    else
                    {
                        m_ArrayOfCards[i].Location = new Point(m_ArrayOfCards[i - 1].Location.X + 100, m_ArrayOfCards[i - 1].Location.Y);
                    }
                }

                this.Controls.Add(m_ArrayOfCards[i]);
            }
        }


        private void pickedCard_Click(object sender, EventArgs e)
        {
            if (!((Card)sender).IsRevealed)
            {
                ((Card)sender).Text = ((Card)sender).CardValue;
                ((Card)sender).IsRevealed = true;
                m_CounterOfPickedCards++;

                if (m_PlayerOneTurn)
                {
                    ((Card)sender).BackColor = Color.LightGreen;
                }
                else
                {
                    ((Card)sender).BackColor = Color.LightSkyBlue;
                }
            }


            if (m_CounterOfPickedCards == 1)
            {
                m_FirstCardIndex = ((Card)sender).CardLocation;
            }
            else if (m_CounterOfPickedCards == 2)
            {
                m_SecondCardIndex = ((Card)sender).CardLocation;
            }

            gameProcess();
            updateCurrentScore();
            checkWinner();

        }


        private bool checkMatchedValues()
        {
            bool foundMatch = false;
            if (m_ArrayOfCards[m_FirstCardIndex].CardValue == m_ArrayOfCards[m_SecondCardIndex].CardValue)
            {
                foundMatch = true;

                if (m_PlayerOneTurn)
                {
                    m_PlayerOne.PlayerScore++;
                }
                else
                {
                    m_PlayerTwo.PlayerScore++;
                }

                m_TotalAmountOfMatchCards++;

                m_ArrayOfCards[m_FirstCardIndex].Enabled = false;
                m_ArrayOfCards[m_SecondCardIndex].Enabled = false;
            }
            return foundMatch;
        }

        private void notMatchMassage()
        {
            MessageBox.Show(String.Format("not a match,\nfirst card: {0}\nsecond card: {1}", m_ArrayOfCards[m_FirstCardIndex].CardValue, m_ArrayOfCards[m_SecondCardIndex].CardValue));
        }


        private void checkWinner()
        {
            if (m_Winner)
            {
                if (m_PlayerOne.PlayerScore == m_PlayerTwo.PlayerScore)
                {
                    MessageBox.Show(String.Format("its a tie! score: {0}", m_PlayerOne.PlayerScore));
                }
                else if (m_PlayerOne.PlayerScore > m_PlayerTwo.PlayerScore)
                {
                    MessageBox.Show(String.Format("player {0} is the winner! score: {1} ", m_PlayerOne.PlayerName, m_PlayerOne.PlayerScore));
                }
                else
                {
                    MessageBox.Show(String.Format("player {0} is the winner! score: {1} ", m_PlayerTwo.PlayerName, m_PlayerTwo.PlayerScore));
                }


                checkToPlayAgain();
                CheckIfWantToPlayAgain = m_PlayAgainForm.WantToPlayAgain;
                this.Close();
            }
        }

        private void checkToPlayAgain()
        {
            m_PlayAgainForm.ShowDialog();
        }

        private char[] randomizeArrayValueMaker(int i_rows, int i_columns)
        {
            int totalNumberOfChars = (i_rows * i_columns);
            int pickedValue = 0;

            int currectPlaceOfTheLoop = 0;
            int inputIndex = 0;

            double theRandomValue = 0;

            Random randomValue = new Random();

            char[] arrayOfChosenCharacters = new char[totalNumberOfChars * 2];
            char[] chackIfPickedAgain = new char[totalNumberOfChars];


            while (currectPlaceOfTheLoop < totalNumberOfChars)
            {
                bool checkIfCantContinue = false;
                bool checkIfDuplicate = false;

                theRandomValue = randomValue.NextDouble();
                if (theRandomValue > 0.5)
                {
                    pickedValue = randomValue.Next(65, 91);
                }
                else
                {
                    pickedValue = randomValue.Next(97, 123);
                }

                char pickedLetter = Convert.ToChar(pickedValue);

                for (int i = 0; i < chackIfPickedAgain.Length; i++)
                {
                    if (chackIfPickedAgain[i] == pickedLetter)
                    {
                        checkIfDuplicate = true;
                        checkIfCantContinue = true;
                        break;
                    }
                }

                if (checkIfDuplicate == false)
                {
                    arrayOfChosenCharacters[inputIndex] = pickedLetter;
                    arrayOfChosenCharacters[inputIndex + 1] = pickedLetter;

                    inputIndex = inputIndex + 2;
                }

                if (checkIfCantContinue == false)
                {
                    currectPlaceOfTheLoop++;
                }
            }
            return arrayOfChosenCharacters;
        }

        private char[] fillCellsValue(char[] i_RandomCharValue)
        {
            char[] mixRandomCharValue = new char[i_RandomCharValue.Length];

            bool[] checkIfRandomValueIsAvailable = new bool[m_TotalAmountOfCards];

            int counterFilledCards = 0;
            int GetFreeRandomValue = 0;

            Random GenerateRandomValue = new Random();


            while (counterFilledCards != checkIfRandomValueIsAvailable.Length)
            {
                GetFreeRandomValue = GenerateRandomValue.Next(0, m_TotalAmountOfCards);

                if (checkIfRandomValueIsAvailable[GetFreeRandomValue] == false)
                {
                    checkIfRandomValueIsAvailable[GetFreeRandomValue] = true;

                    mixRandomCharValue[counterFilledCards] = i_RandomCharValue[GetFreeRandomValue];

                    counterFilledCards++;
                }
            }

            return mixRandomCharValue;
        }


        public bool CheckIfWantToPlayAgain
        {
            get { return m_PlayAgain; }
            set { m_PlayAgain = value; }
        }

    }
}
