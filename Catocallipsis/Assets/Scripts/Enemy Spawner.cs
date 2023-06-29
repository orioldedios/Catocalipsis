using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public int x;
    public int y;
    public int i;

    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        i = Random.Range(1, 4);

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

        Instantiate(enemy, new Vector3(x, y, 0),Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
    }
}
