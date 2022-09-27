using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemoryGameUI
{
    public class Player
    {
        private String m_PlayerName;
        private int m_PlayerScore;

        public Player(string i_PlayerName)
        {
            m_PlayerName = i_PlayerName;
            m_PlayerScore = 0;
        }

        public String PlayerName
        {
            get { return m_PlayerName; }
            set { m_PlayerName = value; }
        }

        public int PlayerScore
        {
            get { return m_PlayerScore; }
            set { m_PlayerScore = value; }
        }

        internal void RaiseScore()
        {
            m_PlayerScore++;
        }

    }
}
