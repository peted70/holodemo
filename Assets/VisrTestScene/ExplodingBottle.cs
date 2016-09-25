using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class ExplodingBottle : MonoBehaviour {

    void OnLookStateAction(RaycastHit rayHit)
    {
        
        GetComponent<Rigidbody>().AddForceAtPosition(rayHit.normal * -5, rayHit.point, ForceMode.Impulse);
    }
}
