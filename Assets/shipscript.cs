using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipScript : MonoBehaviour
{
    public float shipSpeed;
    public float shipTurn;
    public float skillBased;
    Renderer rend;
    public Color shipDefaultColor;
    public Color leftColor;
    public Color rightColor;
    public float timer;
    public float currentTime;
    public Vector3 newPosition;

    // Use this for initialization
    void Start()
    {
        // värden (shipSpeed = randomRange för C-uppgiften)
        shipSpeed = Random.Range(8, 16);
        shipDefaultColor = new Color(1f, 1f, 1f, 1);
        leftColor = new Color(.3f, 1f, .3f, 1);
        rightColor = new Color(.3f, .3f, 1f, 1);
        rend = GetComponent<Renderer>();
        // spawnar på slumpmässig plats 
        transform.Translate(Random.Range(07f, -7f), Random.Range(-4f, 1.5f), 0);
        newPosition = transform.position; 
    }
    // Update is called once per frame
    void Update()
    {
        // svängen måste ju vara som farten
        if (shipSpeed == 8)
        {
            shipTurn = 250f;
        }
        else if (shipSpeed == 9)
        {
            shipTurn = 270;
        }
        else if (shipSpeed == 10)
        {
            shipTurn = 300;
        }
        else if (shipSpeed == 11)
        {
            shipTurn = 330;
        }
        else if (shipSpeed == 12)
        {
            shipTurn = 350f;
        }
        else if (shipSpeed == 13)
        {
            shipTurn = 370;
        }
        else if (shipSpeed == 14)
        {
            shipTurn = 400;
        }
        else if (shipSpeed == 15)
        {
            shipTurn = 430;
        }
        else if (shipSpeed == 16)
        {
            shipTurn = 450;
        }
        // lite kul å så
        //shipSpeed += 1 * Time.deltaTime;
        //shipTurn += 20 * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
        {
            // roterar z-axeln motsols
            transform.Rotate(0, 0, -shipTurn * Time.deltaTime);
            // gör skeppet blått...
            rend.material.color = rightColor;

        }
        else if (Input.GetKey(KeyCode.A))
        {
            // roterar z-axeln motsols
            transform.Rotate(0, 0, shipTurn / 2 * Time.deltaTime);
            // gör skeppet grönt...
            rend.material.color = leftColor;
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
            // ändrar färgen (.3f istället för 0f gör så att det blir mer av en tint)
            shipDefaultColor = new Color(Random.Range(.2f, 1f), Random.Range(.2f, 1f), Random.Range(.2f, 1f), 1);
            // renderar
            rend.material.color = shipDefaultColor;
        }
        // adderar 1 varje sekund 
        timer += 1 * Time.deltaTime;

        // jämför tiden som datorn vet med den vi ser
        if (timer > currentTime && timer < currentTime + 0.2)
        {
            // printa och omvandla
            print(string.Format("Timer: {0}", (int)timer));
            currentTime = (currentTime + 1);


        }
        //flyttar skeppet om det är utanför bilden
    }
}
