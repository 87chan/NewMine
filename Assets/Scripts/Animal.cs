using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour {

    TileType animal_type;
    DirectionType direction_type;
    Vector2 current_pos;
    int extend_num;
    int left_extend_num;
    bool is_complete_extend = false;

    public TileType GetAnimalType() { return animal_type; }
    public DirectionType GetDirectionType() { return direction_type; }
    public Vector2 GetCurrentPos() { return current_pos; }
    public int GetExtendNum() { return extend_num; }
    public bool GetIsCompleteExtend() { return is_complete_extend; }

    public void SetAnimalType(TileType type) { animal_type = type; }
    public void SetDirectionType(DirectionType type) { direction_type = type; }
    public void SetCurrentPos(Vector2 pos) { current_pos = pos; }

    public void InitializeExtendNum(int num)
    {
        extend_num = num;
        left_extend_num = num;
    }

    public void DecreaseLeftExtendNum()
    {
        left_extend_num--;

        if (left_extend_num <= 0)
        {
            left_extend_num = 0;
            is_complete_extend = true;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
