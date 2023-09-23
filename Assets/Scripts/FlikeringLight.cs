using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlikeringLight : MonoBehaviour
{
    public Light light;
    public float originalIntensity;
    public float minSpeed=0.1f;
    public float maxSpeed=0.5f;
    public float minIntensity;
    public float maxIntensity;

    
    // Start is called before the first frame update
    void Start()
    {
       light = GetComponent<Light>();
        StartCoroutine(Flikering());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Flikering()
    {
        while (true)
        {
            light.intensity = originalIntensity + Random.Range(minIntensity, maxIntensity);
            yield return new WaitForSeconds(Random.Range(minSpeed, maxSpeed));
        }
       
    }
}
