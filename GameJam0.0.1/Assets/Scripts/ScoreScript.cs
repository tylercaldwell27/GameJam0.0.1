﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreScript : MonoBehaviour
{   
    public static int scoreValue = 0;
    public Text score;

    // Start is called before the first frame update
    public void Start()
    {
        score.GetComponent<Text>();
    }

    // Update is called once per frame
    public void Update()
    {
        score.text = "Score:" + scoreValue;
        Debug.Log("Score:" + scoreValue);
    }
}