using System;

namespace Minesweeper
{
	public class Game
	{
		public int BoardSize { get; set; }
		public int NumberOfMines { get; set; }
		public Minefield Minefield { get; set; }
		public int TargetColumn { get; set; }
		public int TargetRow { get; set; }
		public int NumberOfVisitedCells { get; set; }
		public int NumberOfEmptyCells { get; set; }

		public Game(int boardSize, int numberOfMines) {
			BoardSize = boardSize;
			NumberOfMines = numberOfMines;
			Minefield = new Minefield(BoardSize, NumberOfMines);
			TargetColumn = -1;
			TargetRow = -1;
			NumberOfVisitedCells = 0;
			NumberOfEmptyCells = Minefield.Cells.Length - NumberOfMines;
 		}

		public void Run()
		{
			Initialize();
			do
			{
				string? userInputTarget = UserInput();
				CheckUserInput(userInputTarget);
				SetVisitedCells();
				RenderBoard();
			}
			while (IsGameOn());

			RevealAnswer();
			Rerun();
		}

		/// <summary>
		/// Render the first view of a new the game
		/// </summary>
		public void Initialize()
		{

			Minefield.PopulateCells();
			Console.Write($"* | ");
			for (int i = 0; i < BoardSize; i++) {
				Console.Write($"{i} | ");
			}
			Console.Write("\n");

			for (int r = 0; r < BoardSize; r++)
			{
				Console.Write($"{r} | ");
				for (int c = 0; c < BoardSize; c++)
				{
					Console.Write($"  | ");
				}
				Console.WriteLine();
			}
		}

		// Check if the game ended
		public bool IsGameOn()
		{
			for (int r = 0; r < BoardSize; r++) 
			{
				for (int c = 0; c < BoardSize; c++)
				{
					if (Minefield.Cells[c, r].WasVisited)
					{
						if (Minefield.Cells[c, r].HasMine)
						{
							Console.WriteLine("KABOOM! You hit a mine ...");
							Console.WriteLine("------- GAME OVER! -------");
							Console.WriteLine();
							return false;
						}
					}
				}
			}

			if (NumberOfEmptyCells == NumberOfVisitedCells)
			{
				Console.WriteLine("Congratulations! You Won! :D ");
				Console.WriteLine();
				return false;
			}

			return true;
		}

		// Render new state of the game board
		private void RenderBoard()
		{
			Console.Write($"* | ");
			for (int i = 0; i < BoardSize; i++) {
				Console.Write($"{i} | ");
			}
			Console.Write("\n");

			for (int r = 0; r < BoardSize; r++)
			{
				Console.Write($"{r} | ");
				for (int c = 0; c < BoardSize; c++)
				{
					if (Minefield.Cells[c, r].WasVisited)
					{
						if (Minefield.Cells[c, r].HasMine)
						{
							Console.Write($"B | ");
						}
						else
						{
							if (Minefield.Cells[c, r].NumberOfNeighborMines == 0)
							{
								Console.Write("- | ");
							}

							else
							{
								Console.Write($"{Minefield.Cells[c, r].NumberOfNeighborMines} | ");
							}
						}
					}
					else
					{
						Console.Write($"  | ");
					}
				}
				Console.WriteLine();
			}
		}

		
		// A recursive method to set if the cell was visited or not.
		private void SetVisitedCells()
		{
			for (int r = 0; r < BoardSize; r++)  
			{
				for (int c = 0; c < BoardSize; c++)
				{
					if (c == TargetRow && r == TargetColumn)
					{
						void VisitNeighbors(int c, int r, Minefield minefield)
						{
							if (c < 0 || c >= BoardSize || r < 0 || r >= BoardSize || minefield.Cells[c, r].WasVisited)
							{
								return;
							}

							minefield.Cells[c, r].WasVisited = true;
							NumberOfVisitedCells++;

							if (minefield.Cells[c, r].NumberOfNeighborMines == 0)
							{
								VisitNeighbors(c + 1, r, minefield);
								VisitNeighbors(c - 1, r, minefield);
								VisitNeighbors(c, r + 1, minefield);
								VisitNeighbors(c, r - 1, minefield);
							}
						}

						VisitNeighbors(c, r, Minefield);
					}
				}
			}
		}

		
		// Fix and validate the user input
		public bool CheckUserInput(string userInputTarget)
		{
			string target = userInputTarget.Replace(" ", "");

			if (target.Length != 2)
			{
				Console.WriteLine("ERROR - You have enterd more or less than 2 numbers.");
				return true;
			}
			else
			{
				if (int.TryParse(target[0].ToString(), out int numberY) && numberY >= 0 && numberY < BoardSize)
				{
					TargetRow = numberY;
				}
				else
				{
					Console.WriteLine("ERROR - You can only insert Numbers (0 - 4).");
					return true;
				}

				if (int.TryParse(target[1].ToString(), out int numberX) && numberX >= 0 && numberX < BoardSize)
				{
					TargetColumn = numberX;
				}
				else
				{
					Console.WriteLine("ERROR - You can only insert Numbers (0 - 4).");
					return true;
				}

				Console.WriteLine($"Your target was Column: {TargetColumn}, Row: {TargetRow}");
				return false;
			}
		}

		public static string? UserInput()
		{
			Console.WriteLine("Please enter \n(1) Column number and then \n(2) Row number to set a target: ");
			string? userInputTarget = Console.ReadLine();

			if (userInputTarget == null) {
				Console.WriteLine("No input was given");
			}
			
			return userInputTarget;
		}

		private void RevealAnswer()
		{
			Console.WriteLine("------- Answer! -------");

			Console.Write($"* | ");
			for (int i = 0; i < BoardSize; i++) {
				Console.Write($"{i} | ");
			}
			Console.Write("\n");

			for (int r = 0; r < BoardSize; r++)
			{
				Console.Write($"{r} | ");
				for (int c = 0; c < BoardSize; c++)
				{
					if (Minefield.Cells[c, r].HasMine)
					{
						Console.Write($"X | ");
					}
					else
					{
						if (c == TargetRow && r == TargetColumn)
						{
							Minefield.Cells[c, r].WasVisited = true;
						}

						if (Minefield.Cells[c, r].WasVisited)
						{
							{
								if (Minefield.Cells[c, r].NumberOfNeighborMines == 0)
								{
									Console.Write("- | ");
								}
								else
								{
									Console.Write($"{Minefield.Cells[c, r].NumberOfNeighborMines} | ");
								}
							}
						}
						else
						{
							Console.Write($"  | ");
						}
					}
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}

		
		/// Ask the user if they want to play again
		private void Rerun()
		{
			Console.WriteLine("Play again? (Y/N)");
			string userInput = Console.ReadLine().ToUpper();

			if (userInput == "Y" || userInput == "YES")
			{
				Game game = new Game(BoardSize, NumberOfMines);
				game.Run();
			}
		}
	}
}