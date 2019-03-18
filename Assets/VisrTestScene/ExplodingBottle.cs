using UnityEngine;
using System.Collections;
using Microsoft.MixedReality.Toolkit.Core.Interfaces.InputSystem.Handlers;
using Microsoft.MixedReality.Toolkit.Core.EventDatum.Input;

[RequireComponent(typeof(Rigidbody))]
public class ExplodingBottle : MonoBehaviour, IMixedRealityPointerHandler
{
    //void OnLookStateAction(RaycastHit rayHit)
    //{

    //    GetComponent<Rigidbody>().AddForceAtPosition(rayHit.normal * -5, rayHit.point, ForceMode.Impulse);
    //}
    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        Vector3 normal = eventData.Pointer.Result.Details.LastRaycastHit.normal;
        var point = eventData.Pointer.Result.Details.LastRaycastHit.point;
        GetComponent<Rigidbody>().AddForceAtPosition(normal * -5, point, ForceMode.Impulse);
    }

    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
    }
}
