using UnityEngine;
using HoloToolkit.Unity;

[RequireComponent(typeof(Rigidbody))]
public class BottleScript : MonoBehaviour
{
    public void OnSelect()
    {
        // HitInfo
        var rayHit = GazeManager.Instance.HitInfo;
        GetComponent<Rigidbody>().AddForceAtPosition(rayHit.normal * -5, rayHit.point, ForceMode.Impulse);

        Debug.Log("Hit the bottle");
    }
}
