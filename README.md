# Code_Challenge_Rara
Used Unity Version: 2021.2.18f1
Major Game Modules: Player, AI, Weapon, Collectables, Obstacles & Level Editor

Player: This module is responsible for Player control. Implemented Walk (WASD or Arrow Keys) and Jump (space bar). Used StateMachine to implement this.

AI: This module uses the state machine and navmesh component. Implemented features are wandering/Patrol, chase if the player is in chase range, and Turret shooting if the player is in range. This is a pluggable system. There is a component called Target which must be
assigned to the target if the target object needs to be followed by the AI characters.

Weapon System: This can be used for shooting purposes. For now, Turret uses this. But if we want to provide shooting ability to any AI Player we can configure it. (This system is limited to the project scope but can easily be scaled)

Collectables & Obstacles: These are again the pluggable component. For collectibles to be collected by the player attach the component Collector on the player. This system uses the Scriptable Event system to notify the collection events. (For flag, Conis, etc.) 
Obstacles(Mine) are also handled in i similar way to the notification and use the SendMessage.

LevelEditor: This module provides the functionality to set up and playtest the levels.

All the above modules are independent of each other. The system is limited to the project scope but can easily be scaled.
The design principles used here are, StateMachine. Pooling. for the event system used the ScriptableEvent system.
The core tools used for the implementations are StateMachne, ScriptableEvent, and Tag System.

Areas to Improve: Level Editor. This can done in much better way.
Also some area like what to do when user get shot and AI touches the player etc can be improved based on the requirment. 

