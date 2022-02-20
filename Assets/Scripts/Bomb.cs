using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private float timer = 2;
    private float areaOfEffect = 0.75f;
    [SerializeField]
    LayerMask whatIsDestructible = default;
    [SerializeField]
    GameObject effect = null;

    private void Update()
    {
        if(timer <= 0)
        {
            Collider2D[] objectsToDamage = Physics2D.OverlapCircleAll(transform.position, areaOfEffect, whatIsDestructible);
            for (int i = 0; i < objectsToDamage.Length; i++)
            {
                objectsToDamage[i].GetComponent<Destructible>().DecreaseHealth();
            }
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, areaOfEffect);
    }
}
