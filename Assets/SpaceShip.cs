using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public Vector3 position;
    float SpeedX = 0;//Don't touch this
    float SpeedY = 0;//Don't touch this
    float MaxSpeed = 10;//This is the maximum speed that the object will achieve
    float Acceleration = 10;//How fast will object reach a maximum speed
    float Deceleration = 10;//How fast will object reach a speed of 0

    // Start is called before the first frame update
    void Start()
    {
        transform.position = position;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey("a")) && (SpeedX < MaxSpeed))
		{
            SpeedX = SpeedX - Acceleration * Time.deltaTime;
            if (SpeedY > Deceleration * Time.deltaTime)
            {
                SpeedY = SpeedY - Deceleration * Time.deltaTime;
            }
            else if (SpeedY < -Deceleration * Time.deltaTime)
            {
                SpeedY = SpeedY + Deceleration * Time.deltaTime;
            }
            else
            {
                SpeedY = 0;
            }

        }
        else if ((Input.GetKey("d")) && (SpeedX > -MaxSpeed))
		{
            SpeedX = SpeedX + Acceleration * Time.deltaTime;
            if (SpeedY > Deceleration * Time.deltaTime)
            {
                SpeedY = SpeedY - Deceleration * Time.deltaTime;
            }
            else if (SpeedY < -Deceleration * Time.deltaTime)
            {
                SpeedY = SpeedY + Deceleration * Time.deltaTime;
            }
            else
            {
                SpeedY = 0;
            }
        }
        else if ((Input.GetKey("w")) && (SpeedY > -MaxSpeed))
        {
            SpeedY = SpeedY + Acceleration * Time.deltaTime;
            if (SpeedX > Deceleration * Time.deltaTime)
            {
                SpeedX = SpeedX - Deceleration * Time.deltaTime;
            }
            else if (SpeedX < -Deceleration * Time.deltaTime)
            {
                SpeedX = SpeedX + Deceleration * Time.deltaTime;
            }
            else
            {
                SpeedX = 0;
            }
        }
        else if ((Input.GetKey("s")) && (SpeedY < MaxSpeed))
        {
            SpeedY = SpeedY - Acceleration * Time.deltaTime;
            if (SpeedX > Deceleration * Time.deltaTime)
            {
                SpeedX = SpeedX - Deceleration * Time.deltaTime;
            }
            else if (SpeedX < -Deceleration * Time.deltaTime)
            {
                SpeedX = SpeedX + Deceleration * Time.deltaTime;
            }
            else
            {
                SpeedX = 0;
            }
        }
        else
        {
            if (SpeedX > Deceleration * Time.deltaTime)
			{
                SpeedX = SpeedX - Deceleration * Time.deltaTime;
            }
            else if (SpeedX < -Deceleration * Time.deltaTime)
			{
                SpeedX = SpeedX + Deceleration * Time.deltaTime;
            }
            else
			{
                SpeedX = 0;
            }

            if (SpeedY > Deceleration * Time.deltaTime)
            {
                SpeedY = SpeedY - Deceleration * Time.deltaTime;
            }
            else if (SpeedY < -Deceleration * Time.deltaTime)
            {
                SpeedY = SpeedY + Deceleration * Time.deltaTime;
            }
            else
            {
                SpeedY = 0;
            }
        }
        position.x = transform.position.x + SpeedX * Time.deltaTime;
        position.y = transform.position.y + SpeedY * Time.deltaTime;
        transform.position = position;
    }
}
