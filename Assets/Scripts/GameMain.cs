using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour {

    const int TILE_SIZE = 32;
    const int LEGEND_PLACEMENT_NUM = 1;

    public Tile tile_ref;
    public Animal animal_ref;

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
    public int beast_extend_min_num;
    public int beast_extend_max_num;
    public int legend_extend_min_num;
    public int legend_extend_max_num;

    public bool is_game_over;
    public bool is_game_clear;

    Tile[,] tiles;
    Animal legend;
    Animal[] beasts;

    // Use this for initialization
    void Start()
    {
        // 周囲マスの数（レアを除く）以上は設定しないように
        Debug.Assert(beast_placement_num <= (width * 2 + (height - 2) * 2) - 1, "猛獣の配置数が多すぎます");

        tiles = new Tile[width, height];
        beasts = new Animal[beast_placement_num];
        legend = new Animal();

        InitializeTiles();
        InitializeAnimals();

        PlacementBeasts();
        ExtendBeasts();

        PlacementLegend();
        ExtendLegend();
    }

    // Update is called once per frame
    void Update()
    {
    }

    bool CheckExtensible(int x, int y)
    {
        // 範囲以内で空の場所
        if ((0 <= x && x < width)
            && (0 <= y && y < height))
        {
            if (tiles[x, y].IsEmptyObject())
            {
                return true;
            }
        }

        return false;
    }

    void InitializeTiles()
    {
        Vector3 offset = new Vector3(((width * TILE_SIZE) * -0.5f) + (TILE_SIZE * 0.5f), ((height * TILE_SIZE) * 0.5f) + (TILE_SIZE * -0.5f));

        for (int j = 0; j < height; ++j)
        {
            for (int i = 0; i < width; ++i)
            {
                Vector3 spawn_pos = new Vector3(i * TILE_SIZE, -(j * TILE_SIZE), 0.0f);
                Tile newTile = Instantiate(tile_ref, spawn_pos + offset, Quaternion.identity);
                Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
                newTile.transform.SetParent(canvas.transform, false);
                tiles[i, j] = newTile;
            }
        }
    }

    void InitializeAnimals()
    {
        legend = Instantiate(animal_ref, new Vector3(), Quaternion.identity);

        for (int i = 0; i < beast_placement_num; ++i)
        {
            beasts[i] = Instantiate(animal_ref, new Vector3(), Quaternion.identity);
        }
    }

    void PlacementAround(TileType type, int index = 0)
    {
        int x = 0;
        int y = 0;

        // 周囲の空きマスを探索
        while (true)
        {
            x = Random.Range(0, width);
            y = Random.Range(0, height);

            if (((x == 0 || x == width - 1) || (y == 0 || y == height - 1))
                && tiles[x, y].IsEmptyObject())
            {
                break;
            }
        }

        // タイプを指定
        Tile tile = tiles[x, y];
        tile.SetObject(type);
        int extend_num = 0;

        switch (type)
        {
            case TileType.Legend:
                legend.SetAnimalType(type);
                legend.SetCurrentPos(new Vector2(x, y));

                extend_num = Random.Range(legend_extend_min_num, legend_extend_max_num + 1);
                legend.InitializeExtendNum(extend_num);
                break;

            case TileType.Beast:
                Animal beast = beasts[index];
                beast.SetAnimalType(type);
                beast.SetCurrentPos(new Vector2(x, y));

                extend_num = Random.Range(beast_extend_min_num, beast_extend_max_num + 1);
                beast.InitializeExtendNum(extend_num);
                break;

            default:
                break;
        }
    }

    void PlacementBeasts()
    {
        for (int i = 0; i < beast_placement_num; ++i)
        {
            PlacementAround(TileType.Beast, i);
        }
    }

    void PlacementLegend()
    {
        PlacementAround(TileType.Legend);
    }

    bool CheckCompleteExtendBeasts()
    {
        for (int i = 0; i < beast_placement_num; ++i)
        {
            Animal beast = beasts[i];
            if (!beast.GetIsCompleteExtend())
            {
                return false;
            }
        }

        return true;
    }

    void ExtendOneStep(Animal animal, int new_x, int new_y)
    {
        int x = (int)animal.GetCurrentPos().x;
        int y = (int)animal.GetCurrentPos().y;

        DirectionType new_direction = Utility.ConvertToDirectionType(new Vector2(new_x - x, new_y - y));
        animal.SetDirectionType(new_direction);

        // 前回位置に足跡を設定
        Tile tile = tiles[x, y];
        tile.SetObject((TileType)((int)TileType.Footprint_U + new_direction));

        // 新しい位置の設定
        tile = tiles[new_x, new_y];
        tile.SetObject(animal.GetAnimalType());
        animal.SetCurrentPos(new Vector2(new_x, new_y));

        animal.DecreaseLeftExtendNum();
    }

    void ExtendBeastsOneStep()
    {
        for (int i = 0; i < beast_placement_num; ++i)
        {
            Animal beast = beasts[i];
            if(beast.GetIsCompleteExtend())
            {
                break;
            }

            Vector2 new_pos = new Vector2();
            while (true)
            {
                Vector2 direction_vector = Utility.ConvertToDirectionVector(Utility.GetRandomDirectionType());
                new_pos = beast.GetCurrentPos() + direction_vector;
                if (CheckExtensible((int)new_pos.x, (int)new_pos.y))
                {
                    break;
                }
            }

            ExtendOneStep(beast, (int)new_pos.x, (int)new_pos.y);
        }
    }

    void ExtendBeasts()
    {
        while(true)
        {
            ExtendBeastsOneStep();

            if (CheckCompleteExtendBeasts())
            {
                break;
            }
        }
    }

    void ExtendLegend()
    {
    }
}
