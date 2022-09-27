using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MemoryGameUI
{
    class Card : Button
    {
        private bool m_IsRevealed = false;
        private bool m_FoundMatch = false;

        private String m_CardValue = "";

        private int m_CardLocationInTheArray;

        public bool IsRevealed
        {
            get { return m_IsRevealed; }
            set { m_IsRevealed = value; }
        }

        public bool IsFoundMatch
        {
            get { return m_FoundMatch; }
            set { m_FoundMatch = value; }
        }

        public String CardValue
        {
            get { return m_CardValue; }
            set { m_CardValue = value; }
        }

        public int CardLocation
        {
            get { return m_CardLocationInTheArray; }
            set { m_CardLocationInTheArray = value; }
        }

    }
}
