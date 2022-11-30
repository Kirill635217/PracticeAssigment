# PracticeAssigment
* The main player is Cylinder, which collects other models in the play zone. Move by A, W, S, and D keys.
* The game starts with a 0 score. When Cylinder pushes other game objects (collectables) - the score increases, 
depending on the game object and level, and the object disappears from the game. If player pushes the same type of game object one by one the score
decreases on double value.
* The new game objects appear randomly in the play zone after Cylinder pushed another game object.
* From time to time in the game appear Cubes which Cylinder can't move.
* The player moves to the next level when you achieve 100 points.
* The player finishes the game in two cases: winner - achieves 400 points, loser - you are blocked by Cubes and can't collect any collectables.
* Cylinder's appearance changes depending on the current level.
* Results of the game (Time of attempt, Score, amount of pushed objects) are save as a JSON file to a set path (streamming assets).
