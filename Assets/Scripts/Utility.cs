using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour {

    public static DirectionType GetRandomDirectionType()
    {
        return (DirectionType)((int)Random.Range(0,9));
    }

    public static Vector2 ConvertToDirectionVector(DirectionType type)
    {
        switch(type)
        {
            case DirectionType.U:
                return new Vector2(0, -1);
            case DirectionType.UR:
                return new Vector2(1, -1);
            case DirectionType.R:
                return new Vector2(1, 0);
            case DirectionType.DR:
                return new Vector2(1, 1);
            case DirectionType.D:
                return new Vector2(0, 1);
            case DirectionType.DL:
                return new Vector2(-1, 1);
            case DirectionType.L:
                return new Vector2(-1, 0);
            case DirectionType.UL:
                return new Vector2(-1, -1);
            default:
                return new Vector2(0, 0);
        }
    }

    public static DirectionType ConvertToDirectionType(Vector2 vector)
    {
        if(vector.x == 0 && vector.y == -1)
        {
            return DirectionType.U;
        }
        if (vector.x == 1 && vector.y == -1)
        {
            return DirectionType.UR;
        }
        if (vector.x == 1 && vector.y == 0)
        {
            return DirectionType.R;
        }
        if (vector.x == 1 && vector.y == 1)
        {
            return DirectionType.DR;
        }
        if (vector.x == 0 && vector.y == 1)
        {
            return DirectionType.D;
        }
        if (vector.x == -1 && vector.y == 1)
        {
            return DirectionType.DL;
        }
        if (vector.x == -1 && vector.y == 0)
        {
            return DirectionType.L;
        }
        if (vector.x == -1 && vector.y == -1)
        {
            return DirectionType.UL;
        }

        return DirectionType.None;
    }

}
