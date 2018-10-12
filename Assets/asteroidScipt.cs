using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidScipt : MonoBehaviour
{
    public float astSpeed;
    public float astTurn;
    // Use this for initialization
    void Start()
    {
        astSpeed = 2;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(0, -astSpeed * Time.deltaTime ,0);
        Vector3 newPosition = transform.position;
        if (newPosition.y < -6 )
        {
            newPosition.y = 6;
        }
        transform.position = newPosition;
    }
}
