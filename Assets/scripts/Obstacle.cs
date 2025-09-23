using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    private GameObject Player;
    public float baseSpeed = 2f;  // starting speed
    private float speed;


    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        // Increase speed as difficulty rises
        float t = Mathf.Clamp01(Time.timeSinceLevelLoad / 60f); // scale over 1 min
        speed = Mathf.Lerp(baseSpeed, baseSpeed * 3f, t); // up to 3x faster
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }

        else if(collision.tag == "Player")
        {
            Destroy(Player.gameObject);
        }
    }
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Cleanup if off screen
        if (transform.position.y < -20f)
        {
            Destroy(gameObject);
        }
    }


}
