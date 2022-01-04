using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WaveSpawner : MonoBehaviour
{

    public GameObject Enemy;
    private int wave = 1;
    
    public Text waveHUD;
    

    float randX;

    float randY;
    private int counterDeath;

    Vector2 whereToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        randX = Random.Range(-8.0f, 8.0f);
        randY = Random.Range(-4.0f, 4.0f);
        whereToSpawn = new Vector2(randX, randY);
        var enemy = Instantiate(Enemy, whereToSpawn, Quaternion.identity);
        enemy.GetComponent<Enemy>().waveSpawner = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddDeath()
    {
        //Nambah satu mati
        counterDeath++;
        //jumlah mati >= level ? 
        if (counterDeath == wave)
        {      
            ScoreScript.scoreValue += 10;    
            wave++;
            waveHUD.text = "Wave: " + wave;
            for (int i = 0; i < wave; i++)
            {
                randX = Random.Range(-8.0f, 8.0f);
                randY = Random.Range(-4.0f, 4.0f);
                whereToSpawn = new Vector2(randX, randY);
                var enemy = Instantiate(Enemy, whereToSpawn, Quaternion.identity);
                enemy.GetComponent<Enemy>().waveSpawner = this;
                counterDeath = 0;
            }
        }
    }
}
