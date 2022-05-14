using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{

    public Text scoreText;
    public Text healthText;
    public CollisonHandler collisionHandler;

    void Start()
    {
        scoreText.text = collisionHandler.score.ToString() + "Points";
        healthText.text = collisionHandler.playerHealth.ToString() + "Health";

    }

    void Update()
    {
        scoreText.text = collisionHandler.score.ToString() + "Points";
        healthText.text = collisionHandler.playerHealth.ToString() + "Health";

    }
}
