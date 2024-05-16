# Therese's Minesweeper game
==========================

## DEFINITION OF DONE:

From "Task.txt": 
1. "Start with this sample project and expand" - Done!
2. "It shall accept x and y coordinates" - Done!
3. "The program shall follow the rules of Minesweeper" - Done!
4. "The game shall render the new state of the game" - Done!
5. "The program shall uncover all coordinates adjacent to the visited one until a bomb is uncovered" - Done!
6. "When the state is printed, the number of bombs that can be reached from uncovered 
		coordinates shall be output for those coordinates or empty for coordinates with no adjacent bombs" - Done!
7. "The program shall ask for coordinates until a bomb is encountered or all bombs have been uncovered" - Done!
8. "Test cases that you feel are relevant can be added to the test project" - Done!

===

## EPICS:

1. "The program will tell the user if they won" - Done!
2. "The program will tell the user if they lost" - Done!
3. "The program will reveal the answer if the game has ended" - Done!
4. "The program will tell if you entered a target that has already been revealed" - To do...

===

## KNOWN BUGS:

1. If the mine was hit, the game shall only render a "B" on the targeted position. 
- But if the hit mine has an adjacent mine, it will also render a "B".

===

## THE PROGRESS:
It's been 7 years since I wrote any C#, and I definitely learned and relearned a lot!

Minesweeper.cs - I just wnted the clean Main() that initializes the game and where I could pass in the board size and amount of mines.

Game.cs - Here is where you find the game logic.

Minefield.cs - Here is where we set a new game field.

Mine.cs - A minefield contains cells, and it's the cell that contains a mine or other information for the player.

MinesweeperTest - Contains three tests to check for bugs.

Of course, it was a bit of a challenge in the beginning redirecting from JavaScript to C#,
but this went out faster than expected. 
The logic was fairly easy to accomplish. The real struggle came with the tests. 
I should have done "Test-driven development" if I did it again. 
Now I had to refactor a lot to make it testable. But I did learn a lot from 
that and how to work better object-oriented.

I could have worked more with the methods - for example, so the RenderBoard 
was responsible for making all the WriteLine() calls. 
But improvements can continue indefinitely, and for now, it was time to be satisfied.
