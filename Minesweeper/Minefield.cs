using System.Security.Cryptography.X509Certificates;

namespace Minesweeper;

public class Minefield
{
	public int BoardSize { get; set; }
	public int NumberOfMines { get; set; }
	public Cell[,] Cells { get; set; }

	public Minefield(int boardSize, int numberOfMines) 
	{
		BoardSize = boardSize;
		NumberOfMines = numberOfMines;
		Cells = new Cell[boardSize, boardSize];
	}

	public Cell[,] PopulateCells()
	{
		for (int r = 0; r < BoardSize; r++)
		{
			for (int c = 0; c < BoardSize; c++)
			{
				Cell newCell = new Cell(false, false, 0);
				Cells[r, c] = newCell;
			}
		}

		SetMines();

		CountNeighbors();

		return Cells;
	}

	private void CountNeighbors()
	{
		for (int r = 0; r < BoardSize; r++)
		{
			for (int c = 0; c < BoardSize; c++)
			{
				if (!Cells[r, c].HasMine)
				{
						if (IsInsideBoard(r + 1, c + 1) && Cells[r + 1, c + 1].HasMine) { Cells[r, c].NumberOfNeighborMines++; }
						if (IsInsideBoard(r - 1, c - 1) && Cells[r - 1, c - 1].HasMine) { Cells[r, c].NumberOfNeighborMines++; }
						if (IsInsideBoard(r + 1, c - 1) && Cells[r + 1, c - 1].HasMine) { Cells[r, c].NumberOfNeighborMines++; }
						if (IsInsideBoard(r - 1, c + 1)	&& Cells[r - 1, c + 1].HasMine) { Cells[r, c].NumberOfNeighborMines++; }
						if (IsInsideBoard(r + 1, c) && Cells[r + 1, c].HasMine) { Cells[r, c].NumberOfNeighborMines++; }
						if (IsInsideBoard(r - 1, c) && Cells[r - 1, c].HasMine) { Cells[r, c].NumberOfNeighborMines++; }
						if (IsInsideBoard(r, c + 1) && Cells[r, c + 1].HasMine) { Cells[r, c].NumberOfNeighborMines++; }
						if (IsInsideBoard(r, c - 1) && Cells[r, c - 1].HasMine) { Cells[r, c].NumberOfNeighborMines++; }
				}
			}
		}
	}

	private bool IsInsideBoard(int rows, int cols) {
		return rows >= 0 && rows < BoardSize && cols >= 0 && cols < BoardSize;
	}
	
	public void SetMines()
	{
		Random rnd = new Random();

		for (int i = 0; i < NumberOfMines; i++) {
			int x, y;

			do {
				x = rnd.Next(0, BoardSize);
				y = rnd.Next(0, BoardSize);
			} while (Cells[x, y].HasMine);

			// This will set a mine to the position 
			Cells[x, y].HasMine = true;
		}
	}
}
