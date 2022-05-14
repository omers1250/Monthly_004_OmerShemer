using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    [SerializeField] float moveForce;
    private Rigidbody rbody;
    public Vector3 moveDir;
    public Vector3 moveDirOld;
    public LayerMask isWall;
    [SerializeField] float maxDistance;
    public Vector3 oldPos;
    float stuckCounter = 0f;
    float stuckCooldown = 1f;
    [SerializeField] float destroyStuckOffSet;
    [SerializeField] float maxRandDirCooldown;
    [SerializeField] float minRandDirCooldown;
    float changeDirCooldown;
    public float changeDirCounter = 0f;
    public Transform sphere;
    Vector3 fallSpeed = new Vector3(0, -20, 0);
    [SerializeField] float gravityMult;

    void Start()
    {
        oldPos = transform.position;
        rbody = GetComponent<Rigidbody>();
        moveDir = ChooseDirection();
        changeDirCooldown = Random.Range(minRandDirCooldown, maxRandDirCooldown);


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Wall")
        {
            moveDir = ChooseDirection();
            //Debug.Log("Changing");
        }
    }

    void Update()
    {
        rbody.velocity = moveDir * moveForce;

        if ((stuckCounter += Time.deltaTime) >= stuckCooldown)
        {
            if (Vector3.Distance(oldPos, transform.position) <= destroyStuckOffSet)
            {
                moveDir = ChooseDirection();
                //Debug.Log("ChangingStuck");

            }
            else
            {
                stuckCounter = 0f;
                oldPos = transform.position;
            }

        }
        if ((changeDirCounter += Time.deltaTime) >= changeDirCooldown)
        {
            ChangeDir();
        }



    }

    private void ChangeDir()
    {
        ChooseDirection();
        moveDir = ChooseDirection();
        changeDirCooldown = Random.Range(minRandDirCooldown, maxRandDirCooldown);
        changeDirCounter = 0f;
        //Debug.Log("ChangedDir");


    }
    public Vector3 ChooseDirection()
    {
        int rand = Random.Range(0, 4);
        int i = rand;
        Vector3 temp = new Vector3();

        if (i == 0)
        {
            temp = transform.forward;
            temp.y = -gravityMult;

        }
        else if (i == 1)
        {
            temp = -transform.forward;
            temp.y = -gravityMult;

        }
        else if (i == 2)
        {
            temp = transform.right;
            temp.y = -gravityMult;

        }
        else if (i == 3)
        {
            temp = -transform.right;
            temp.y = -gravityMult;
        }


        //Debug.Log(i);

        return temp;
    }
}
