# Grid Game Groundwork Lite for Unity

A Unity project & level editor for making 3D grid-based games.  
Based on https://github.com/mytoboggan/grid-game-groundwork, with less assumptions.  
Made with Unity 2019.x LTS  

## Setting Up Scenes:
See "Example.unity"  

## Using the Editor:
The editor window can be found under "Window" -> "Level Editor".
- Define the list of prefabs at `Assets/leveleditorprefabs.txt`, or assign prefabs manually to the "Prefabs" dropdown
- Select a game object (prefab)
- Left-click anywhere in the scene to paint in the selected gameObject
- Hold left-click to paint continuously 

_Note: Selecting "Erase" will clear any objects at that position._

## Setting up prefabs:

Any prefab that you'd like to draw with the editor will need a `BaseObject` component on its root (or
a class that derives from `BaseObject`). It will also need one or more child gameobjects tagged with "Tile", each with a
`BoxCollider` component. See the `L-Shape` prefab under `Assets/Resources` for an example.

## Class Breakdown:

### BaseObject:
Component for objects that the editor can draw

### Utils:
General utilities class

### WaitFor:
For caching yield instructions, borrowed from... somewhere on the internet years ago.

### LevelEditor:
The `EditorWindow` class (see "Using the Editor" above)
