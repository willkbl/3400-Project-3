using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSpear : MonoBehaviour
{

    public AudioClip spearSound;

    public float spearTimer = 0.0f;
    public float spearTimeBetweenThrows = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && spearTimer >= spearTimeBetweenThrows)
        {
            RaycastHit hit;

            spearTimer = 0.0f;

            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                AudioSource.PlayClipAtPoint(spearSound, transform.position);
                if (hit.collider.CompareTag("WeakPoint"))
                {
                    hit.collider.transform.parent.gameObject.GetComponent<SpiderDamage>().takeHeavyDamage();
                }
                else if (hit.collider.CompareTag("Spider"))
                {
                    hit.collider.GetComponent<SpiderDamage>().takeLightDamage();
                }
            }
        }

        spearTimer += Time.deltaTime;
    }
}
