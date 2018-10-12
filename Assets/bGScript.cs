using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bGScript : MonoBehaviour {
    // floats, färger och renderers
    Renderer rend;
    public float pulseColorRed;
    public Color pulseColor;
    public bool printed;
    public float sizeX;
    public float sizeY;

    // Use this for initialization
    void Start () {
        // värden
        rend = GetComponent<Renderer>();
        pulseColorRed = 0;
        printed = true;
        sizeX = 5f;
        sizeY = 5f;
    }
	// Update is called once per frame
	void Update () {
        // skaffa en pulsecolor some använder röd
        pulseColor = new Color(pulseColorRed, 0, 0);
        // adderar lite på det röda varje sekund
        pulseColorRed += 0.001f * Time.deltaTime * 20;
        // renderar färgen
        rend.material.color = pulseColor;
        // roterar objektet 
        transform.Rotate(0, 0, 5 * Time.deltaTime);
        // om objektet är helt rött ock boolen är sann...
        if (pulseColorRed >= 1.1f && printed == true)
        {
            // ...printa meddelandet 
            print("IS THIS LOSS?");
            // och gör boolen osann
            printed = false;
        }
        // lägger till lite på storleken varje sekund 
        sizeX += 0.3f * Time.deltaTime;
        sizeY += 0.3f * Time.deltaTime;
        // transformera till storleken 
        transform.localScale = new Vector3(sizeX, sizeY, 1);
    }
}
