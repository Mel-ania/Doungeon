using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomType : MonoBehaviour
{
    [SerializeField]
    int type = 0;

    public void RoomDestruction()
    {
        Destroy(gameObject);
    }

    public int Type()
    {
        return type;
    }
}
