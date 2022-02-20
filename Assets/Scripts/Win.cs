using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField]
    GameObject effect = null;

    private void Start()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
    }
}
