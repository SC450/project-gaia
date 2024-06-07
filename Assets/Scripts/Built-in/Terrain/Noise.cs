using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise {
    public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, int seed, float scale, int octaves, float persistance, float lacunarity, Vector2 offset) {
        // Float array to store noise values
        float[,] noiseMap = new float[mapWidth, mapHeight];

        // Seed functionality for replacability
        System.Random prng = new System.Random(seed);

        // Offsets to scroll through noise
        Vector2[] octaveOffsets = new Vector2[octaves];
        for(int i = 0; i < octaves; i++) {
            float offsetX = prng.Next(-100000, 100000) + offset.x;
            float offsetY = prng.Next(-100000, 100000) + offset.y;
            octaveOffsets[i] = new Vector2(offsetX, offsetY);
        }

        // Ensure scale isn't equal to or less than 0, will crash Unity if it is
        if(scale <= 0) {
            scale = 0.000001f;
        }

        // Variables to keep track of max and min noise height and width values
        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;

        // Variables to keep noise scale towards the center
        float halfWidth = mapWidth / 2f;
        float halfHeight = mapHeight / 2f;

        // Generate the noise map
        for(int y = 0; y < mapHeight; y++) {
            for(int x = 0; x < mapWidth; x++) {
                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0;

                // Create octaves
                for (int i = 0; i < octaves; i++) {
                    // Calculate x and y values based on parameters
                    float sampleX = (x - halfWidth) / scale * frequency + octaveOffsets[i].x;
                    float sampleY = (y - halfHeight) / scale * frequency + octaveOffsets[i].y;

                    // Use x and y values to create noise
                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
                    noiseHeight += perlinValue * amplitude;

                    // Update amplitude and frequency variables
                    amplitude *= persistance;
                    frequency *= lacunarity;
                }

                // Update max and min noise height if needed
                if(noiseHeight > maxNoiseHeight) {
                    maxNoiseHeight = noiseHeight;
                } else if(noiseHeight < minNoiseHeight) {
                    minNoiseHeight = noiseHeight;
                }

                noiseMap[x, y] = noiseHeight;
            }
        }

        // Normalize noise height (keep it between -1 and 1)
        for (int y = 0; y < mapHeight; y++) {
            for (int x = 0; x < mapWidth; x++) {
                noiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x, y]);
            }
        }

        return noiseMap;
    }
}
