using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MemoryGameUI
{
    class PlayAgainForm : Form
    {
        Button m_ButtonYes = new Button();
        Button m_ButtonNo = new Button();

        private bool m_WantToPlayAgain = false;

        public PlayAgainForm()
        {
            this.Text = "play again";
            this.Size = new Size(200, 100);
            this.StartPosition = FormStartPosition.CenterParent;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;

            buttonControl();
        }

        private void buttonControl()
        {
            yesButton();
            noButton();

            this.Controls.AddRange(new Control[] { m_ButtonYes, m_ButtonNo });
        }

        private void yesButton()
        {
            m_ButtonYes.Text = "Yes";

            m_ButtonYes.Location = new Point(20, 20);

            m_ButtonYes.Click += new EventHandler(YesButton_Click);
        }

        void YesButton_Click(object sender, EventArgs e)
        {
            m_WantToPlayAgain = true;
            this.Close();
        }

        private void noButton()
        {
            m_ButtonNo.Text = "No";

            m_ButtonNo.Location = new Point(100, 20);

            m_ButtonNo.Click += new EventHandler(NoButton_Click);
        }

        void NoButton_Click(object sender, EventArgs e)
        {
            m_WantToPlayAgain = false;
            this.Close();
        }

        public bool WantToPlayAgain
        {
            get { return m_WantToPlayAgain; }
            set { m_WantToPlayAgain = value; }
        }

    }
}
