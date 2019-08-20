using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pmouv : MonoBehaviour {

    public float horiSpeed;
    public float vertiSpeed;

    public float constVel;
    public float sprintVel;

    // Use this for initialization
    void Start()
    {
        constVel = horiSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * horiSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * vertiSpeed;

        transform.Translate(x, 0, z);

        if (Input.GetKey(KeyCode.LeftShift))
        {

            vertiSpeed = sprintVel;
        }
        else
        {
            vertiSpeed = constVel;
        }
    }
}
