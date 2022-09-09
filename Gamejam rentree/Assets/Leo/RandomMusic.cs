using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMusic : MonoBehaviour
{

    public AudioSource[] sources;
    // Start is called before the first frame update
    void Start()
    {
        sources = GetComponents<AudioSource>();
        int randomMusic = Random.Range(0, sources.Length);
        sources[randomMusic].Play();
    }

    
}
