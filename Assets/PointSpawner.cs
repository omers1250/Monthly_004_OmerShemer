using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawner : MonoBehaviour
{
    public GameObject points;
    [SerializeField] float spawnDistFromPlayer;
    public static int alivePoints = 0;
    public static int desiredPoints = 3;
    GameObject player;

    private void Awake()
    {
        player = FindObjectOfType<CollisonHandler>().gameObject;
    }

    public void SpawnEnemyBasic()
    {
        Vector3 spawnPoint = SelectSpawnPosition();
        Instantiate(points, spawnPoint, Quaternion.identity);
    }


    Vector3 SelectSpawnPosition()
    {
        Vector2 rnd = Random.insideUnitCircle.normalized * 2;
        Vector3 rnd3 = new Vector3(rnd.x, 0, rnd.y) * spawnDistFromPlayer;

        rnd3[1] = player.transform.position.y; // Spawn them in the air because they have gravity so it works, so they don't spawn inside of the hills but on top of them

        return rnd3;
    }

    bool canSpawn = true;
    public static float spawnOffsetBasic = 3f;


    IEnumerator SpawnAgainCorountineBasic()
    {
        yield return new WaitForSeconds(spawnOffsetBasic);
        canSpawn = true;
    }
    void Update()
    {
        spawnBasic();
    }




    void spawnBasic()

    {
        while (alivePoints < desiredPoints && canSpawn)
        {
            SpawnEnemyBasic();
            alivePoints++;
            canSpawn = false;
            StartCoroutine(SpawnAgainCorountineBasic());
            break;
        }

    }


}

