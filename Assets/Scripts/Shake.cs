using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    [SerializeField]
    Animator camAnim = null;

    public void CamShake()
    {
        camAnim.SetTrigger("shake");
    }
}
