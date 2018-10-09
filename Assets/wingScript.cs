using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wingScript : MonoBehaviour
{
    Renderer rend;
    public float pulseColorRed;
    public float pulseColorGreen;
    public float pulseColorBlue;
    public Color pulseColor;

    // Use this for initialization
    void Start()
    {
        // värden
        rend = GetComponent<Renderer>();
        // 1.2 för mer tid av fullt ljus
        pulseColorRed = 1.2f;
        pulseColorGreen = 0;
        pulseColorBlue = 0;

    }

    // Update is called once per frame
    void Update()
    {
        // pulsfärgen är en blandning av Röd, Grön och Blå
        pulseColor = new Color(pulseColorRed, pulseColorGreen, pulseColorBlue);
        // sänker Röd ett antal gånger per sekund
        pulseColorRed -= 0.01f * Time.deltaTime * 50;

        rend.material.color = pulseColor;

        // om Röd är mindre än 0, blir de 1 igen
        if (pulseColorRed <= 0)
        {
            pulseColorRed = 1.2f;
        }
        // ignorera
        //if (Input.GetKey(KeyCode.D))
        //{

        //    rend.material.color = new Color(pulseColorRed, pulseColorGreen, 1);

        //}
        //else if (Input.GetKey(KeyCode.A))
        //{

        //    rend.material.color = new Color(pulseColorRed, 1, pulseColorBlue);
        //}   
    }
}
