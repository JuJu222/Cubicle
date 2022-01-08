using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeluruMusuh : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.TransformDirection(Vector2.right * speed);
    }

    void OnTriggerEnter2D(Collider2D other){
         if(other.CompareTag("Player"))
         {
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
