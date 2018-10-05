using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipscript : MonoBehaviour
{
    public float shipSpeed;
    public float shipTurn;
    public Color turnRightColor;
    public Color turnLeftColor;

    // Use this for initialization
    void Start()
    {
        shipSpeed = 0.15f;
        shipTurn = 4f;
        
    }

    // Update is called once per frame
    void Update()
    {
        // roterar z-axeln medsols
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate( 0, 0, -shipTurn);
        }
        // roterar z-axeln motsols
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate( 0, 0, shipTurn);
        }
        // kör skeppet hälften av normal hastighet...
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, shipSpeed/2, 0);
        }
        // ... eller kör skeppet normal hastighet
        else
        {
            transform.Translate(0, shipSpeed, 0);
        }
    }
}
