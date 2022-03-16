# Terraphoria

https://www.evl.uic.edu/cs426/finals/2021-Spring/Videos/Terraphoria.mp4





**Design**

We designed Koi to be someone who is natively from the eastern hemisphere and will have to traverse through the map. The map we made is to citylike along with a mix of some outdoors. The reason we chose this is because we wanted the player to first be able to settle down in an open outdoorish field before having them introduced into the city where it will most likely but a bit more narrow. In terms of the yakuza models the first model we made was the motorcyclist model. The reason we chose this model was because out of all the models in mixamo he looked the closest to a gang member and looked somewhat menacing. The animation he has attached is a walking animation because he is constantly moving on patrol so we thought this would be a good implementation. The AI we decided to implement on him was patrolling because we thought it would be appropriate for a yakuza member to be patrolling around the area making sure there are no intruders. The next model we decided to do was a vampire with a hood and the reason why we chose this model is because he is easily distinguishable as an evil character so the player may not mistaken him as an ally. The animation we chose for this character is some sort of guard animation because he should be blocking the player from his destination. When it comes to the overall map, the map was made so it is impossible to traverse through without the use of "Terraforming" because that is the key aspect of our game. The sounds we implemented also matched the overall theme and an example of this would be the sound notification of when the player terraforms. We made sure that the sound was somewhat “eerie” because the overall aspect of terraforming is supernatural. Other sounds were designed so that it gives the player some sort of feedback that their action has successfully been done. The lights added were also made with the map in mind. The neon red lights help set up the “Downtown” feel of the area it is in since cities often have neon red lights. The streetlight is also near the player spawn to help illuminate the beginning area so they may properly see where they are going. In the end we feel that all of our assets and design decisions have helped create the overall feel of the downtown Tokyo environment we originally had planned. 

**AI**  
• Yakuza member using navmesh to patrol and chase the player when in range. otherwise return back to patrol - Michael Chau  
• Vampire unit that will chase the player and attempt to block their path (uses navmesh as well) - Jiajun Mo  
• Pedestrian ai that should utilize an FSM to patrol from point A to point B - John Cervantes  
• RBS that ensured the player can not jump multiple times while in the air. - Michael Chau/John Cervantes/Jiajun Mo  


**Mecanim**  
• Koi model + animations - John Cervantes  
• Yakuza member (Motocyclist model) + animations - Michael Chau  
• Yakuza member (Vampire model) + animations - Jiajun Mo  

The changes we made for our game in order to meet the requirements for assignment 7 are the following:

**UI Design**

-- Michael Chau			

• Added an HP bar so the player may now see how much HP is remaining. The HP bar will properly be updated as the player takes damage and should now allow the player to properly know when they are in danger.

• Solved this by adding a billboard that suggests what the player should do. With this billboard the players should now be able to properly understand that the main objective of the game is to collect all the floating orbs in order to beat the game.

• Fixed by having another board explaining how sprinting adds spirit energy. By having this billboard explain an alternative to gaining spirit energy, players may not use this alternative to gain enough energy to attack again without possibly waiting for the natural generation or picking up foliage.

-- John Cervantes

• To fix the first instance, I implemented a resource bar for the accompanying spirit where the player can see the usage of the accompanying spirit’s aura. Thus, it is clear to the player how much resource for the aura of the accompanying spirit is currently left, allowing the player to manage their usage of the aura.

• To fix the second instance, I implemented a physical sign for the player located at the beginning of the scene to describe to the player how to play the game. The physical sign describes the input needed for movement, terraforming, firing spirit attacks, and interacting with foliage. Thus, it is clear to the player how to play the game by describing what inputs do what in the game.
		
• To fix the third instance, I changed the material of the obstacles into a brick material that is a less saturated red color. The brick material helps avoid saturated colors as it is a lower shade of red and is less saturated compared to the previously used saturated purple color. Additionally, the brick material helps with clarity as it makes the obstacles look like obstacles as brick is often associated with walls and are viewed as obstacles. Thus, it is clear to the player that the obstacles are obstacles and color was used more sparingly.
	

-- Jiajun Mo

• Added more action effects. When the player is far away from the monster, the monster will be in a standby state, and the walking and attack modes will be switched according to the distance. Fixed the mold penetration caused by monsters moving or being attacked.

• Increased the HP value, which will be displayed when the monster is in the player's field of vision. If the player is too far away from the monster, the monster will return to its initial position and restore its HP value.

• The monster will die and disappear when its HP returns to zero, and the strange rotation and displacement caused by the player's attack by the monster has been fixed. At the same time, monsters during the death animation can no longer be attacked, and the "attacked" animation appears in the death animation.

**Sounds created for the game:**

• Terraforming sound

• Pedestrian sounds

• Spirit projectile sound

• Enemy hit by spirit projectile sound

• Footstep sounds

**Other modifications**

We updated the overall map to help fill in the void and emptiness of the previous map. We the additions of trees, more buildings, and background music we aimed to help set up the specific environment/mood we intend for the player. Also along with all the additions of the features listed above we aimed to help make the player experience more immersive and fluid while playing our game. Lastly the additions of the new UI and other features were aimed to give more clarity to the player and perhaps give more assistance.

**Assignment 9 Section**

