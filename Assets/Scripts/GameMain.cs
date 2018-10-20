using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour {

    const int TILE_SIZE = 32;
    const int LEGEND_PLACEMENT_NUM = 1;

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

    public int beast_placement_num;
    public int beast_extend_num;
    public int legend_extend_num;

    public bool is_game_over;
    public bool is_game_clear;

    Tile[,] tiles;

    // Use this for initialization
    void Start()
    {
        // 周囲マスの数（レアを除く）以上は設定しないように
        Debug.Assert(beast_placement_num <= (width * 2 + (height - 2) * 2) - 1, "猛獣の配置数が多すぎます");

        tiles = new Tile[width, height];

        InitializeTiles();

        PlacementBeasts();
        PlacementLegend();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void InitializeTiles()
    {
        Vector3 offset = new Vector3(((width * TILE_SIZE) * -0.5f) + (TILE_SIZE * 0.5f), ((height * TILE_SIZE) * 0.5f) + (TILE_SIZE * -0.5f));

        for (int j = 0; j < height; ++j)
        {
            for (int i = 0; i < width; ++i)
            {
                Vector3 spawn_pos = new Vector3(i * TILE_SIZE, -(j * TILE_SIZE), 0.0f);
                Tile newTile = Instantiate(tile, spawn_pos + offset, Quaternion.identity);
                Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
                newTile.transform.SetParent(canvas.transform, false);
                tiles[i, j] = newTile;
            }
        }
    }

    void PlacementAround(Tile.TileType type)
    {
        int x = 0;
        int y = 0;

        // 周囲の空きマスを探索
        bool is_found = false;
        while (!is_found)
        {
            x = Random.Range(0, width);
            y = Random.Range(0, height);

            if (((x == 0 || x == width - 1) || (y == 0 || y == height - 1))
                && tiles[x, y].IsEmptyObject())
            {
                is_found = true;
            }
        }

        // タイプを指定
        Tile tile = tiles[x, y];
        tile.SetObject(type);
    }

    void PlacementBeasts()
    {
        for (int i = 0; i < beast_placement_num; ++i)
        {
            PlacementAround(Tile.TileType.Beast);
        }
    }

    void PlacementLegend()
    {
        PlacementAround(Tile.TileType.Legend);
    }
}
