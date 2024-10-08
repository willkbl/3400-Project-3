using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderDamage : MonoBehaviour
{

    Renderer renderer;
    Color origColor;
    Renderer wpRenderer;
    Color wpOrigColor;
    public float flashTime = .15f;
    public float eyebrowTime = 1.0f;

    public Color lightDamageColor;
    public Color heavyDamageColor;

    AudioSource damageAudio;
    public GameObject eyebrows;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        origColor = renderer.material.color;
        wpRenderer = this.transform.GetChild(0).GetComponent<Renderer>();
        wpOrigColor = wpRenderer.material.color;
        damageAudio = GetComponent<AudioSource>();
        eyebrows.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeLightDamage()
    {
        renderer.material.color = lightDamageColor;
        //currently only works on the first child of the object (the weak point, presumably)
        wpRenderer.material.color = lightDamageColor;
        Invoke("FlashStop", flashTime);
    }

    public void takeHeavyDamage()
    {
        renderer.material.color = heavyDamageColor;
        wpRenderer.material.color = heavyDamageColor;
        Invoke("FlashStop", flashTime);
        damageAudio.Play();
        eyebrows.SetActive(true);
        Invoke("EyebrowsOff", eyebrowTime);
    }

    void FlashStop()
    {
        renderer.material.color = origColor;
        wpRenderer.material.color = wpOrigColor;
    }

    void EyebrowsOff()
    {
        eyebrows.SetActive(false);
    }
}
