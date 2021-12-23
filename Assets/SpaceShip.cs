using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public Vector3 position;
    public Rigidbody2D rb;
    public float speed = 10;
    public GameObject laser;
    private float shootCooldown = 0.3f;
    private float shootTimer = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        shootTimer += Time.deltaTime;

        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(horizontalInput * speed, verticalInput * speed);

        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            rb.MoveRotation(45f);
            if (shootTimer > shootCooldown)
            {
                var newLaser = Instantiate(laser);
                newLaser.transform.position = this.transform.position;
                newLaser.transform.Rotate(new Vector3(0, 0, 45f));
                shootTimer = 0;
            }

        }
        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            rb.MoveRotation(-45f);
            if (shootTimer > shootCooldown)
            {
                var newLaser = Instantiate(laser);
                newLaser.transform.position = this.transform.position;
                newLaser.transform.Rotate(new Vector3(0, 0, -45f));
                shootTimer = 0;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            rb.MoveRotation(135f);
            if (shootTimer > shootCooldown)
            {
                var newLaser = Instantiate(laser);
                newLaser.transform.position = this.transform.position;
                newLaser.transform.Rotate(new Vector3(0, 0, 135f));
                shootTimer = 0;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            rb.MoveRotation(-135f);
            if (shootTimer > shootCooldown)
            {
                var newLaser = Instantiate(laser);
                newLaser.transform.position = this.transform.position;
                newLaser.transform.Rotate(new Vector3(0, 0, -135f));
                shootTimer = 0;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.MoveRotation(90f);
            if (shootTimer > shootCooldown)
            {
                var newLaser = Instantiate(laser);
                newLaser.transform.position = this.transform.position;
                newLaser.transform.Rotate(new Vector3(0, 0, 90f));
                shootTimer = 0;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.MoveRotation(-90f);
            if (shootTimer > shootCooldown)
            {
                var newLaser = Instantiate(laser);
                newLaser.transform.position = this.transform.position;
                newLaser.transform.Rotate(new Vector3(0, 0, -90f));
                shootTimer = 0;
            }
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.MoveRotation(0f);
            if (shootTimer > shootCooldown)
            {
                var newLaser = Instantiate(laser);
                newLaser.transform.position = this.transform.position;
                newLaser.transform.Rotate(new Vector3(0, 0, 0f));
                shootTimer = 0;
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.MoveRotation(180f);
            if (shootTimer > shootCooldown)
            {
                var newLaser = Instantiate(laser);
                newLaser.transform.position = this.transform.position;
                newLaser.transform.Rotate(new Vector3(0, 0, 180f));
                shootTimer = 0;
            }
        }
    }
}
