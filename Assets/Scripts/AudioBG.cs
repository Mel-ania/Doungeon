using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBG : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
