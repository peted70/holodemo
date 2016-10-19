using UnityEngine;

public class BenchScript : MonoBehaviour
{
    public void OnSelect()
    {
        transform.parent.SendMessage("OnSelect");
        Debug.Log("propagate message");
    }
}
