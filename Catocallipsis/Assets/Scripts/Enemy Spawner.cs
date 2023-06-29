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
        
    }

    IEnumerator EnemyDrop()
    {
        i = Random.Range(1,4);

        switch(i)
        {
            CASE 1:
            {
                x = Random.Range(-10, 10);
                y = 7;
                brake;
            }
            CASE 2:
            {
                x = -10;
                y = Random.Range(-6,6);
                brake;
            }
            CASE 3:
            {
                x = Random.Range(-10, 10);
                y = -7;
                brake;
            }
            CASE 4:
            {
                x = 10;
                y = Random.Range(-6,6);
                brake;
            }
        }

        Instantiate(enemy, new Vector3(x,y,0));
        yeild return new WaitForSeconds(0.5f);
    }
}
