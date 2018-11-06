using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigCollider : MonoBehaviour {
    public GameObject myPlayer;
    private void Update()
    {
        transform.position = myPlayer.transform.position;
    }
}
