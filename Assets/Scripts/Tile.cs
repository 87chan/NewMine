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

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetSprite(TileType type)
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
        Debug.Log("クリック");
    }
}
