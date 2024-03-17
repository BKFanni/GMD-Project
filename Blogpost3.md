###Blog Post #3

(Marwa)
In this third blog post, we're starting to document our progress on The GMD Project. Before diving into the details, we ensured everyone was on the same page regarding the game idea and important aspects like design, platforms, technology, and scope.

Our first step was setting up a 2D project and making some adjustments in Unity to make it easier to work with GitHub. For example, we ensured meta files were visible and configured text settings for better readability.

Two important packages were installed: the Input System and Cinemachine. The Input System helps us make player controls easier and more flexible. Cinemachine gives us some neat tools to make our game look more cinematic and exciting.


(Fanni)
After dividing the tasks between us, I started on creating the main character (the knight) in the game. After installing the necessary assets, I created a GameObject for the Player and added the character Sprite to it. Firstly, I added a rigidbody and box collider to the player and another collider on the feet of the character as a trigger collider, that is used for the jump animation.
box collider and a The installed asset contains multiple images of the character movements, such as idle, walk, run, attack, block and die. I made animations for the Player using the sprites from the asset, so that the user can control the player and make it walk, run and jump. Later I modified the jump animation to be limited to only 2 jumps at a time (double jump feature).

Then I moved on to setting up the platform for the first level of the game. I used the previously installed background asset for this. After modifying the sprites (slicing, adjusting, etc.), I added some basic background elements and platform elements, using rigidbody and tilemap collider. Although I encountered some problems when trying to move up on a hill on the platform with the Player and later I found out that it was due to inappropriate shaping of the collider of the Player. Then I modified and added a composite collider to the Player in order to avoid that problem. I also added a platform that is moving horizontally constantly so that the Player has to jump on it when it gets closer to him in order to continue his way.

I also started on the main menu UI, creating the title and adding animation to it. Then I made a simple play button with onclick functionality. After that Marwa continued working on the UI. After she finished with the first part of the UI, I helped her fix the buttons so that they work (EventSystem was missing) then I modified the nickname field so that it is an input field not only an image and also added the icon of the Player in the top-left corner. 

(Add screenshots how it looks so far)




