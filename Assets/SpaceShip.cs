using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceShip : MonoBehaviour
{
    public Vector3 position;
    public Rigidbody2D rb;
    public float speed = 10;
    public GameObject laser;
    private float shootCooldown = 0.3f;
    private float shootTimer = 0;
    private bool stunned = false;
    public Image dangerBar;
    public float dangerPercent = 100;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DepletingDangerPerecentage());

    }

    // Update is called once per frame
    void Update()
    {
        dangerBar.fillAmount = dangerPercent / 100;
        shootTimer += Time.deltaTime;

        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(horizontalInput * speed, verticalInput * speed);

        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow) && !stunned)
        {
            rb.MoveRotation(45f);
            if (shootTimer > shootCooldown)
            {
                SoundManager.PlaySound("enemyfire");
                var newLaser = Instantiate(laser);
                newLaser.transform.position = this.transform.position;
                newLaser.transform.Rotate(new Vector3(0, 0, 45f));
                shootTimer = 0;
            }

        }
        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow) && !stunned)
        {
            rb.MoveRotation(-45f);
            if (shootTimer > shootCooldown)
            {
                SoundManager.PlaySound("enemyfire");
                var newLaser = Instantiate(laser);
                newLaser.transform.position = this.transform.position;
                newLaser.transform.Rotate(new Vector3(0, 0, -45f));
                shootTimer = 0;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow) && !stunned)
        {
            rb.MoveRotation(135f);
            if (shootTimer > shootCooldown)
            {
                SoundManager.PlaySound("enemyfire");
                var newLaser = Instantiate(laser);
                newLaser.transform.position = this.transform.position;
                newLaser.transform.Rotate(new Vector3(0, 0, 135f));
                shootTimer = 0;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow) && !stunned)
        {
            rb.MoveRotation(-135f);
            if (shootTimer > shootCooldown)
            {
                SoundManager.PlaySound("enemyfire");
                var newLaser = Instantiate(laser);
                newLaser.transform.position = this.transform.position;
                newLaser.transform.Rotate(new Vector3(0, 0, -135f));
                shootTimer = 0;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && !stunned)
        {
            rb.MoveRotation(90f);
            if (shootTimer > shootCooldown)
            {
                SoundManager.PlaySound("enemyfire");
                var newLaser = Instantiate(laser);
                newLaser.transform.position = this.transform.position;
                newLaser.transform.Rotate(new Vector3(0, 0, 90f));
                shootTimer = 0;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !stunned)
        {
            rb.MoveRotation(-90f);
            if (shootTimer > shootCooldown)
            {
                SoundManager.PlaySound("enemyfire");
                var newLaser = Instantiate(laser);
                newLaser.transform.position = this.transform.position;
                newLaser.transform.Rotate(new Vector3(0, 0, -90f));
                shootTimer = 0;
            }
        }
        else if (Input.GetKey(KeyCode.UpArrow) && !stunned)
        {
            rb.MoveRotation(0f);
            if (shootTimer > shootCooldown)
            {
                SoundManager.PlaySound("enemyfire");
                var newLaser = Instantiate(laser);
                newLaser.transform.position = this.transform.position;
                newLaser.transform.Rotate(new Vector3(0, 0, 0f));
                shootTimer = 0;
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow) && !stunned)
        {
            rb.MoveRotation(180f);
            if (shootTimer > shootCooldown)
            {
                SoundManager.PlaySound("enemyfire");
                var newLaser = Instantiate(laser);
                newLaser.transform.position = this.transform.position;
                newLaser.transform.Rotate(new Vector3(0, 0, 180f));
                shootTimer = 0;
            }
        }

        if (dangerPercent <= 0)
		{
            dangerPercent = 100;
            StartCoroutine(Explode());
        } else if (dangerPercent > 100)
		{
            dangerPercent = 100;
        }
    }

    public void ShootAllDirections()
	{
        var newLaser1 = Instantiate(laser);
        newLaser1.transform.position = this.transform.position;
        newLaser1.transform.Rotate(new Vector3(0, 0, 45f));

        var newLaser2 = Instantiate(laser);
        newLaser2.transform.position = this.transform.position;
        newLaser2.transform.Rotate(new Vector3(0, 0, -45f));

        var newLaser3 = Instantiate(laser);
        newLaser3.transform.position = this.transform.position;
        newLaser3.transform.Rotate(new Vector3(0, 0, 135f));

        var newLaser4 = Instantiate(laser);
        newLaser4.transform.position = this.transform.position;
        newLaser4.transform.Rotate(new Vector3(0, 0, -135f));

        var newLaser5 = Instantiate(laser);
        newLaser5.transform.position = this.transform.position;
        newLaser5.transform.Rotate(new Vector3(0, 0, 90f));

        var newLaser6 = Instantiate(laser);
        newLaser6.transform.position = this.transform.position;
        newLaser6.transform.Rotate(new Vector3(0, 0, -90f));

        var newLaser7 = Instantiate(laser);
        newLaser7.transform.position = this.transform.position;
        newLaser7.transform.Rotate(new Vector3(0, 0, 0f));

        var newLaser8 = Instantiate(laser);
        newLaser8.transform.position = this.transform.position;
        newLaser8.transform.Rotate(new Vector3(0, 0, 180f));
    }

    IEnumerator DepletingDangerPerecentage()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            dangerPercent -= 1;
        }
    }    
    
    IEnumerator Explode()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.15f);
            SoundManager.PlaySound("enemyfire");
            ShootAllDirections();
        }
    }

    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(0.5f);
        rb.constraints = RigidbodyConstraints2D.None;
        stunned = false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("PeluruMusuh"))
        {
            stunned = true;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            StartCoroutine(Waiter());
        }
    }
}
