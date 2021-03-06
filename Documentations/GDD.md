# Game Design Document

## Contents
**I** *- Versions*

**II** *- Product Description*

**III** *- Concept*

**IV** *- Gameplay and mechanics*
* **A** *- Victory condition*
* **B** *- Defeat condition*
* **C** *- 3C*
	* *Camera*
	* *Control*
	* *Character*
* **D** *-Flowshart*
	* *Legend*
	* *Hero*
	* *Messenger*
	* *Square*
* **E** *- HUD*
* **F** *- Level Design*
	* *LD Bricks*
	
	
## Versions
| VX.X | Date       | Title							| Comments																										| Author              |
| ---- | ---------- | ----------------------------- | ------------------------------------------------------------------------------------------------------------	| ------------------- |
| V0.0 | 04/12/2020 | Creation of the documentation	| Create the document and add the summary and product description part											| Matthias de Toffoli |
| V0.1 | 04/13/2020 | Concept						| Add Concept part																								| Matthias de Toffoli |
| V0.2 | 04/18/2020 | Gameplay and mechanics		| Add Gameplay and mechanics parts and add Victory and defeat condition and 3C (Camera and control) parts in it	| Matthias de Toffoli |
| V0.3 | 04/19/2020 | Character and HUD				| Add Character part in Gameplay and mechanics, and add HUD part											   	| Matthias de Toffoli |
| V0.4 | 05/02/2020 | Flowsharts, LD bricks and HUD	| Add Flowshart's legend and Flowsharts for hero, messenger and square, add LD bricks and modify HUD			| Matthias de Toffoli |
| V1.0 | 21/11/2020 | Change game rules 			| Change game rules for make it more easy for the player														| Matthias de Toffoli |

## Product Description
* Pitch : It's a 2D mobile mind break game, you will conquer a square that will influence the adjacent squares for conquer them too. An opponent will do same. Every square on your side will give you power, if you have more power than your opponent you will can defeat him.
* Platform : Android Mobile
* Tools : Unity, Photoshop
* Targets : Casual gamers
* Localization : English
* 1 Player, 1 Mobile Android required

## Concept
This game will make you control a character who will have to conquere an area by capturing all it squares and fight an opponant who will try to do same. Every square on your side will give you power, if you have more power than your opponent you will can defeat him.
* For capturing the square a character have to staying on it.
* A square conquered has a level of influence
	* if a character want capture a square with a level superior to 0, the square will lose his levels one by one.
	* if the level is superior to the level of the square next to him (not the diagonal) it will influence it and they will be conquered to.
	* the level can be upgrade if the character stay on the square
* Every square give power of the character which capture it.
* Some square can give more or less power than others
* Characters can't walk on some squares
* Some square can't be conquered
* The oponent can have an hero too , you will can win by killing him or conquer all the map
* All actions will take time, the opponent will act during this time
## Gameplay and mechanics
This game is a strategic mind break game, the player will see the map at it top, he will can click on squares he didn't conquer and will can conquest it. A square conquest will have a level if the player influence more this square so the square will influance the squares next to it.
The player have an hero, he can send him for doing actions. 
The hero can also upgrade his influence in a town by his presence.
All actions take time, in this time the opponent can move and conquer too. The player can pause the time for take decision or let it continue, the action will only be exectuted when the time will throw.
Every square will give powers to the characters.
If the player's hero and the opponent character are on the same square they will fight, the one with more power will win. If they have the same quantity of power they will move to a square near.
### Victory condition
The player conquer the all map or beat the opponent hero
### Defeat condition
The opponent conquere the all map or beat the player hero
### 3C
#### Camera
Fix 2D top-down
#### Control
Touch only
#### Character
* Move to a square point out
* Conquer an empty square
* attack the opponent's hero
### Flowshart
#### Legend
![Legend flowshart](./pictures/GDD/Flowshart_legend.png "Legend flowshart")
#### Hero
![Hero flowshart](./pictures/GDD/Hero_flowshart.png "Hero flowshart")
#### Square
![Square flowshart](./pictures/GDD/Square_flowshart.png "Square flowshart")
### HUD
* *Red are actions*
* *Blue are indications*

![IHM](./pictures/GDD/IHM.png "IHM")
### Level design
#### LD Bricks
Square took by no side :

![neutral square](./pictures/GDD/neutral_square.png "neutral square")

Square took by the player :

![ally square](./pictures/GDD/ally_square.png "ally square")

Square took by the oponent :

![enemy square](./pictures/GDD/enemy_square.png "enemy square")

