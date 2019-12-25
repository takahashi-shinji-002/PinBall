using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    private GameObject scoreText;

    private int score;

    // Use this for initialization
    void Start()
    {
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
         this.scoreText.GetComponent<Text>().text = "score: " + score;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "SmallStarTag")
        {
            score += 10;
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            score += 20;
        }
        else if (other.gameObject.tag == "SmallCloudTag")
        {
            score += 30;
        }
        else if (other.gameObject.tag == "LargeCloudTag")
        {
            score += 50;
        }
    }
}
    




