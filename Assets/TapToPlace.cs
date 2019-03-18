using Microsoft.MixedReality.Toolkit.Core.EventDatum.Input;
using Microsoft.MixedReality.Toolkit.Core.Interfaces.InputSystem.Handlers;
using Microsoft.MixedReality.Toolkit.Core.Interfaces.SpatialAwarenessSystem.Observers;
using Microsoft.MixedReality.Toolkit.Core.Services;
using Microsoft.MixedReality.Toolkit.Core.Utilities;
using UnityEngine;

public class TapToPlace : MonoBehaviour, IMixedRealityPointerHandler
{
    public bool placing;
    private bool moved;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnSelect()
    {
        placing = !placing;
        Debug.Log("placing = " + (placing == true ? "true" : "false"));
    }

    // Update is called once per frame
    void Update()
    {
        // If the user is in placing mode,
        // update the placement to match the user's gaze.
        if (placing)
        {
            // Do a raycast into the world that will only hit the Spatial Mapping mesh.
            var headPosition = CameraCache.Main.transform.position;
            var gazeDirection = CameraCache.Main.transform.forward;

            Debug.Log("head position = " + headPosition);
            Debug.Log("gaze direction = " + gazeDirection);

            RaycastHit hitInfo;

            var mrsao = MixedRealityToolkit.Instance.GetService<IMixedRealitySpatialAwarenessObserver>();
            //Debug.Log("mrsao = " + (mrsao != null ? "non-null" : "null"));
            var pl = mrsao.DefaultPhysicsLayer;

            int layerMask = 1 << pl;
            Debug.Log("physics layer = " + pl);
            if (Physics.Raycast(headPosition, gazeDirection, out hitInfo, 30.0f, layerMask))
            { 
                // Here is where you might consider adding intelligence
                // to how the object is placed.  For example, consider
                // placing based on the bottom of the object's
                // collider so it sits properly on surfaces.
                var pivot = headPosition + gazeDirection * (hitInfo.distance - 0.2f);
                Debug.Log("pivot = " + pivot);

                //this.transform.position = pivot;

                this.transform.position = Vector3.Lerp(this.transform.position, pivot, 0.2f);

                // Rotate this object to face the user.
                Quaternion toQuat = CameraCache.Main.transform.localRotation;

                toQuat.x = 0;
                toQuat.z = 0;

                transform.localRotation = toQuat;
                moved = true;
            }
        }
    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
    }

    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
    }

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        if (placing == true && moved == true)
        {
            placing = false;
            moved = false;
            
            //When here we can init the physics on the bottles..
            var stack = GetComponentInChildren<StackedBottles>();
            stack.InitPhysics();
        }
    }
}
