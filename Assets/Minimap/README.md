# Map-view
Provides a minimap that shows the user's location on the map.

## How to Use
1. Create a Minimap User Layer
2. Add `Minimap Camera` Prefab to your scene
3. Add `User Sphere` Prefab as a child to the AR Camera
4. Add `Destination Cube` Prefab as a child to the various destination objects. Alternatively we can also have it inputted directly into the scene w/ its own controller script.
5. Add `MUSEUM MODEL` to scene. You will need to set the location such that AR Session will appear in the right part of the map upon initialization.

## About
Minimap Layer: User Defined, this is the layer of elements that will appear on the minimap camera. 
