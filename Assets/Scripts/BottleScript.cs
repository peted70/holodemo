using UnityEngine;
using HoloToolkit.Unity;

[RequireComponent(typeof(Rigidbody))]
public class BottleScript : MonoBehaviour
{
    private Vector3 _position;
    private Quaternion _rotation;
    private AudioSource _audio;

    public void Start()
    {
        _position = this.gameObject.transform.localPosition;
        _rotation = this.gameObject.transform.localRotation;

        _audio = GetComponent<AudioSource>();
    }

    public void OnSelect()
    {
        // HitInfo
        var rayHit = GazeManager.Instance.HitInfo;
        GetComponent<Rigidbody>().AddForceAtPosition(rayHit.normal * -5, rayHit.point, ForceMode.Impulse);

        _audio.pitch = Random.Range(0.5f, 2.0f);
        _audio.Play();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 2)
        {
            _audio.pitch = Random.Range(0.5f, 2.0f);
           _audio.Play();
        }
    }


    public void Reset()
    {
        GetComponent<Rigidbody>().Sleep();
        this.gameObject.transform.localPosition = _position;
        this.gameObject.transform.localRotation = _rotation;
    }
}
