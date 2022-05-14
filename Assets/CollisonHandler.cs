using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonHandler : MonoBehaviour
{
    [SerializeField] int playerMaxHealth;
    public int playerHealth;
    public int score;
    public GameObject damagePrefab;
    public bool canHit;
    public float timerCount;
    [SerializeField] float hitCooldown;
    private bool startCount = false;
    private void Start()
    {
        canHit = true;
        score = 0;
        playerHealth = playerMaxHealth;
    }
    private void Update()
    {
        if (startCount)
        {
            timerCount += Time.deltaTime;
        }
        if (timerCount >= hitCooldown)
        {
            canHit = true;
            timerCount = 0;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.collider.tag)
        {
            case "Enemy":
                DoDamage();
                break;

            case "Point":
                score++;
                Destroy(collision.gameObject);
                PointSpawner.alivePoints--;
                Debug.Log("Point");
                break;
        }
    }

    private void DoDamage()
    {
        if (canHit)
        {
            StartTimer();
            canHit = false;
            playerHealth--;
            Instantiate(damagePrefab, transform.position, transform.rotation);
            Debug.Log("Hit!");
        }
        

    }

    private void StartTimer()
    {
        startCount = true;
    }

}
