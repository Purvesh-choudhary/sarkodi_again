using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip diceRollSFX;
    [SerializeField] AudioClip moveSFX;
    [SerializeField] AudioClip KillSFX;


    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void DiceRoll()
    {
        audioSource.PlayOneShot(diceRollSFX);
    }

    public void Move()
    {
        audioSource.PlayOneShot(moveSFX);
    }

    public void Kill()
    {
        audioSource.PlayOneShot(KillSFX);
    }



}
