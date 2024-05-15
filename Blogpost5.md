(Fanni)
I added a transform gameobject with a collider that I set as a trigger, to mark the "end of the world". So that when the player falls down, he dies and the Game Over UI is displayed, along wiht a play again and quit button. I also added the "Die" animation for the player and it is triggered when the animation attribute, "isDead", is triggered. It is triggered when the Player collides with the "end of the world" gameobject, that has a tag "GameOver". For this I used the OnTriggerEnter2D function, and it also sets the Canvas active (That is the UI to display Game Over + buttons) and also pauses the game, by setting the timeScale to 0. 
I had to modify the DontDestroyOnLoad script, so that it will not create duplicate gameobjects when the same scene is reloaded, for e.g. when pressing the Play again button. Additionally, the Play again button now calls a Reload scene function on click, so that it reloads the current scene. It was a bit of a struggle to figure out how to fix the issue with the objects using DontDestroyOnLoad component, but finally it works and it still keeps the objects when a new scene is loaded. 
##Add screenshot here


<h2>Marwa</h2>
<H4>Attack mechanics for the player </H4>First of all I have changed some of the pick-up items to the green pivot item to make it ready to use to increase the player's Health range. To implement the attack mechanics I created a script where, I first set up variables to define the attack properties, such as attackRate, attackRange, and attackDamage. Then, I create a check for player input to initiate attacks, like pressing the "Return" key. Next, I ensure smooth animation control for the player character's attacks, using animator.SetBool("Attack", true) to trigger the attack animation. To detect nearby enemies, I employ Unity's physics system, utilizing Physics2D.OverlapCircleAll within the defined attack range. With enemy identification based on tags, such as checking if an enemy has the tag "Enemy," I ensure that only valid targets are attacked. Finally, when an attack occurs, I call a method to inflict damage on the enemy, like enemyHealth.TakeDamage(attackDamage). 

I created a script for Enemy Health, I started by defining variables for maximum and current health. When an enemy takes damage (TakeDamage method), I reduce its current health. If the health drops to or below zero, I trigger a death animation (Die method) using an Animator component. Finally, I destroy the enemy GameObject after a short delay to allow the death animation to complete. This script allows me to handle enemy health, death animations, and removal from the game.

I had some issues with the attack animation where the attack animation continued even though I didn't press the return key, the problem was that the attack function would set the animation to attack and never set it to false again, so after many tries, I figured out that I need to add one line of code to update method " animator.SetBool("Attack", Input.GetKey(KeyCode.Return));" that will set the attack animation to false if the Return key is not pressed. 

<h4>control animation states</h4> I improved the animations for the player character by smoothly transitioning between movement and attack actions. When the player attacks, the attack animation is triggered seamlessly.

For the female enemy character, I added a death animation that plays when her health reaches zero. This makes the game visuals more engaging and responsive to gameplay events. 
<img src="images/attack.png">

<h4>Player Health System</h4>
To manage the player's health, I developed a PlayerHealth script. This script not only tracks the player's health points but also manages the number of lives, we decided that the player has 3 lives and each life is equal to 100. When the player sustains damage from the enemies, the script deducts health points accordingly. If the player's health reaches zero, the script handles life deduction or triggers a game over if no lives remain. This robust system ensures smooth gameplay and adds depth to the player's experience.

<h4>Enemy attack</h4>
I updated the EnemyAttack script to make enemy attacks more dynamic and challenging.
Each enemy attack now has a defined damage amount which is equal to 0.25 for each attack.
Furthermore, I ensured that changes in the player's health were reflected in the Health UI in real time. This allows players to stay informed about their health status during combat, enhancing their immersion in the game world.
