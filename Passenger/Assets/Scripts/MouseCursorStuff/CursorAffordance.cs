using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Layer
{
    UI = 5,             // this is a unity default constant, so never change this unless you are setting up unique UI layers
    Walkable = 10,        // where character can walk to
    Item = 12,           // thing to pick up
    Character = 13,          // hostile NPCs (attacking a valid NPC will turn it into an character)
    RaycastEndStop = 31
}

[RequireComponent(typeof(CameraRaycaster))]
public class CursorAffordance : MonoBehaviour
{
    [SerializeField] Texture2D walkCursor = null;
    [SerializeField] Texture2D itemCursor = null;
    [SerializeField] Texture2D characterCursor = null;
    [SerializeField] Texture2D defaultCursor = null;
    [SerializeField] Texture2D nullCursor = null;
    [SerializeField] Vector2 cursorHotspot = new Vector2(0, 0);

    CameraRaycaster cameraRaycaster;

    // Use this for initialization
    void Start()
    {
        Cursor.SetCursor(walkCursor, cursorHotspot, CursorMode.Auto);

        cameraRaycaster = GetComponent<CameraRaycaster>();
        cameraRaycaster.onLayerChange += OnLayerChanged; // registering the delegate
    }

    // Update is called once per frame

    void OnLayerChanged(Layer newLayer)
    {
        //print(CameraRaycaster.currentLayerHit);
       // print("Cursor Affordance delegate reporting for duty!");

        switch (newLayer)
        {
            case Layer.Walkable:
                //Debug.Log("I see walkable!");
                Cursor.SetCursor(walkCursor, cursorHotspot, CursorMode.Auto);
                break;
            case Layer.Item:
               // Debug.Log("I see item!");
                Cursor.SetCursor(itemCursor, cursorHotspot, CursorMode.Auto);
                break;
            case Layer.Character:
                //Debug.Log("I see character!");
                Cursor.SetCursor(characterCursor, cursorHotspot, CursorMode.Auto);
                break;
            case Layer.RaycastEndStop:
                Debug.Log("Raycast end stop!");
                Cursor.SetCursor(nullCursor, cursorHotspot, CursorMode.Auto);
                break;
            default:
                Debug.Log("Default...");
                Cursor.SetCursor(null, cursorHotspot, CursorMode.Auto);
                return;
        }
    }
}
