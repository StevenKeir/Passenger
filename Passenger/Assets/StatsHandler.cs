using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsHandler : MonoBehaviour {

    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }
    public int busOxygen;
    public int oxygen;
    public int calmLevel;

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
    public void AddItem(string myItem, bool add) {
        switch (myItem) {
            case "Gun":
                if (add) hasGun = true;
                else hasGun = false;
                break;
            case "Ductape":
                if (add) hasDuctape = true;
                else hasDuctape = false;
                break;
            case "Laptop":
                if (add) hasLaptop = true;
                else hasLaptop = false;
                break;
            case "CigarBox":
                if (add) hasCigarBox = true;
                else hasCigarBox = false;
                break;
            case "Crystal":
                if (add) hasCrystal = true;
                else hasCrystal = false;
                break;
            case "OxygenKit":
                if (add) wearingOxygenKit = true;
                else wearingOxygenKit = false;
                break;
        }
    }
    private void Update() {
        OxygenDrain();
    }

    void OxygenDrain() {
        if (outside) {
            oxygen += -calmLevel - 1;
        }
    }
}
