using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsHandler : MonoBehaviour {
    public float myBusMinutesMult;
    public float myMinutesMult;
    [HideInInspector]
    public bool hasOxygen;
    [HideInInspector]
    public float timeMultiplier;
    void Awake() {
        DontDestroyOnLoad(this.gameObject);
        if (!hasOxygen) {
            hasOxygen = false;
            //60 * 180 = 2 hours;
            busOxygen = 60f * myBusMinutesMult;
            //calm level starts at negative so it affects oxygen the same way
            calmLevel = -60f;
            //maxOxygen is the kit's maximum capacity. 60f = 60 seconds, mult = how many minutes.
            maxOxygen = 60f * myMinutesMult;
            //the oxygen kit is full at the start, since it's inside the bus
            oxygen = maxOxygen;
        }
    }

    //oxygen
    public float busOxygen;
    float maxOxygen;
    public float oxygen;
    public float calmLevel;

    //items
    public enum Items { Gun, DuctTape, Laptop, CigarBox, Crystal, OxygenKit }
    public Items[] items;
    public bool wearingOxygenKit;
    public bool outside;
    public bool hasGun;
    public bool hasDuctape;
    public bool hasLaptop;
    public bool hasCigarBox;
    public bool hasCrystal;

    public void AffectCalmLevel(int effect) {
        calmLevel += effect;
    }

    public void ChangeLocale(bool inside) {
        if (!inside) outside = true;
        else outside = false;
    }

    public void AddItem(Items item, bool add) {
        switch (item) {
            case Items.Gun:
                if (add) hasGun = true;
                else hasGun = false;
                break;

            case Items.DuctTape:
                if (add) hasDuctape = true;
                else hasDuctape = false;
                break;

            case Items.Laptop:
                if (add) hasLaptop = true;
                else hasLaptop = false;
                break;

            case Items.CigarBox:
                if (add) hasCigarBox = true;
                else hasCigarBox = false;
                break;

            case Items.Crystal:
                if (add) hasCrystal = true;
                else hasCrystal = false;
                break;

            case Items.OxygenKit:
                if (add) wearingOxygenKit = true;
                else wearingOxygenKit = false;
                break;

            default:
                break;
        }
    }
    private void Update() {
        OxygenDrain();
    }

    void OxygenDrain() {
        if (outside) {
            oxygen += -1f * Time.deltaTime;
        }
        else {
            if (oxygen < maxOxygen) {
                oxygen += (6f * myMinutesMult) * Time.deltaTime;
                busOxygen -= (6f * myMinutesMult) * Time.deltaTime;
            }
            busOxygen += -1f * Time.deltaTime;
        }
        busOxygen += (calmLevel - 1f) * Time.deltaTime;
    }
}
