using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{

    public GameObject toSpawn;
    public bool executie = false;
    public Transform spawner;
    private int cooldown = 0;

    void Start()
    {
        spawner = GetComponent<Transform>();
    }

    void Update()
    {
        if (Player_Controller.Instance.stage == 1)
        {
            executie = true;
        }
        if (Player_Controller.Instance.stage == 2 && executie == true)
        {
            executie = false;
            SpawnEnemy();
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        int number_of_enemies = enemies.Length;

        if (number_of_enemies == 0)
            SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        cooldown -= 1;
        if (cooldown <= 0)
        {
            Instantiate(toSpawn, new Vector3(spawner.position.x, spawner.position.y, spawner.position.z), Quaternion.identity);
            cooldown = 2;
        }
    }
}
