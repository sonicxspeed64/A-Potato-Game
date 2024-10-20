using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrTater : MonoBehaviour
{
    public bool dropped;
    public Rigidbody rig;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Drop"))
        {
            dropped = true;
            rig.useGravity = true;
        }
    }
}
