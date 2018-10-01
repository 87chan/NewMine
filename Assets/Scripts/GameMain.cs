﻿using System.Collections;
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

    public int width;
    public int height;

    Tile[,] tiles;

    // Use this for initialization
    void Start()
    {
        tiles = new Tile[width, height];

        for (int j = 0; j < height; ++j)
        {
            for (int i = 0; i < width; ++i)
            {
                Vector3 spawn_pos = new Vector3(i * TILE_SIZE, -(j * TILE_SIZE), 0.0f);
                Tile newTile = Instantiate(tile, spawn_pos, Quaternion.identity);
                Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
                newTile.transform.SetParent(canvas.transform, false);
                newTile.SetObject(Tile.TileType.Beast);

                tiles[i, j] = newTile;
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
    }
}
