using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightWaver : MonoBehaviour {

    Light myLight;
    float timer;
    public float maxTime;
    public float minTime;
    float originalIntensity;
    float originalRange;
    bool addTime;

    private void Start() {
        myLight = GetComponent<Light>();
        originalIntensity = myLight.intensity;
        originalRange = myLight.range;
    }

    private void Update() {
        TimerChange();
        myLight.intensity = timer;
    }

    void TimerChange() {
        if (addTime) {
            timer += Time.deltaTime;
            if (maxTime < timer) {
                addTime = false;
            }
        }
        else {
            timer -= Time.deltaTime;
            if (minTime > timer) {
                addTime = true;
            }
        }
    }
}
