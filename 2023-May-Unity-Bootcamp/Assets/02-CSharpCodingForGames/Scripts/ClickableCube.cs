using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableCube : MonoBehaviour, ISelectHandler
{

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log("Select");
    }
}
