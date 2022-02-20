using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    private int health = 1;
    [SerializeField]
    GameObject destroyEffect = null;

    private void Update()
    {
        if(health <= 0)
        {
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void DecreaseHealth()
    {
        health--;
    }
}
