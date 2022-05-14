using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    GameObject player;
    Rigidbody rb;
    [SerializeField] public float movementSpeed;


    void Start()
    {
        player = FindObjectOfType<CollisonHandler>().gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)     //following player 
        {
            Vector3 vectToPlayer = (player.transform.position - transform.position);
            transform.position += vectToPlayer.normalized * movementSpeed * Time.deltaTime;
            transform.LookAt(player.transform);

            transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
        }

    }
}
