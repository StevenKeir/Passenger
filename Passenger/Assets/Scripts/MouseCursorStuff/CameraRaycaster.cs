using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class CameraRaycaster : MonoBehaviour
{
    public Layer[] layerPriorities;

    [SerializeField] float distanceToBackground = 100f;
    Camera viewCamera;

    RaycastHit raycastHit;
    public RaycastHit hit
    {
        get { return raycastHit; }
    }

    Layer layerHit;
    public Layer currentLayerHit
    {
        get { return layerHit; }
    }

    public delegate void OnLayerChange(Layer newLayer); // declare OnLayerChange delegate type
    public event OnLayerChange onLayerChange; // instantiate an observer set
    // TODO consider deregistering layerChangeObservers when leaving game scenes

    private bool layerChanged = false;
    private bool wasNullLayer = false;


   public class NavMeshHitResult
    {
        public bool result;
        public NavMeshHit navMeshHit;
     
        public NavMeshHitResult(bool result, NavMeshHit navMeshHit)
        {
            this.result = result;
            this.navMeshHit = navMeshHit;
        }
    }
    
    void Start() // TODO Awake?
    {
        viewCamera = Camera.main;
        layerHit = 0;
        wasNullLayer = true;
        onLayerChange(Layer.RaycastEndStop);
    }

    void Update()
    {
        // Look for and return priority layer hit
        foreach (Layer layer in layerPriorities)
        {
            var hit = RaycastForLayer(layer);
            if (hit.HasValue) // if it hit a layer
            {
              
                raycastHit = hit.Value; // store the raycast results to rayCastHit for some reason?
                if (layerHit != layer) // if layer has changed
                {
                    layerHit = layer;
                    wasNullLayer = false;
                    onLayerChange(layerHit); // Call ALL the delegates, i.e. broadcast to them
                    //print ("layerHit = "+layerHit);
                }
                return;
            }
        }

        // if no layer was detected, but there was a layer last update (an undetected change from layer to no layer)
        if (wasNullLayer == false)
        {
            //print("Did not hit a layer!");
            // return background hit
            wasNullLayer = true;
            raycastHit.distance = distanceToBackground;
            layerHit = Layer.RaycastEndStop;
            onLayerChange(Layer.RaycastEndStop); // Call ALL the delegates, i.e. broadcast to them
        }
    }

    public NavMeshHitResult RaycastToNavmesh(Vector3 hitPoint)
    {
        int layerMask = 1 << (int)Layer.Walkable; 

        NavMeshHit navMeshHit;
        var result = NavMesh.SamplePosition(hitPoint, out navMeshHit, 1, layerMask);
        return new NavMeshHitResult(result, navMeshHit);
    }

    public bool IsReachable(Vector3 startPoint, Vector3 endPoint)
    {
        // Both methods work, except they both return sky as a navigable point...
        
        // SAMPLE POSITION DETECTION METHOD - 
        NavMeshHitResult navMeshHitResult = RaycastToNavmesh(endPoint);
        bool result = navMeshHitResult.result;
        

        /*
        // NAVMESH PATH DETECTION METHOD - is the point navigable?
        bool result = false;
        NavMeshPath path = new NavMeshPath();
        if (NavMesh.CalculatePath(startPoint, endPoint, NavMesh.AllAreas, path))
            return true;
      */
        return result;
    }

    RaycastHit? RaycastForLayer(Layer layer)
    {
       // print("Raycasting layer = " + (int)layer);

        int layerMask = 1 << (int)layer; // See Unity docs for mask formation
        bool hasHit = false;
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit; // used as an out parameter
        
        if (layer == Layer.Walkable)
        {
            hasHit = Physics.Raycast(ray, out hit, distanceToBackground, layerMask);
            if (hasHit)
            {
                Physics.Raycast(ray, out hit, distanceToBackground, layerMask);
                hasHit = IsReachable(hit.point, ray.origin);
            }
        }
        else
        { 
            hasHit = Physics.Raycast(ray, out hit, distanceToBackground, layerMask);
        }

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        if (hasHit)
        {
            return hit;
        }
        return null;
    }
}
