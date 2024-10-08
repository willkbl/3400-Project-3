using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderDamage : MonoBehaviour
{

    MeshRenderer meshRenderer;
    Color origColor;
    float flashTime = .15f;

    public Color lightDamageColor;
    public Color heavyDamageColor;

    AudioSource damageAudio;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        origColor = meshRenderer.material.color;
        damageAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeLightDamage()
    {
        meshRenderer.material.color = lightDamageColor;
        //currently only works on the first child of the object (the weak point, presumably)
        this.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = lightDamageColor;
        Invoke("FlashStop", flashTime);
    }

    public void takeHeavyDamage()
    {
        meshRenderer.material.color = heavyDamageColor;
        this.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = heavyDamageColor;
        Invoke("FlashStop", flashTime);
        damageAudio.Play();
    }

    void FlashStop()
    {
        meshRenderer.material.color = origColor;
        this.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = origColor;
    }
}
