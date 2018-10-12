using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipScript : MonoBehaviour
{
    // ALLA SHIPSCRIPS OCH WINGSCRIPS ÄR IDENTISKA

    // floats, färger och ränderers

    public float shipSpeed;
    public float shipTurn;
    public float skillBased;
    Renderer rend;
    public Color shipDefaultColor;
    public Color leftColor;
    public Color rightColor;
    public float timer;
    public float currentTime;

    // Use this for initialization
    void Start()
    {
        // värden (shipSpeed = randomRange för C-uppgiften)
        shipSpeed = Random.Range(4, 12);
        // shipturn ocksp random bara för att
        shipTurn = Random.Range(250, 450);
        // vanliga färgem
        shipDefaultColor = new Color(1f, 1f, 1f, 1);
        // färgen när man svänger vänster
        leftColor = new Color(.3f, 1f, .3f, 1);
        // färgen när man svänger höger
        rightColor = new Color(.3f, .3f, 1f, 1);
        // skaffar komponenten för framtida färgbytning
        rend = GetComponent<Renderer>();
        // spawnar på slumpmässig plats 
        transform.Translate(Random.Range(07f, -7f), Random.Range(-4f, 1.5f), 0);
    }
    // Update is called once per frame
    void Update()
    {
        // skeppet blir snabbare ju mer tid som går
        shipSpeed += 0.2f * Time.deltaTime;
        shipTurn += 10 * Time.deltaTime;
        // om värdet är 1
        // annars
        // så länge man håller in D
        if (Input.GetKey(KeyCode.D))
        {
            // roterar z-axeln motsols
            transform.Rotate(0, 0, -shipTurn * Time.deltaTime);
            // gör skeppet blått...
            rend.material.color = rightColor;

        }
        // så länge man håller in A
        else if (Input.GetKey(KeyCode.A))
        {
            // roterar z-axeln motsols
            transform.Rotate(0, 0, shipTurn / 2 * Time.deltaTime);
            // ...eller skeppet grönt...
            rend.material.color = leftColor;
        }
        else
        {
            // ...eller bara den vanliga färgen
            rend.material.color = shipDefaultColor;
        }
        // så länge man håller in S...
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
        // om man trycker på space
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
            // lägger till en på currentTime
            currentTime += 1;
        }
        // en vektor för att kunna kolla positionen
        Vector3 newPosition = transform.position;
        // om skepper är utanför bilden på X...
        if (newPosition.x > 10 || newPosition.x < -10)
        {
        // ...åker den till motsatta position
            newPosition.x = -newPosition.x;
        }
        // om skepper är utanför bilden på Y...
        if (newPosition.y > 6 || newPosition.y < -6)
        {
        // ...åker den till motsatta position
            newPosition.y = -newPosition.y;
        }
        // OBS: detta ^ kan skapa spelförstörande buggar
        // sätter positionen 
        transform.position = newPosition;

    }
}
