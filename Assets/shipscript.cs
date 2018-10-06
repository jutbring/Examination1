using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipscript : MonoBehaviour
{
    public float shipSpeed;
    public float shipTurn;
    Renderer rend;
    public Color shipDefaultColor;
    public Color leftColor;
    public Color rightColor;
    public float timer;
    public float currentTime;

    // Use this for initialization
    void Start()
    {
        // värden
        shipSpeed = 8f;
        shipTurn = 250f;
        shipDefaultColor = new Color(1, 1, 1, 1);
        leftColor = new Color(0, 1, 0, 1);
        rightColor = new Color(0, 0, 1, 1);
        rend = GetComponent<Renderer>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            // roterar z-axeln motsols
            transform.Rotate(0, 0, -shipTurn * Time.deltaTime);
            // gör skeppet blått...
            rend.material.color = rightColor;
        }
        else
        {
            // ...eller inte
            rend.material.color = shipDefaultColor;
        }

        if (Input.GetKey(KeyCode.A))
        {
            // gör skeppet grönt...
            rend.material.color = leftColor;
            // roterar z-axeln motsols
            transform.Rotate(0, 0, shipTurn / 2 * Time.deltaTime);
        }
        else
        {
            // ...eller inte
            rend.material.color = shipDefaultColor;
        }

        if (Input.GetKey(KeyCode.S))
        {
            // kör skeppet hälften av normal hastighet...
            transform.Translate(0, shipSpeed / 2 * Time.deltaTime, 0);
        }
        else
        {
            // ... eller kör skeppet normal hastighet
            transform.Translate(0, shipSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ändrar färgen
            shipDefaultColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
            // renderar
            rend.material.color = shipDefaultColor;
        }
        // adderar 1 varje sekund (med decimaler)
        timer += 1 * Time.deltaTime;

        // jämför tiden som datorn vet med den vi ser
        if (timer > currentTime && timer < currentTime + 0.2)
        {
            // printa och omvandla
            print(string.Format("Timer: {0}", (int)timer));
            currentTime = (currentTime + 1);
        }
    }
}
