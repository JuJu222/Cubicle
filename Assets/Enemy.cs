using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;

    public WaveSpawner waveSpawner;
    public float retreatDistance;
    public GameObject projectile;
    public Rigidbody2D rb;
    public Transform player;

    public AudioSource audioSource;
    public AudioClip shootingAudioClip;

    public float startTimeBetweenShots;
    private float timeBetweenShots;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBetweenShots = startTimeBetweenShots;
    }

    // Update is called once per frame
    void Update()
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

        if (collision.gameObject.tag == "Peluru")
		{
            Destroy(gameObject);

            waveSpawner.AddDeath();
        }
    }


    


}
