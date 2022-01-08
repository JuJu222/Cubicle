using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompanionCube : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameOver gameOver;
    public Text waveHUD;
    private static int health;

    public void GameOver(){
        gameOver.getScore();
        gameOver.Setup();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        rb.AddForce(new Vector2(100f, 100f));
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            GameOver(); //After game over delete all gameobjects from scene
            Destroy(gameObject);
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
                GameObject.Destroy(enemy);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        float bounce = 500f; //amount of force to apply
        rb.AddForce(collision.contacts[0].normal * bounce);
        rb.MoveRotation(collision.contacts[0].normalImpulse);

        if (collision.gameObject.tag == "Peluru")
        {
            health -= 5;
            waveHUD.text = "" + health;
        }
    }
}
