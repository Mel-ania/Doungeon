using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManagement : MonoBehaviour
{
    private int score = 0;
    [SerializeField]
    TextMeshProUGUI scoreDisplay = null;
    [SerializeField]
    GameObject soundEffect = null;

    private void Update()
    {
        scoreDisplay.text = "SCORE " + score;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coins"))
        {
            Instantiate(soundEffect, transform.position, Quaternion.identity);
            score++;
        }
    }

}
