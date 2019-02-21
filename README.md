# Wh40k TableTop

## Copyright

This web site is completely unofficial and in no way endorsed by Games Workshop Limited.

40k, Adeptus Astartes, Blood Angels, Bloodquest, Cadian, Catachan, Chaos, the Chaos device, the Chaos logo, Citadel, Citadel Device, Cityfight, Codex, Daemonhunters, Dark Angels, Dark Eldar, Dawn of War, 'Eavy Metal, Eldar, Eldar symbol devices, Eye of Terror, Fire Warrior, the Fire Warrior logo, Forge World, Games Workshop, Games Workshop logo, Genestealer, Golden Demon, Gorkamorka, Great Unclean One, GW, GWI, the GWI logo, Inquisitor, the Inquisitor logo, the Inquisitor device, Inquisitor:Conspiracies, Keeper of Secrets, Khorne, the Khorne device, Kroot, Lord of Change, Necron, Nurgle, the Nurgle device, Ork, Ork skull devices, Sisters of Battle, Slaanesh, the Slaanesh device, Space Hulk, Space Marine, Space Marine chapters, Space Marine chapter logos, Tau, the Tau caste designations, Tyranid, Tyrannid, Tzeentch, the Tzeentch device, Ultramarines, Warhammer, Warhammer 40k Device, White Dwarf, the White Dwarf logo, and all associated marks, names, races, race insignia, characters, vehicles, locations, units, illustrations and images from the Warhammer 40,000 universe are either �, TM and/or � Games Workshop Ltd 2000-2019, variably registered in the UK and other countries around the world. Used without permission. No challenge to their status intended. All Rights Reserved to their respective owners.

## Tutorial
This Instructional comes without testing on any other system therefore I cannot be guarantee it will work on any other system. The test and compile system is a ADVENT with 2GB of RAM and 1.66 GHz processor running Microsoft Windows Vista Home Premium SP2.
There are a number of forms some with similar properties they are:
- �Race selection�
- �Team selection�
- <Race> �Army selection�
- <Race>�Weapons selection�
- �Map�

Upon executing the program you will be presented with a number of message boxes, the first asks whether you want deployment zones displayed on the map form, for now we will click �no�. The next two messages boxes asks for the width and height of the scenario/playing table, adjust this at your discretion however upper bounds have been set to 120 inches for width and 80 for height. After confirming the width and height it will prompt you for the number of players, as of January 2019 this has not been play tested any higher or lower than 2, as such please confirm the default value of 2 by clicking �ok� (this instructional will also assume 2 players where appropriate). 
Now you are presented with the �Race Selection� for now only two buttons do something, if you would like to skip straight to the �Map� and use values current used for debugging then click on the button marked �Orks� otherwise click on the button marked �Space Marines� twice
The �Team selection� form will now appear and the only button is marked �Continue� please click this. You will now be presented with two buttons, a drop-down list and an empty list box, at your discretion please experiment with these inputs as well as all other inputs available on this screen. When you are done with this please click the button marked �finished� which will take you to the �weapons selection� form, this will preset you with the current values used for debugging for now scroll through them clicking on the button marked �next squad�. Continue doing this for the other player�s forms until the screen fills with a large yellow form (the �Map�) with lines of green boxes on the left and red boxes on the right, it will also have twenty brown boxes randomly placed in between them. The red and green boxes represent models from different players/teams. The brown boxes are scenery parts and have not been fully implemented
The map has yet to be finalised however it implements phases like the WH40k tabletop as such the following phases have been started: movement, psychic, shooting, and leadership/morale. The other phases have yet to be started and should be skipped. Information regarding current phase can be found by right clicking anywhere on the from that is not model, a box will appear in the top left or right of this form, you can also cycle the phases by clicking on the button marked �next phase�. All other buttons or selection boxes are currently used for the shooting phase. For now skip to the movement phase, and hover over any green boxes on the left, a black ring should appear centring on the green box, this is the maximum distance the model can move. The circle does not take into account for scenery. Drag this model anywhere inside this circle to move it (you can move it outside the circle however it will reset to the boundary of it movement upon releasing the mouse). 
Cycle to the shooting phase and hover over the top left green model its name should be �Captain in Terminator armour�. Right click this unit and click on the �select� option under �shooting�, now right click on the next model down with the same name and choose �select� under �targeting�. This will allow the user to select model to shoot with and to target, to clear a model of shooting or targeting right click on the model and pick �cancel� under the appropriate menu, alternatively click �cancel all� to clear all model from the appropriate option. Now go to the box with phase information and click on �select this unit to shoot with�, pick the �plasma gun� (it is advised to not utilise and melee weapon at this time as the program will go into an infinite loop) and click on �select this unit to target�, after that click �use selected weapon�. A message box will pop up prompting you to click either �standard� or �supercharge� click either. It may (depending on dice rolls) prompt you to select a unit to apply damage to that model, right click on the model selected to be the target and click �apply damage due to the shooting phase� to apply damage to the model. Repeat the procedure for using the weapon until the target model is dead (not visible). After selecting multiple targets, when applying damage it will default to select the top most model.
After cycling to the leadership/morale phase (and enough models have died in the previous phases) it may be necessary to remove some models from the battlefield/flee, a popup will inform you if this is needed. If one is needed right click on a model in the appropriate group and select �model flees during the morale phase�.

## To-do list
- Needs a proper project name
- Complete psychic phase and amount of psychic powers per psyker inc denials, Weapons rule exceptions
- Implement Charge Phase, Fight phase, Abilities, Invulnerable Save, Damage Characteristics (for models with 12+ wounds), assault + heavy for moving and advancing, exploding and chaining and kill on number of shots termination, depth (for roofs of building and gantries).
- Include vehicle and flyers
- Flesh out Races:- Orks, Dark Eldar, Chaos, Chaos Daemons, Eldar, Tau etc
- Plans to include 3d graphics