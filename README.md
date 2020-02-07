# GolfGamePrototype
**Video Demo URL**
https://youtu.be/0JVLoSVUcIQ 

**Description**
In this golf game, the player controls the direction of the ball with **A, D** or **left and right arrow**, and the force by pressing **SPACE** once to start charging and once again to apply the force. 

The ***capsules*** shown in the game are different ***power-ups*** that are supposed to be a surprise and that's the reason why they are not labelled somehow. However, the player can learn through the game to distinguish them by their colours:
 - red -> increased strike force
 - blue -> immediate transportation of the golf quite close and around the final hole
 - purple -> swap positions with an opponent (available on "multi-player" levels).

The red striped "bridges" give some ***bonus points***, that could be used to unlock extra features.

The ***hatch***:
- when multi-player, it relates to 2 buttons that respond only to the golf ball that has the same colour as them,
- when single player, it just opens when the player collides with it.

The ***multi-player*** functionality in this prototype is presented with a "mimic ball" that copies the main player's position and reverse it. It is convenient though, in order to show the ***co-op functionality*** of the different coloured buttons that open the hatch.

The ***fireballs*** can burn the players:
 - if the main player gets burnt, the player turns into black and stops moving, and after 2 seconds the level restarts
 - it the mimic player get burnt, it turns into black and stops moving, and
	 - if the hatch is still closed, the game turns into single player, the buttons get disappeared, and the hatch can be opened with collision with the player
	 - if the hatch is opened, the main player continues the game.
  
The third level shows the different affect that ***different floors*** have on the golf ball.

Screenshots:
|[Level1_3D](https://github.com/sopa92/GolfGamePrototype/blob/master/Screenshots/Level1_3D.JPG)| [Level1 Top View](https://github.com/sopa92/GolfGamePrototype/blob/master/Screenshots/Level1_top_view.JPG) |
|--|--|
|[Level2_3D](https://github.com/sopa92/GolfGamePrototype/blob/master/Screenshots/Level2_3D.JPG)| [Level2 Top View](https://github.com/sopa92/GolfGamePrototype/blob/master/Screenshots/Level2_top_view.JPG) |
|[Level3_3D](https://github.com/sopa92/GolfGamePrototype/blob/master/Screenshots/Level3_3D.JPG)| [Level3 Top View](https://github.com/sopa92/GolfGamePrototype/blob/master/Screenshots/Level3_top_view.JPG) |
