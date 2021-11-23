using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIZoomImage : MonoBehaviour, IScrollHandler
{
    private Vector3 initialScale;

    [SerializeField]
    private float zoomSpeed = 0.1f;
    [SerializeField]
    private float maxZoom = 3f;


    private void Awake()
    {
        initialScale = transform.localScale;
    }

    public void OnScroll(PointerEventData eventData)
    {
        var delta = Vector3.one * (eventData.scrollDelta.y * zoomSpeed);
        var desiredScale = transform.localScale + delta;

        desiredScale = ClampDesiredScale(desiredScale);

        transform.localScale = desiredScale;
    }

    private Vector3 ClampDesiredScale(Vector3 desiredScale)
    {
        desiredScale = Vector3.Max(initialScale, desiredScale);
        desiredScale = Vector3.Min(initialScale * maxZoom, desiredScale);
        return desiredScale;
    }

    public void clampToNode()
    {
        transform.localScale = new Vector3(2, 2, 2);
        
        transform.position = NodeManager.instance.searchNode().GetComponent<NodoName>().part.position;
    }

    public void resetImage()
    {
        transform.localScale = initialScale;
        transform.position = new Vector3(0,0,0);
    }
}