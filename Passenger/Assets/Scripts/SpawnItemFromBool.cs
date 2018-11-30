using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class SpawnItemFromBool : MonoBehaviour {
    bool myBool;
    bool hasSpawned = false;
    public Flowchart myFlow;

    //this string should be named EXACTLY as the variable you want to load (ie, "spawnObject" or "Spawn Laptop" or whatever else.
    public string myItem;

    //create a gameobject and place it where you want the object to be
    public GameObject myInstantiatePosition;

    //drag and drop the item to be spawned when the bool is true;
    public GameObject myItemSpawn;

    private void Update() {
        myBool = myFlow.GetBooleanVariable(myItem);
        if (myBool &&!hasSpawned) {
            Instantiate(myItemSpawn, myInstantiatePosition.transform.position, myInstantiatePosition.transform.rotation);
            hasSpawned = true;
        }
    }
}
