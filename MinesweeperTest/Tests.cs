using Minesweeper;

namespace MinesweeperTest;

[TestClass]
public class Tests
{
	[TestMethod]
    public void ErrorWasThrowWhenOutsideBoard()
    {
			// Arrange
			int boardSize = 5;
			Game game = new Game(boardSize, 5);

			// Act
			bool testErrorHandling = game.CheckUserInput("99");

			// Assert
			Assert.IsTrue(testErrorHandling);
    }

		[TestMethod]
    public void EndGameIfBombwasFound()
    {
			// Arrange
			Game game = new Game(5, 5);

			// Act
			Cell newCell = new Cell(true, true, 0);
			game.Minefield.Cells[0, 0] = newCell;

			// Assert
			Assert.IsFalse(game.IsGameOn());
    }

		[TestMethod]
    public void NumberOfMinesIsEqualToAsIniziated()
    {
			// Arrange
			int numberOfMines = 5;
			int boardSize = 5;
			Game game = new Game(boardSize, numberOfMines);

			// Act
			int testNumerOfMines = (boardSize * boardSize) - game.NumberOfEmptyCells;

			// Assert
			Assert.IsTrue(testNumerOfMines == numberOfMines);
    }
}
