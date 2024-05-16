using System.Dynamic;
using System.Reflection.Metadata;

namespace Minesweeper;

public class Cell
{
		public bool HasMine { get; set; }
		public bool WasVisited { get; set; }
		public int NumberOfNeighborMines { get; set; }

		public Cell(bool hasMine, bool wasVisited, int numberOfNeighborMines) {
			HasMine = hasMine;
			WasVisited = wasVisited;
			NumberOfNeighborMines = numberOfNeighborMines;
		}
}
