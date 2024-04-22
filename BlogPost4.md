<h1> Blog Post #4 </h1>
<h2>Marwa</h2>
-Now is the time for us to have more excitement in our game by adding enemies. so I had the first enemy to the level 1 scene and added more components like Box Collider 2d and Rigidbody 2d I used Edge Collider 2d to the enemy's sword + enable isTrigger for both colliders.
I animated the enemy asset, the Idle and Walk animation for now, and created an enemy controller to handle the states and the transitions between each state I made conditions for example the condition from the idle state to the walk state is moving equal to true.
-Game AI for enemy movement between two points so the enemy should switch between Idle and walking movement and when reaching point 2 should flip to the other direction and move back to point 1, I used EnemyMovement script where I defend 2 points, move speed and Idle time.
the script will  update the animator component to change the animation state based on whether the enemy is moving or idle.
