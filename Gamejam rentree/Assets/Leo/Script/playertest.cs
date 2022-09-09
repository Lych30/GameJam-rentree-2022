using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playertest : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    Transform destination;
    [SerializeField] int index = 0;
    public AudioClip[] clips;

    void Update()
    {
        if (PlayerMove.instance.canMove)
        {
            if (Input.GetKeyDown(KeyCode.D))
        {
            index++;

            if(index == 6)
            {
                index = 0;
            }
            transform.rotation = transform.rotation * Quaternion.Euler(new Vector3(0,-60,0));
            playRandomSwitchSound();
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            index--;

            if (index == -1)
            { 
                index = 5;
            }
            transform.rotation = transform.rotation * Quaternion.Euler(new Vector3(0,60,0));

            playRandomSwitchSound();
        }
        }
        
        AtoB(points[index]);
    }
    void AtoB(Transform destination)
    {
        transform.position = Vector3.Lerp(transform.position, destination.position,5*Time.deltaTime);
    }
    void playRandomSwitchSound()
    {
        int randomNb = Random.Range(0, 3);
        switch (randomNb)
        {
            case 0:
                SoundManager.Instance.Play(clips[3]);
                break;
            case 1:
                SoundManager.Instance.Play(clips[4]);
                break;
            case 2:
                SoundManager.Instance.Play(clips[5]);
                break;
            default:
                SoundManager.Instance.Play(clips[3]);
                break;
        }
    }
}
