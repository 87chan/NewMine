using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    public enum TileType
    {
        Field,
        Legend,
        Beast,
        Grass,
        Footprint_U,
        Footprint_UR,
        Footprint_R,
        Footprint_DR,
        Footprint_D,
        Footprint_DL,
        Footprint_L,
        Footprint_UL,
    }

    TileType tile_type;
    bool is_open = false;

    // Use this for initialization
    void Start ()
    {
        GameMain game_main = GameObject.Find("GameMain").GetComponent<GameMain>();

        if (!game_main.is_full_view)
        {
            SetSprite(TileType.Grass);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SetObject(TileType type)
    {
        GameMain game_main = GameObject.Find("GameMain").GetComponent<GameMain>();

        tile_type = type;

        if (game_main.is_full_view)
        {
            SetSprite(tile_type);
        }
    }

    void SetSprite(TileType type)
    {
        GameMain game_main = GameObject.Find("GameMain").GetComponent<GameMain>();
        SpriteRenderer sprite = transform.FindChild("Object").GetComponent<SpriteRenderer>();

        Sprite new_sprite = null;
        switch(type)
        {
            case TileType.Field:
                new_sprite = game_main.sprite_field;
                break;
            case TileType.Legend:
                new_sprite = game_main.sprite_legend;
                break;
            case TileType.Beast:
                new_sprite = game_main.sprite_beast;
                break;
            case TileType.Grass:
                new_sprite = game_main.sprite_grass;
                break;
            case TileType.Footprint_U:
                new_sprite = game_main.sprite_footprint_u;
                break;
            case TileType.Footprint_UR:
                new_sprite = game_main.sprite_footprint_ur;
                break;
            case TileType.Footprint_R:
                new_sprite = game_main.sprite_footprint_r;
                break;
            case TileType.Footprint_DR:
                new_sprite = game_main.sprite_footprint_dr;
                break;
            case TileType.Footprint_D:
                new_sprite = game_main.sprite_footprint_d;
                break;
            case TileType.Footprint_DL:
                new_sprite = game_main.sprite_footprint_dl;
                break;
            case TileType.Footprint_L:
                new_sprite = game_main.sprite_footprint_l;
                break;
            case TileType.Footprint_UL:
                new_sprite = game_main.sprite_footprint_ul;
                break;
        }
        sprite.sprite = new_sprite;
    }

    public void OnClick()
    {
        GameMain game_main = GameObject.Find("GameMain").GetComponent<GameMain>();

        if (!game_main.is_game_over
            && !game_main.is_game_clear
            && !is_open)
        {
            is_open = true;

            SetSprite(tile_type);

            switch(tile_type)
            {
                case TileType.Legend:
                    game_main.is_game_clear = true;
                    break;
                case TileType.Beast:
                    game_main.is_game_over = true;
                    break;
                default:
                    break;

            }
        }
    }
}
