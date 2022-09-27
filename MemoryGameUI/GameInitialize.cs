using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemoryGameUI
{
    public class GameInitialize
    {
        public GameInitialize()
        {
            PlayerSettings loginForm = new PlayerSettings();

            loginForm.ShowDialog();

            GameBoard gameBoard = new GameBoard(loginForm);

            bool checkIfPressedStart = loginForm.ClickedOnStart;

            if (checkIfPressedStart)
            {
                gameBoard.ShowDialog();
            }

            while (gameBoard.CheckIfWantToPlayAgain)
            {
                gameBoard = new GameBoard(loginForm);
                gameBoard.ShowDialog();
            }
        }

    }
}
