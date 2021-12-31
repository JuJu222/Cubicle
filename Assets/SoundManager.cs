using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip playerfire, enemyfire, enemydeath,stunneds;
    static AudioSource audiosrc;

    // Start is called before the first frame update
    void Start()
    {
        playerfire = Resources.Load<AudioClip>("playerfire");
        enemyfire = Resources.Load<AudioClip>("enemyfire");
        enemydeath = Resources.Load<AudioClip>("enemydeath");
        stunneds = Resources.Load<AudioClip>("stunned");

        audiosrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "playerfire":
                audiosrc.PlayOneShot(playerfire);
                break;
            case "enemyfire":
                audiosrc.PlayOneShot(enemyfire);
                break;
            case "enemydeath":
                audiosrc.PlayOneShot(enemydeath);
                break;
            case "stunned":
                audiosrc.PlayOneShot(stunneds);
                break;
        }
    }
}
