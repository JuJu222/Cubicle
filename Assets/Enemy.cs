using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;

    private readonly float directionChangeTime = 3f;

    private float latestDirectionChangeTime;
    public float retreatDistance;


    private Vector2 movementDirection;
    private Vector2 movementPerSecond;
    public GameObject projectile;
    public Rigidbody2D rb;
    public Transform player;

    float angle;
    public float startTimeBetweenShots;
    private float timeBetweenShots;
    // Start is called before the first frame update
    void Start()
    {


        // latestDirectionChangeTime = 0f;
        // calcuateNewMovementVector();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBetweenShots = startTimeBetweenShots;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Kalau jauh maka musuh akan mendekat spaceship
        if(Vector2.Distance(transform.position, player.position) > stoppingDistance){
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        //Jika tidak terlalu deket maka musuh akan diam ditempat dan nembak
        }else if(Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance){
            transform.position = this.transform.position;

        }else if(Vector2.Distance(transform.position, player.position) < retreatDistance){
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        

        // if (Time.time - latestDirectionChangeTime > directionChangeTime)
        // {
        //     latestDirectionChangeTime = Time.time;
        //     calcuateNewMovementVector();
        // }

        // transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime),
        // transform.position.y + (movementPerSecond.y * Time.deltaTime));

        if (timeBetweenShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBetweenShots = startTimeBetweenShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        rb.MoveRotation(collision.contacts[0].normalImpulse);
    }

    void calcuateNewMovementVector()
    {
        //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
        movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        movementPerSecond = movementDirection * speed;
    }

    


}
