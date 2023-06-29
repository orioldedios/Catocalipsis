using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public int x;
    public int y;
    public int i;
    public int enemies_on_map = 0;
    public int max_enemies_on_map = 0;
    public float spawn_velocity = 0.0f;


    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemies_on_map < max_enemies_on_map)
        {


            i = Random.Range(1, 5);

            switch (i)
            {
                case 1:
                    x = Random.Range(-10, 10);
                    y = 7;
                    break;
                case 2:
                    x = -10;
                    y = Random.Range(-6, 6);
                    break;
                case 3:
                    x = Random.Range(-10, 10);
                    y = -7;
                    break;
                case 4:
                    x = 10;
                    y = Random.Range(-6, 6);
                    break;

            }

            Instantiate(enemy, new Vector3(x, y, 0), Quaternion.identity);
            yield return new WaitForSeconds(spawn_velocity);

            if(spawn_velocity > 0.5)
                spawn_velocity -= 0.1f;

            enemies_on_map += 1;
        }
    }


}
