using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MemoryGameUI
{
    class PlayerSettings : Form
    {
        private Label m_FirstPlayerLabel = new Label();
        private Label m_SecondPLayerLabel = new Label();
        private Label m_BoardSizeLabel = new Label();

        private TextBox m_FirstPlayerTextBox = new TextBox();
        private TextBox m_SecondPlayerTextBox = new TextBox();

        private Button m_AgainstFriendButton = new Button();
        private Button m_BoardButton = new Button();
        private Button m_ButtonStart = new Button();

        private bool m_AgaintComputer = true;
        private bool m_ClickOnStart = false;

        private int m_NumberOfRows = 0;
        private int m_NumberOfcolumns = 0;
        private int m_ChoosenBoardSize = 0;

        public PlayerSettings()
        {
            this.Text = "Setting Form";
            this.Size = new Size(400, 270);
            this.Location = new Point(0, 0);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(180, 180, 180);
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;

            formControl();
        }


        private void formControl()
        {
            firstPlayerSetting();

            secondPlayerSetting();

            choosenOppnenButtonSetting();

            gameBoardSetting();

            startTheGameButton();

            this.Controls.AddRange(new Control[] { m_FirstPlayerLabel, m_FirstPlayerTextBox,
                                                   m_SecondPLayerLabel, m_SecondPlayerTextBox,
                                                   m_AgainstFriendButton, m_BoardSizeLabel,
                                                   m_BoardButton, m_ButtonStart });
        }

        private void firstPlayerSetting()
        {
            m_FirstPlayerLabel.Text = "First Player Name:";
            m_FirstPlayerLabel.Location = new Point(20, 20);

            int textBoxTop = m_FirstPlayerLabel.Top + m_FirstPlayerLabel.Height / 2;
            textBoxTop -= m_FirstPlayerTextBox.Height / 2;

            m_FirstPlayerTextBox.Location = new Point(m_FirstPlayerLabel.Right + 15, textBoxTop);
        }

        private void secondPlayerSetting()
        {
            m_SecondPLayerLabel.Text = "Second Player name:";
            m_SecondPLayerLabel.Width = 115;
            m_SecondPLayerLabel.Location = new Point(m_FirstPlayerLabel.Location.X, m_FirstPlayerLabel.Location.Y + 30);

            m_SecondPlayerTextBox.Location = new Point(m_FirstPlayerTextBox.Location.X, m_SecondPLayerLabel.Location.Y);
        }

        private void choosenOppnenButtonSetting()
        {
            m_AgainstFriendButton.Location = new Point(m_SecondPlayerTextBox.Right + 10, m_SecondPlayerTextBox.Location.Y);
            m_AgainstFriendButton.Width = 115;
            m_AgainstFriendButton.Text = "Againt Friend";
            this.m_AgainstFriendButton.Click += new EventHandler(m_AgainstFriendButton_Click);
            againtComputerSettings();
        }

        private void againtComputerSettings()
        {
            m_SecondPlayerTextBox.Enabled = false;
            m_SecondPlayerTextBox.BackColor = Color.LightGray;
            m_SecondPlayerTextBox.Text = "Computer";
        }

        void m_AgainstFriendButton_Click(object sender, EventArgs e)
        {
            if (m_AgaintComputer)
            {
                m_AgainstFriendButton.Text = "Againt Computer";
                m_SecondPlayerTextBox.Enabled = true;
                m_SecondPlayerTextBox.BackColor = Color.White;
                m_SecondPlayerTextBox.Text = "";
                m_AgaintComputer = false;
            }
            else
            {
                againtComputerSettings();
                m_AgainstFriendButton.Text = "Againt Friend";
                m_AgaintComputer = true;
            }
        }

        private void gameBoardSetting()
        {
            m_BoardSizeLabel.Text = "Board Size";
            m_BoardSizeLabel.Location = new Point(m_SecondPLayerLabel.Location.X, m_SecondPLayerLabel.Location.Y + 50);

            this.m_BoardButton.Click += new EventHandler(BoardSizeButton_Click);
            m_BoardButton.Location = new Point(m_BoardSizeLabel.Location.X, m_BoardSizeLabel.Location.Y + 25);
            m_BoardButton.Width = 100;
            m_BoardButton.Height = 85;
            int boarderSize = 15;
            m_BoardButton.Font = new Font(m_BoardButton.Font.FontFamily, boarderSize);
            m_BoardButton.FlatStyle = FlatStyle.Flat;
            m_BoardButton.FlatAppearance.BorderColor = Color.Black;
            m_BoardButton.FlatAppearance.BorderSize = 3;

            boardSizeSwitchCase();

        }

        void BoardSizeButton_Click(object sender, EventArgs e)
        {
            m_ChoosenBoardSize++;

            //MessageBox.Show(String.Format("{0}", m_ChoosenBoardSize));
            //MessageBox.Show(String.Format("{0},{1}", m_NumberOfRows, m_NumberOfcolumns));

            boardSizeSwitchCase();
        }

        private void boardSizeSwitchCase()
        {
            switch (m_ChoosenBoardSize)
            {
                case 0:
                    NumberOfRows = 4;
                    NumberOfColumn = 4;
                    m_BoardButton.Text = String.Format("{0}x{1}", m_NumberOfRows, m_NumberOfcolumns);
                    m_BoardButton.BackColor = Color.LightBlue;
                    break;
                case 1:
                    NumberOfRows = 4;
                    NumberOfColumn = 5;
                    m_BoardButton.Text = String.Format("{0}x{1}", m_NumberOfRows, m_NumberOfcolumns);
                    break;
                case 2:
                    NumberOfRows = 4;
                    NumberOfColumn = 6;
                    m_BoardButton.Text = String.Format("{0}x{1}", m_NumberOfRows, m_NumberOfcolumns);
                    break;
                case 3:
                    NumberOfRows = 5;
                    NumberOfColumn = 4;
                    m_BoardButton.Text = String.Format("{0}x{1}", m_NumberOfRows, m_NumberOfcolumns);
                    m_BoardButton.BackColor = Color.LightGreen;
                    break;
                case 4:
                    NumberOfRows = 5;
                    NumberOfColumn = 6;
                    m_BoardButton.Text = String.Format("{0}x{1}", m_NumberOfRows, m_NumberOfcolumns);
                    break;
                case 5:
                    NumberOfRows = 6;
                    NumberOfColumn = 4;
                    m_BoardButton.Text = String.Format("{0}x{1}", m_NumberOfRows, m_NumberOfcolumns);
                    m_BoardButton.BackColor = Color.LightSalmon;
                    break;
                case 6:
                    NumberOfRows = 6;
                    NumberOfColumn = 5;
                    m_BoardButton.Text = String.Format("{0}x{1}", m_NumberOfRows, m_NumberOfcolumns);
                    break;
                case 7:
                    NumberOfRows = 6;
                    NumberOfColumn = 6;
                    m_BoardButton.Text = String.Format("{0}x{1}", m_NumberOfRows, m_NumberOfcolumns);
                    m_ChoosenBoardSize = -1;
                    break;
            }
        }

        private void startTheGameButton()
        {
            m_ButtonStart.Text = "Start!";
            m_ButtonStart.BackColor = Color.LightGreen;

            m_ButtonStart.Location = new Point(m_AgainstFriendButton.Location.X + 20, m_BoardButton.Location.Y + 40);

            m_ButtonStart.Click += new EventHandler(StartButton_Click);
        }

        void StartButton_Click(object sender, EventArgs e)
        {
            m_ClickOnStart = true;
            this.Close();
        }



        public String FirstPlayerName
        {
            get { return m_FirstPlayerTextBox.Text; }
            set { m_FirstPlayerLabel.Text = value; }
        }

        public String SecondPlayerName
        {
            get { return m_SecondPlayerTextBox.Text; }
            set { m_SecondPLayerLabel.Text = value; }
        }

        public bool ClickedOnStart
        {
            get { return m_ClickOnStart; }
        }

        public bool IsAgaintsComputer
        {
            get { return m_AgaintComputer; }
        }

        public int NumberOfRows
        {
            get { return m_NumberOfRows; }
            set { m_NumberOfRows = value; }
        }
        public int NumberOfColumn
        {
            get { return m_NumberOfcolumns; }
            set { m_NumberOfcolumns = value; }
        }

        public int ChoosenBoardSize
        {
            get { return m_ChoosenBoardSize; }
        }

    }
}
