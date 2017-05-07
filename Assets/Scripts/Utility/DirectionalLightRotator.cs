using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalLightRotator : MonoBehaviour {

    public float targetRotation;
    public float rotationMultiplier;
    public float targetIntensity;
    public float intensityMultiplier;

    private Light light;

    private void Awake()
    {
        light = GetComponent<Light>();
    }

	void Update () {
        if (transform.eulerAngles.x > targetRotation)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x - (Time.deltaTime * rotationMultiplier), transform.eulerAngles.y));
        }
        if(light.intensity > targetIntensity)
        {
            light.intensity -= Time.deltaTime * intensityMultiplier;
        }
	}
}
