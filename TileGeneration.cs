using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using UnityEngine.Tilemaps;
using UnityEditor;

public class TileGeneration : MonoBehaviour {

    public Vector3Int tmpSize;

    public static int mapwidth;
    public static int mapheight;

    public Tilemap WaterMap;
    public Tilemap LandMap;

    public Tile TownTile;

    public Tile ShallowWaterTile;
    public Tile DeepWaterTile;

    public Tile GrassTile;
    public Tile DirtTile;


    public string Seed = "apple";
    private float xOffset;
    private float yOffset;
    private System.Random pseudoRandom;


    private int width;
    private int height;

    void Start()
    {
        float freqmult = 1.2f;
        int fx1 = 3;
        int fx2 = 8;

        int fy1 = 2;
        int fy2 = 15;

        width = tmpSize.x;
        height = tmpSize.y;

        mapwidth = width;
        mapheight = height;

        // Get Random Number Generator
        pseudoRandom = new System.Random(Seed.GetHashCode());
        // Set Offsets from seed (new world each time)

        xOffset = pseudoRandom.Next(-10000, 10000);
        yOffset = pseudoRandom.Next(-10000, 10000);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                //if (terrainMap[x, y] == 1)

                float FinalX = 5f * noisegen_X(fx1 * width, x, xOffset) + 0.2f * noisegen_X(fx2 * width, x, xOffset) + 14f * noisegen_X(fx2 * width, x, xOffset);
                float FinalY = 5f * noisegen_Y(fy1 * height, y, yOffset) + 0.2f * noisegen_Y(fy2 * height, y, yOffset) + 14f * noisegen_Y(fy2 * height, y, yOffset);

                float noise = Mathf.PerlinNoise(FinalX * freqmult, FinalY * freqmult);
                //Debug.Log("(" + finalx + "," + finaly + ")" + noise);


                if((x > 0.13 * width && x < 0.23 * width && y > 0.15 * height && y < 0.25 * height) || (x > 0.85 * width && x < 0.95 * width && y > 0.35 * height && y < 0.45 * height) || (x > 0.13 * width && x < 0.23 * width && y > 0.85 * height && y < 0.95 * height))
                {
                    LandMap.SetTile(new Vector3Int(x, y, 0), TownTile); //add more?
                }
                else
                {
                    terrain(noise, x, y);
                }

                //SampleTile = MajorMap.GetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0);
            }
        }
    }

    float noisegen_X(int w, int Xc, float Xoff)
    {
        float finalx = (float)Xc / w + Xoff;

        return finalx;

    }

    float noisegen_Y(int h, int Yc, float Yoff)
    {
        float finaly = (float)Yc / h + Yoff;

        return finaly;

    }

    void terrain(float e, int x, int y)
    {
        if (e < 0.20)
        {
            WaterMap.SetTile(new Vector3Int(x, y, 0), DeepWaterTile); //add more?
        }
        if (e < 0.30 && e > 0.20)
        {
            LandMap.SetTile(new Vector3Int(x, y, 0), ShallowWaterTile); //add more?
        }
        if (e > 0.30 && e < 0.45)
        {
            LandMap.SetTile(new Vector3Int(x, y, 0), DirtTile); //add more?
        }
        if (e > 0.45)
        {
            LandMap.SetTile(new Vector3Int(x, y, 0), GrassTile); //add more?
        }
    }

}