using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionCube : MonoBehaviour
{
    public Rigidbody2D rb;
    private static int health = 500;

    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(new Vector2(100f, 100f));
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        float bounce = 100f; //amount of force to apply
        rb.AddForce(collision.contacts[0].normal * bounce);
        rb.MoveRotation(collision.contacts[0].normalImpulse);

        if (collision.gameObject.tag == "Peluru")
        {
            health = health - 30;
        }

    }
}
