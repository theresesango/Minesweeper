using System.IO.Compression;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Minesweeper;

public class MinesweeperGame
{
  static void Main()
	{
		Console.WriteLine("Welcome To Minesweeper!");

		// Start a new game
		int boardSize = 10; 
		int numberOfMines = 5;
		
		Game game = new Game(boardSize, numberOfMines);
		game.Run();

		Console.WriteLine("Thank you for playing! :) ");
	}
}
