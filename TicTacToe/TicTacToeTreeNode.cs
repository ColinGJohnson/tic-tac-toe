using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class TicTacToeTreeNode
    {
        public bool Explored { get; set; }

        public TileContent CurrentTurn { get; set; }

        public int MiniMaxScore { get; set; }

        public (int winning, int losing, int draw) SubtreeStats { get; set; }

        public TicTacToeBoard Board { get; set; }

        public List<TicTacToeTreeNode> Children { get; }

        public TicTacToeTreeNode(TicTacToeBoard board, TileContent currentTurn)
        {
            Explored = false;
            Board = board;
            CurrentTurn = currentTurn;
            Children = new List<TicTacToeTreeNode>();
        }

        public TileContent getNextTurnPlayer()
        {
            if (CurrentTurn == TileContent.PlayerOne)
            {
                return TileContent.PlayerTwo;
            }
            return TileContent.PlayerOne;
        }

        public bool IsLeaf()
        {
            if (!Explored)
            {
                throw new InvalidOperationException("Node is not explored");
            }

            return Children.Count == 0;
        }
    }
}
