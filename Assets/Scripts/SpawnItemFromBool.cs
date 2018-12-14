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

    //drag and drop the item to be activated when the bool is true;
    public GameObject myItemCollider;
    MeshCollider myCol;

    private void Start() {
        myCol = myItemCollider.GetComponent<MeshCollider>();
        if (myFlow == null) {
            myFlow = GameObject.FindGameObjectWithTag("Flowchart").GetComponent<Flowchart>();
        }
        myCol.enabled = false;
    }

    private void Update() {
        if (!hasSpawned) {
        myBool = myFlow.GetBooleanVariable(myItem);
            if (myBool) {
                myCol.enabled = true;
                hasSpawned = true;
            }
        }

    }
}
