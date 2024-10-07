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

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        origColor = meshRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeLightDamage()
    {
        meshRenderer.material.color = lightDamageColor;
        //currently only works if object has exclusively 1 child (or only works on the first child, unsure)
        this.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = lightDamageColor;
        Invoke("FlashStop", flashTime);
    }

    public void takeHeavyDamage()
    {
        meshRenderer.material.color = heavyDamageColor;
        this.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = heavyDamageColor;
        Invoke("FlashStop", flashTime);
    }

    void FlashStop()
    {
        meshRenderer.material.color = origColor;
        this.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = origColor;
    }
}
