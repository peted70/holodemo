using Microsoft.MixedReality.Toolkit.Core.EventDatum.Input;
using Microsoft.MixedReality.Toolkit.Core.Interfaces.InputSystem.Handlers;
using System;
using System.Collections;
using UnityEngine;

public class BenchScript : MonoBehaviour, IMixedRealityPointerHandler
{
    private bool debounce;

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        if (debounce == false)
        {
            transform.parent.SendMessage("OnSelect");
            Debug.Log("propagate message");
            debounce = true;

            // Set it back next time around the loop
            InvokeDelegate(() => debounce = false, 0.0f);
        }
    }

    IEnumerator InvokeDelegateImpl(Action action, float delay)
    {
        yield return new WaitForSeconds(delay);
        action();
    }

    public void InvokeDelegate(Action action, float delay)
    {
        StartCoroutine(InvokeDelegateImpl(action, delay));
    }

    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
    }

    //public void OnSelect()
    //{
    //    transform.parent.SendMessage("OnSelect");
    //    Debug.Log("propagate message");
    //}
}
