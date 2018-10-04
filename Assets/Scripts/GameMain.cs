using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour {

    const int TILE_SIZE = 32;

    public Tile tile;

    public Sprite sprite_field;
    public Sprite sprite_legend;
    public Sprite sprite_beast;
    public Sprite sprite_grass;
    public Sprite sprite_footprint_u;
    public Sprite sprite_footprint_ur;
    public Sprite sprite_footprint_r;
    public Sprite sprite_footprint_dr;
    public Sprite sprite_footprint_d;
    public Sprite sprite_footprint_dl;
    public Sprite sprite_footprint_l;
    public Sprite sprite_footprint_ul;

    public bool is_full_view;

    public int width;
    public int height;

    public bool is_game_over;
    public bool is_game_clear;

    Tile[,] tiles;

    // Use this for initialization
    void Start()
    {
        tiles = new Tile[width, height];

        Vector3 offset = new Vector3(((width * TILE_SIZE) * -0.5f) + (TILE_SIZE * 0.5f), ((height * TILE_SIZE) * 0.5f) + (TILE_SIZE * -0.5f));

        for (int j = 0; j < height; ++j)
        {
            for (int i = 0; i < width; ++i)
            {
                Vector3 spawn_pos = new Vector3(i * TILE_SIZE, -(j * TILE_SIZE), 0.0f);
                Tile newTile = Instantiate(tile, spawn_pos + offset, Quaternion.identity);
                Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
                newTile.transform.SetParent(canvas.transform, false);
                newTile.SetObject(Tile.TileType.Legend);

                tiles[i, j] = newTile;
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
    }
}
