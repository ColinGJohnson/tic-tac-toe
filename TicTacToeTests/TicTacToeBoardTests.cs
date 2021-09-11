using NUnit.Framework;

namespace TicTacToe.Tests
{
    [TestFixture()]
    public class TicTacToeBoardTests
    {
        [Test()]
        public void CheckWinTest()
        {
            // boards with no winners
            TicTacToeBoard emptyBoard = new TicTacToeBoard();
            Assert.False(emptyBoard.CheckWin(TileContent.PlayerOne));
            Assert.False(emptyBoard.CheckWin(TileContent.PlayerTwo));

            TicTacToeBoard CornersOnly = new TicTacToeBoard(new TileContent[3, 3] {
                { TileContent.PlayerOne, TileContent.Empty,  TileContent.PlayerOne },
                { TileContent.Empty, TileContent.Empty,  TileContent.Empty },
                { TileContent.PlayerOne, TileContent.Empty,  TileContent.PlayerOne }
            });
            Assert.False(CornersOnly.CheckWin(TileContent.PlayerOne));
            Assert.False(CornersOnly.CheckWin(TileContent.PlayerTwo));

            TicTacToeBoard edgesOnly = new TicTacToeBoard(new TileContent[3, 3] {
                { TileContent.Empty, TileContent.PlayerOne,  TileContent.Empty },
                { TileContent.PlayerOne, TileContent.Empty,  TileContent.PlayerOne },
                { TileContent.Empty, TileContent.PlayerOne,  TileContent.Empty }
            });
            Assert.False(CornersOnly.CheckWin(TileContent.PlayerOne));
            Assert.False(CornersOnly.CheckWin(TileContent.PlayerTwo));

            // check horizontal/vertical win
            TicTacToeBoard horizontalWin = new TicTacToeBoard(new TileContent[3, 3] {
                { TileContent.Empty, TileContent.Empty,  TileContent.Empty },
                { TileContent.Empty, TileContent.Empty,  TileContent.Empty },
                { TileContent.PlayerOne, TileContent.PlayerOne,  TileContent.PlayerOne }
            });
            Assert.True(horizontalWin.CheckWin(TileContent.PlayerOne));
            Assert.False(horizontalWin.CheckWin(TileContent.PlayerTwo));

            // check diagonal wins
            TicTacToeBoard leftDiagonalWin = new TicTacToeBoard(new TileContent[3, 3] {
                { TileContent.Empty, TileContent.Empty,  TileContent.PlayerOne },
                { TileContent.Empty, TileContent.PlayerOne,  TileContent.Empty },
                { TileContent.PlayerOne, TileContent.Empty,  TileContent.Empty }
            });
            Assert.True(leftDiagonalWin.CheckWin(TileContent.PlayerOne));
            Assert.False(leftDiagonalWin.CheckWin(TileContent.PlayerTwo));

            TicTacToeBoard rightDiagonalWin = new TicTacToeBoard(new TileContent[3, 3] {
                { TileContent.PlayerOne, TileContent.Empty,  TileContent.Empty },
                { TileContent.Empty, TileContent.PlayerOne,  TileContent.Empty },
                { TileContent.Empty, TileContent.Empty,  TileContent.PlayerOne }
            });
            Assert.True(leftDiagonalWin.CheckWin(TileContent.PlayerOne));
            Assert.False(leftDiagonalWin.CheckWin(TileContent.PlayerTwo));
        }
    }
}
