using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class scrTaterDropper : MonoBehaviour
{
    public float xspeed;
    public int leftBound, rightBound;
    bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 motion = new Vector3(Input.GetAxisRaw("Horizontal") * xspeed * Time.deltaTime, 0, 0);
        transform.position += motion;

        if (transform.position.x < leftBound || transform.position.x > rightBound) transform.position -= motion;

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
}
