using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StatsHandler : MonoBehaviour
{
    //use this bool to detect if values have been saved
    bool hasSaved;
    bool isStarting;
    public float myBusMinutesMult;
    public float myMinutesMult;
    [HideInInspector]
    public bool hasOxygen;
    [HideInInspector]
    public float timeMultiplier;

    void Awake()
    {//this runs at the start of each scene ( I think )
        DontDestroyOnLoad(this.gameObject);
        OxygenDealing();
    }

    void OxygenDealing()
    {
        if (!isStarting)
        {
            hasOxygen = false;
        }
        if (isStarting)
        {
            if (hasSaved)
            {
                GameObject.FindGameObjectWithTag("Player").transform.position = characterPosition;
                //move the camera so it's also in the right position (Camera.main.transform.position =???)
            }

            else
            {
                wearingOxygenKit = false;
                outside = false;
                hasGun = false;
                hasDuctape = false;
                hasLaptop = false;
                hasCigarBox = false;
                hasCrystal = false;
            }
            isStarting = false;
            if (!hasOxygen)
            {
                OxygenStart();
            }
        }
    }

    void OxygenStart()
    {
        hasOxygen = true;
        //60 * 180 = 2 hours;
        busOxygen = 60f * myBusMinutesMult;
        origBusOxygen = busOxygen;
        //calm level starts at negative so it affects oxygen the same way
        calmLevel = -60f;
        origCalmLevel = calmLevel;
        //maxOxygen is the kit's maximum capacity. 60f = 60 seconds, mult = how many minutes.
        maxOxygen = 60f * myMinutesMult;
        //the oxygen kit is full at the start, since it's inside the bus
        oxygen = maxOxygen;
        origOxygen = oxygen;
    }
    //characterStats:
    Vector3 characterPosition;
    int myScene = -1;

    //oxygen
    public float busOxygen;
    public float origBusOxygen;
    public float maxOxygen;
    public float oxygen;
    float origOxygen;
    public float calmLevel;
    float origCalmLevel;

    //items
    public bool wearingOxygenKit;
    public bool outside;
    public bool hasGun;
    public bool hasDuctape;
    public bool hasLaptop;
    public bool hasCigarBox;
    public bool hasCrystal;

    public void AffectCalmLevel(int effect)
    {
        calmLevel += effect;
    }

    public void ChangeLocale(bool inside)
    {
        if (!inside) outside = true;
        else outside = false;
    }

    void RemoveAllItems()
    {

    }
    public void AddItem(string item, bool add)
    {
        switch (item)
        {
            case "Gun":
                if (add)
                {
                    hasGun = true;
                }
                else
                {
                    hasGun = false;
                }
                break;

            case "DuctTape":
                if (add)
                {
                    hasDuctape = true;
                }
                else
                {
                    hasDuctape = false;
                }
                break;

            case "Laptop":
                if (add)
                {
                    hasLaptop = true;
                }
                else
                {
                    hasLaptop = false;
                }
                break;

            case "CigarBox":
                if (add)
                {
                    hasCigarBox = true;
                }
                else
                {
                    hasCigarBox = false;
                }
                break;

            case "Crystal":
                if (add)
                {
                    hasCrystal = true;
                }
                else
                {
                    hasCrystal = false;
                }
                break;

            case "OxygenKit":
                if (add)
                {
                    wearingOxygenKit = true;
                    hasOxygen = false;
                    OxygenStart();
                }
                else
                {
                    wearingOxygenKit = false;
                }
                break;

            default:
                break;
        }
    }
    private void Update()
    {
        OxygenDrain();
        if (Input.GetKeyDown(KeyCode.O))
        {
            outside = !outside;
        }
    }

    public void ContinueGame()
    {
        //use this from the menu
        isStarting = true;
        if (myScene != -1f)
        {
            SceneManager.LoadScene(myScene);
        }
    }

    public void NewGame()
    {
        hasSaved = false;
        hasOxygen = false;
        isStarting = true;
        SceneManager.LoadScene("Bus");
    }

    void OxygenDrain()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            characterPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            myScene = SceneManager.GetActiveScene().buildIndex;
        }
        if (hasOxygen)
        {
            if (outside)
            {
                oxygen += -1f * Time.deltaTime;
            }
            else
            {
                if (oxygen < maxOxygen)
                {
                    oxygen += (6f * myMinutesMult) * Time.deltaTime;
                    busOxygen -= (6f * myMinutesMult) * Time.deltaTime;
                }
                busOxygen += -1f * Time.deltaTime;
            }
            busOxygen += (calmLevel - 1f) * Time.deltaTime;
        }
    }
}
