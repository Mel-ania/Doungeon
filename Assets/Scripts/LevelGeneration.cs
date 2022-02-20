using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    private int direction;
    private int downCounter;

    private float moveAmount = 10;
    private float timeBtwRoom;
    private float startTimeBtwRoom = 0.1f;
    private float minX = -5;
    private float maxX = 25;
    private float minY = -25;

    private bool stopGeneration = false;

    [SerializeField]
    Transform[] startedPositions = null;
    [SerializeField]
    GameObject[] rooms = null; // i=0 LR  i=1 LRB  i=2 LRBT  i=3 LRT
    [SerializeField]
    GameObject key = null;
    [SerializeField]
    LayerMask room = default;


    private void Start()
    {
        timeBtwRoom = startTimeBtwRoom;
        int randStartingPos = Random.Range(0, startedPositions.Length);
        transform.position = startedPositions[randStartingPos].position;
        Instantiate(rooms[0], transform.position, Quaternion.identity);
        direction = Random.Range(1, 6);
    }

    private void Update()
    {
        if(timeBtwRoom <= 0 && stopGeneration == false)
        {
            Move();
            timeBtwRoom = startTimeBtwRoom;
        }
        else
        {
            timeBtwRoom -= Time.deltaTime;
        }
    }

    private void Move()
    {
        if(direction == 1 || direction == 2) // GO RIGHT
        {
            if (transform.position.x < maxX)
            {
                downCounter = 0;
                Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                transform.position = newPos;

                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(1, 4);
            }
            else
            {
                direction = 3;
            }
        }
        else if (direction == 4 || direction == 5) // GO LEFT
        {
            if (transform.position.x > minX)
            {
                downCounter = 0;
                Vector2 newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
                transform.position = newPos;

                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(3, 6);
            }
            else
            {
                direction = 3;
            }
        }
        else if (direction == 3) // GO DOWN
        {
            downCounter++;

            if (transform.position.y > minY)
            {
                Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, room);
                if(roomDetection.GetComponent<RoomType>().Type() != 1 && roomDetection.GetComponent<RoomType>().Type() != 2)
                {
                    roomDetection.GetComponent<RoomType>().RoomDestruction();
                    if (downCounter >= 2)
                    {
                        Instantiate(rooms[2], transform.position, Quaternion.identity);
                    }
                    else
                    {
                        int randBottomRoom = Random.Range(1, 3);
                        Instantiate(rooms[randBottomRoom], transform.position, Quaternion.identity);
                    }
                    
                }

                Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmount);
                transform.position = newPos;

                int rand = Random.Range(2, 4);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(1, 6);
            }
            else
            {
                Instantiate(key, transform.position, Quaternion.identity);
                stopGeneration = true;
            }
        }
    }

    public bool Stop()
    {
        return stopGeneration;
    }

    public GameObject[] Rooms()
    {
        return rooms;
    }
}
