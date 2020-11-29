using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class TileGeneration : MonoBehaviour {


    //public Transform player;

    [Range(0,100)]
    public int iniChance;
    [Range(1,8)]
    public int birthLimit;
    [Range(1,8)]
    public int deathLimit;

    [Range(1,10)]
    public int numR;
    private int count = 0;
    private int decotilespawn;

    private int[,] terrainMap;

    
    public Vector3Int tmpSize;


    public static int mapwidth;
    public static int mapheight;

    public Tilemap MinorMap;
    public Tilemap MajorMap;
    public Tile MinorTile;
    public Tile MajorTile;

    public Tilemap GrassMap;

    public Tile CommonGrassTile;
    public Tile UncommonGrassTile;
    public Tile RareGrassTile;

    public Tile RareDecoTile;
    public Tile DecoPlant1;
    public Tile DecoPlant2;
    public Tile DecoPlant3;


    private int width;
    private int height;

    private bool Simulate = true;
    public bool ClearMap;

    public void doSim(int nu)
    {
        clearMap(false);
        width = tmpSize.x;
        height = tmpSize.y;

        mapwidth = width;
        mapheight = height;

        if (terrainMap==null)
            {
            terrainMap = new int[width, height];
            initPos();
            }


        for (int i = 0; i < nu; i++)
        {
            terrainMap = genTilePos(terrainMap);
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (terrainMap[x, y] == 1)
                    MinorMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), MinorTile);
                    MajorMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), MajorTile); //add more?

                //SampleTile = MajorMap.GetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0);


                if (Random.Range(1, 10) < 6) //60%
                {
                    if (Random.Range(1, 10) <= 3) 
                    {
                        if (Random.Range(1, 3) == 1) 
                        {
                            GrassMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), RareGrassTile);
                        }
                        else if (Random.Range(1, 3) >= 2)
                        {
                            GrassMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), RareDecoTile);
                        }
                    }
                    else if (Random.Range(1, 10) > 5) //50%
                    {
                        GrassMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), CommonGrassTile);
                    }
                    else if (Random.Range(1, 10) > 1 && Random.Range(1, 10) <= 4) //30%
                    {
                        decotilespawn = Random.Range(1, 4);

                        switch (decotilespawn)
                        {
                            case 1:
                                GrassMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), UncommonGrassTile);
                                break;
                            case 2:
                                GrassMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), DecoPlant1);
                                break;
                            case 3:
                                GrassMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), DecoPlant2);
                                break;
                            case 4:
                                GrassMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), DecoPlant3);
                                break;
                        }   



                        

                    }


                }
                else if (Random.Range(1, 10) > 6) //40%
                {
                    GrassMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), CommonGrassTile);
                }
            }
        }


    }

    public void initPos()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                terrainMap[x, y] = Random.Range(1, 101) < iniChance ? 1 : 0;
            }

        }

    }


    public int[,] genTilePos(int[,] oldMap)
    {
        int[,] newMap = new int[width,height];
        int neighb;
        BoundsInt myB = new BoundsInt(-1, -1, 0, 3, 3, 1);


        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                neighb = 0;
                foreach (var b in myB.allPositionsWithin)
                {
                    if (b.x == 0 && b.y == 0) continue;
                    if (x+b.x >= 0 && x+b.x < width && y+b.y >= 0 && y+b.y < height)
                    {
                        neighb += oldMap[x + b.x, y + b.y];
                    }
                    else
                    {
                        neighb++;
                    }
                }

                if (oldMap[x,y] == 1)
                {
                    if (neighb < deathLimit) newMap[x, y] = 0;

                        else
                        {
                            newMap[x, y] = 1;

                        }
                }

                if (oldMap[x,y] == 0)
                {
                    if (neighb > birthLimit) newMap[x, y] = 1;

                else
                {
                    newMap[x, y] = 0;
                }
                }

            }

        }



        return newMap;
    }


	void Update () {
        if (Simulate)
        {

            doSim(numR);
            Simulate = false;
            
        }


        if (ClearMap)
        {
            clearMap(true);
            ClearMap = false;
            Simulate = true;
        }


    }



    public void clearMap(bool complete)
    {

        MinorMap.ClearAllTiles();
        MajorMap.ClearAllTiles();
        GrassMap.ClearAllTiles();
        if (complete)
        {
            terrainMap = null;
        }


    }



}