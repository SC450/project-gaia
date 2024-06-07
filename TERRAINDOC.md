# Terrain Generation Documentation
We've provided you with tools to generate terrain and customize water, but knowing how to use these tools can be confusing at first glance! Here you will find documentation on the fields (properties) of the scripts contained within the Map Generator object, as well as documentation on how to customize the water.

## Map Generator Documentation
Inside MainScene, you will find an object called "Map Generator," which is responsible for generating the terrain. Map Generator contains three scripts: Map Generator, Map Display, and Asset Placement. You only need to be familiar with how to use the Map Generator and Asset Placement scripts; do *not* change any fields inside the Map Display script.

## Map Generator (Script)
The Map Generator script inside the Map Generator object is the heart of generating the terrain and giving it a texture. 

### Fields
1. Draw Mode: Keep this setting as "Mesh." If you want to, you can select the other modes and see the Noise Map object to see how the Perlin Noise looks like before it is mapped onto a mesh.
2. Level of Detail: The quality of detail on the mesh, ranging from values 0-6. Increasing this value will make the terrain more flat and less hilly, so it is recommended to keep this value low.
3. Noise Scale: Affects how "zoomed in" the noise map is. A lower noise scale will make the terrain more hilly and scattered, while a higher noise scale value will make the terrain more whole and basic.
4. Octaves: Affects the "roundedness" of the terrain. The higher the amount of octaves, the more detail there is to the roundedness of the terrain.
5. Persistance: Affects how "grainy" your terrain will be. Higher persistance makes the terrain more grainy and scattered.
6. Lacunarity: Affects how detailed hills are on your terrain. A higher lacunarity value will make the terrain more "spiky," while a lower lacunarity value will make the terrain more smooth.
7. Seed: A number that is associated with a certain randomly generated piece of terrain. Useful for replicating and saving pieces of terrain (If you're familiar with seeds in Minecraft, this seed system works essentially the same!).
8. Offset: X and Y values that allow you to "move" through the noise map, being able to shift the terrain in the X or Y direction.
9. Use Falloff: Highly recommended to keep this setting on. Forms edges around the terrain, turning the terrain into an island. Useful to establish boundaries for your map.
10. Mesh Height Multiplier: The amount to scale the height of hills and bumps on your terrain by. Increasing this value makes hills and bumps on the terrain higher.
11. Mesh Height Curve: A curve repesenting how the terrain should be scaled according to the height at a certain part of the terrain. You can adjust this curve if you want to, but the default curve should suffice for most terrain figurations.
12. Auto Update: Highly recommended to keep this on. Will automatically update the terrain if you change any of the values within the fields of Map Generator.
13. Regions: Here, you can configure the regions for your terrain. Each region has three properties.
- Name: The name of the region (e.g. Sand, Mountain).
- Height: The height *up to* which the region will generate.
- Color: The color of the region.

Last but not least, do not forget about the "Generate" button at the bottom of the Map Generator script, as you can use this button to regenerate the terrain's texture each time after you exit playmode.

## Asset Placement (Script)
This script is responsible for randomly placing assets on your terrain.

### Fields
1. Assets: Customize the asset categories you want on your terrain in this field. The placement of assets is highly customizable, with multiple fields you can adjust for each asset category.
- Name: The name of the asset, or a group name if using multiple assets.
- Prefabs: The assets that can be placed for this category. This field is used to add variants of assets (e.g. Spruce variants, mint variants, etc.). When an asset of this category is placed, a random prefab from the Prefabs field will be chosen if there are multiple prefabs.
- Amount: The number of objects that will be placed for this category.
- Scale Range: The scale that the assets in this category can range from. X is the lower range, Y is the upper range. Set both X and Y to 1 if no variance in scale is desired.
- Height Range: The height range that the assets in this category can spawn at. X is the minimum height, Y is the maximum height. You may have to mess around with these values if assets are spawning in undesired locations.
- Grounding Offset: The amount to "push" the asset into the ground. Mainly used for tree assets, as the root of a tree can stick out if it is not set into the ground far enough. You should set this value to 0 for assets that should not spawn pushed into the ground, such as animals.
- X Bound: The boundary on the X-axis to place assets. Past the X Bound, assets will not be placed. You may have to mess around with this value to fit it properly if you change the size of your terrain. (IMPORTANT: Make sure that this value is not 0 or a very low number, like 10, otherwise your bounds will be too small and Unity may crash!)
- Z Bound: The boundary on the Z-axis to place assets. Past the Z Bound, assets will not be placed. You may have to mess around with this value to fit it properly if you change the size of your terrain. (Also with the Z Bound, make sure that this value is not 0 or a very low number.)
- Obstacle: Sets the asset to be an obstacle for animals to avoid. If checked, animals will walk around the asset, or be able to walk through it if unchecked. This box should be unchecked for small assets that animals can walk through, such as grass or mint.
2. Water: The object that represents the water of the terrain. (Do not change this field unless you want to create your own water object.)
3. Global Scale: The amount by which to scale all assets that are placed.

Use the "Place Assets" button at the bottom of the Asset Placement script to randomly place your set of assets. You can press the button repeatedly to get different configurations of asset placements.

## Water
In MainScene, you will see an object called "Water." This object is the water for your terrain, and if you view the inspector tab and expand the "Stylized Water (Material)" component, you will see that there are multiple properties that you can adjust under "Surface Inputs."

### Fields
1. WaterDepth: The depth of the water. A low water depth will display the DeepWater color more prominently, while a higher water depth makes the ShallowWater color more visible.
2. ShallowWater: The color that water nearer to the surface will have.
3. DeepWater: The color that water farther from the surface will have.
4. RefractionSpeed: The speed that the water will refract light at. A higher RefractionSpeed makes objects in the water appear more "wavy."
5. RefractionScale: Affects the scale of how objects look in water.
6. RefractionStrength: The intensity of the water's refraction.
7. WaterTransparency: Affects how clear the water is. A lower value makes the water more clear.
8. FoamAmount: Affects how much foam there is in the water.
9. FoamCutoff: Affects how close foam should be to edges of land. A higher FoamCutoff value pushes foam closer to edges of terrain.
10. FoamSpeed: Affects how much the foam should move.
11. FoamScale: Affects how fine the foam is. A higher FoamScale makes the foam more fine.
12. FoamColor: The color of the foam.

## Ending Notes
If you are still struggling to understand how any of the fields work for the Map Generator and Asset Placement scripts, or how to customize the water to your liking, the best way to better understand the fields is to just play around with them! Adjust the values for each field and see how it affects the terrain; make observations on these changes to understand how each field works! If you are still struggling on customizing the fields after your own experimentation, do not hesitate to ask a tutor or your mentor for help!