**How we modified the design of “Terraphoria” since the alpha release:**

  • In order to resolve the issue of our music being too loud we significantly reduced the Audio source volume that handled the output of the music throughout the areas.

  • To help aid the player when it comes to jumping on the terraformed objects, we have made the platforms that the spirit spawns to be much larger and wider so that even players that are inexperienced with platformers could easily jump onto them. 

  • To help make the yellow collectables orbs more noticeable and easier to see we have increased the size of the orbs very slightly.

  • We have adjusted the overall volume of JmoAITest bullet impact along with the overall volume of the game to help make sure that it is more suitable to play. 

  • In order to resolve the observation where the two testers ignored the vampire enemy and proceeded to terraform to platform over the first obstacle, we decided to   enlarge the obstacle to dissuade the act and widening the platform so that players cannot walk around the obstacle. Additionally, as a reward for defeating the vampire enemy, the first obstacle is destroyed.

  • In order to reduce the difficulty of using the terraforming feature, we implemented an optional tutorial area where the player can practice using the terraforming on two courses of varying difficulty.

  • In order to make the foliage collectible knowledgeable to the player, we implemented an optional tutorial area where the player can learn about and interact with the foliage infinitely.

  • In order to deal with the feedback regarding the rotation speed, we implemented the ability to increase and decrease the rotation speed of the player.

  • In order to deal with fast player movement speed, we reduced the player movement speed and implemented a sprint functionality that will allow the player to use a short sprint by pressing shift that depletes an accompanying stamina bar that slowly regenerates over time.
  
  • We have added a pause menu, where you can save, return to the main menu or exit the game.

  • We have added a save function, which will record the player's location, collection, and monster status. The player can delete the archive by pressing the "L" key. When there is no save, the "Load Game" of the main menu will appear gray and cannot be interactive.

  • Increase the damage stacking mechanism, and the player will cause double damage to monsters with a certain probability of crit.

  • Added the mechanism that after the player's stamina is exhausted, he will not be able to sprint and his actions will consume HP.

  • The speed of the player in the jump is reduced, and the player's high-speed forward situation after jumping is reduced.

these changes were influenced by feedback in alpha testing, as well as things we thought would improve our game. 


Shader design:

  • Player Character shader: A shader for the player character was implemented due to the player seeing the player character throughout the gameplay and thus the player character should provide visual feedback of the environment it is currently in. Therefore, a rim lighting shader was applied to the player character to have the player character model provide visual feedback of the sunlight hitting in a specific direction.

  • Building shader: A shader for buildings was implemented as the city area is an essential area of the scene with respect to the gameplay and significance in the story. We decided it should be visually appealing to the player and should look realistic with respect to the building visually being affected by the sunlight hitting in a specific direction. By implementing the shader for the building, it also helps add more realism to the environment as it is expected that buildings react to light sources, making the environment more believable.
  
  • Yakuza model shader: Added a shader to the yakuza model that increased the overall brightness of his material along with helping it reflect some more light. The purpose of adding this shader to the model was to make it more visible to the player as well as brighten the color red which is easily associated with danger.

  • Vampire & Brick model shader: Shader allows the material to add more details, vampire has the texture of the tree, and it becomes more concealed as it blends with the environment. Use the same Shader to add a map to the bricks to make the texture of the bricks look rougher instead of looking very smooth. Has a stale feeling.





**What each person worked on for assignment 9**

--Michael Chau 

 • Yakuza model shader 
 
 • Credits scene and making sure each asset properly given credit to.
 
 • Implementation of ScoreManager to properly keep track of how many collectibles players have gotten
 
 • Updating Yakuza AI to properly subtract HP from player on collision, increasing movement speed when player is spotted, bugfixes.
 
 • Resized collectible size
 
 • Design of stamina bar
 
 • Transition to credits once x amount of spheres collected
 
 -- Jiajun Mo
 
 • Detail Shader for vampire & brick.

 • Optimized the death effect of vampire, destroying the first barrier.

 • Numerical optimization:
 
	 • Added  the consumption and function implementation of the player's stamina bar
	 
	 • Added the effect of returning to the main menu when the player returns to zero health
	 
	 • Added  the sprint function so that players can become more flexible
	 
	 • Added the player's perspective rotation acceleration function
	 
	 • Improved the relationship between player's health and stamina consumption
	 
	 • Modified the movement speed of the player in various states
	 
	 • Modified the damage mechanism of players and monsters

 • Added save and delete archive functions
 
 -- John Cervantes
 
 • Player model shader
 
 • Building shader
 
 • Main Menu scene with the corresponding functionality of five buttons: Play, Load Game, How To Play, Introduction, and Quit
 
 • Optional tutorial area in the scene with for the player to learn about and practice interacting with foliage, using spirit attacks, and terraforming
 
 • Added lights to the scene to show sunlight
 
 • Pause Menu with corresponding functionality of four buttons: Resume, Save Game, Return to Main Menu, and Quit Game
 
 • Added onto the How to Play sign in the scene to include the added controls
 
 • Added a script for the foliage in the optional tutorial to be able to be interacted with infinite amount of times
 





---------------------------------------------------------------------------------------------------------------------------------------------------
**end of assignment 9 section**
