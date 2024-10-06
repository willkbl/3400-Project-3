using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSpear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
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
    }
}
