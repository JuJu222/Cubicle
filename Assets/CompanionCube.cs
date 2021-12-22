using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionCube : MonoBehaviour
{
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(new Vector2(100f, 100f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        float bounce = 100f; //amount of force to apply
        rb.AddForce(collision.contacts[0].normal * bounce);
        rb.MoveRotation(collision.contacts[0].normalImpulse);
    }
}
