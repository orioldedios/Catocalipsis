using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Scoring : MonoBehaviour
{
    public int score = 0;
    public int i = 0;
    public GameObject player = null;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (i >= 3 ) 
        {
            i = 0;
            boostPlayer();
        }
    }

    void boostPlayer()
    {
        int r = Random.Range(1, 4);

        switch (r)
        {
            case 1:
                    player.GetComponent<PlayerController>().moveSpeed += 1f;
                break;
            case 2:
                if (player.GetComponent<PlayerController>().shootCooldownTime >= 0.1f)
                    player.GetComponent<PlayerController>().shootCooldownTime -= 0.1f;
                break;
            case 3:
                if (player.GetComponent<PlayerController>().currentHealth < 5)
                    player.GetComponent<PlayerController>().currentHealth += 1;
                break;
        }
    }
}
