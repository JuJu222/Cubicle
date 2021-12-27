using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 50f;
    Vector3 translationVec;
    public Rigidbody2D rb;
    SpaceShip spaceShip;

    // Start is called before the first frame update
    void Start()
    {
        spaceShip = GameObject.Find("SpaceShip").GetComponent<SpaceShip>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.TransformDirection(Vector2.right * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.tag == "Wall")
		{
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Enemy"){
            Destroy(gameObject);
            spaceShip.dangerPercent += 5;
        }
    }
}
