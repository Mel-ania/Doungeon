using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRooms : MonoBehaviour
{
    [SerializeField]
    LayerMask whatIsRoom = default;
    [SerializeField]
    LevelGeneration levGen = null;

    private void Update()
    {
        Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, whatIsRoom);
        if(roomDetection == null && levGen.Stop() == true)
        {
            // SPAWN A ROOM
            int rand = Random.Range(0, levGen.Rooms().Length);
            Instantiate(levGen.Rooms()[rand], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
