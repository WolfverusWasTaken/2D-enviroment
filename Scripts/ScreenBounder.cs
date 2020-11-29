using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBounder : MonoBehaviour
{
    private Vector2 screenBounds;
    public GameObject PlayerObj;
    public Transform Player;

    private static int mapsizewidth;
    private static int mapsizeheight;

    public float playervel;

    public Rigidbody2D rb;
    public float screenboundx;
    public float screenboundy;
    public float cloneposx;
    public float cloneposy;

    public float pposx;
    public float pposy;

    public static int inmapspawns;


    // Start is called before the first frame update
    void Start()
    {
        PlayerObj = GameObject.Find("Deer");
        Player = PlayerObj.transform;
        rb = this.GetComponent<Rigidbody2D>();

        mapsizewidth = TileGeneration.mapwidth;
        mapsizeheight = TileGeneration.mapheight;
    }

    // Update is called once per frame
    void Update()
    {
        cloneposx = transform.position.x;
        cloneposy = transform.position.y;
        pposx = Player.position.x;
        pposy = Player.position.y;

        playervel = rb.velocity.sqrMagnitude;

        if (cloneposx > pposx + 15 || cloneposx < pposx - 15 || cloneposy > pposy + 15 || cloneposy < pposy - 15)
        {
            Destroy(this.gameObject);
            inmapspawns = inmapspawns - 1;
            ScreenSpawner.totalspawns = inmapspawns;
        }

        if (cloneposx > mapsizewidth/2 || cloneposx < -mapsizewidth/2 || cloneposy > mapsizeheight/2 || cloneposy < -mapsizeheight/2)
        {
            Destroy(this.gameObject);
            inmapspawns = inmapspawns - 1;
            ScreenSpawner.totalspawns = inmapspawns;
        }

        /*
        if(rb.Isleeping())
        {
            Debug.Log("Die");
        }*/
    }
}
