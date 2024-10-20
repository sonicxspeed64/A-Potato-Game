using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class scrTaterDropper : MonoBehaviour
{
    public float xspeed, taterTimer;
    public int leftBound, rightBound;
    bool paused = false;
    public int[] tater = { 0, 0, 0, 0 };

    public GameObject Potato, currPotato;

    // Start is called before the first frame update
    void Start()
    {
        taterTimer = 0;

        for (int k = 0; k < 4; k ++)
        tater[k] = taterGen();

        GameObject go = Instantiate(Potato, transform.position, Quaternion.identity);
        currPotato = go;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 motion = new Vector3(Input.GetAxisRaw("Horizontal") * xspeed * Time.deltaTime, 0, 0);
        transform.position += motion;

        if (transform.position.x < leftBound || transform.position.x > rightBound) transform.position -= motion;

        currPotato.transform.position = transform.position;

        if (taterTimer > 0) taterTimer -= Time.deltaTime;
        else
        {
            if (tater[0] == 0)
            {
                for (int k = 0; k < 3; k++)
                    tater[k] = tater[k + 1];

                tater[3] = taterGen();
            }

            if (Input.GetButtonDown("Drop"))
            {
                //do some code here

                GameObject go = Instantiate(Potato, transform.position, Quaternion.identity);
                currPotato = go;

                tater[0] = 0;
                taterTimer = 0.2f;
            }
        }

        if (Input.GetButtonDown("Pause")) paused = togglePause();
    }

    bool togglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            return false;
        }
        else
        {
            Time.timeScale = 0f;
            return true;
        }
    }

    int taterGen()
    {
        int tot = Random.Range(1, 8+1);

        return tot;
    }
}
