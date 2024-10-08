using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMusic : MonoBehaviour
{
    // Start is called before the first frame update

    AudioSource music;
    void Start()
    {
        music = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!music.isPlaying && other.gameObject.CompareTag("Player"))
        {
            music.Play();
            GetComponent<SphereCollider>().enabled = false;
        }
    }
}
