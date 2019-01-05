using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ShootyScript : MonoBehaviour
{
    public static int score;

    public GameObject projectile;
    private GameObject clone;
    public Text scoreText;

    void Update()
    {
        if (GameManagerScript.finishedCountDown == true)
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began) // Als de speler het scherm aan raakt:
                {
                    clone = Instantiate(projectile, transform.position, transform.rotation) as GameObject; // Spawnt het projectiel
                    clone.GetComponent<Rigidbody>().velocity = 35 * transform.localScale.x * clone.transform.forward; // Geeft het projectiel snelheid			
                    Destroy(clone, 1.4f); // Vernietigd het projectiel na 2 seconden.
                }
            }
        }
        scoreText.text = "Score: " + score.ToString();
    }
}
