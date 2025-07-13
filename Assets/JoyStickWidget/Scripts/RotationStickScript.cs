using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotationStickScript : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerDownHandler
{
    //===============================================================
    // PRIVATE VARIABLES
    //===============================================================

    private Vector2 startPosition;
    private float parentRadius;
    private RectTransform rectTransform;
    private RotationJoystickScript parentJoystick;
    private bool isDragging = false;

    //===============================================================
    // INITIALIZATION
    //===============================================================

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        parentJoystick = GetComponentInParent<RotationJoystickScript>();

        float parentWidth = transform.parent.GetComponent<RectTransform>().rect.width;
        rectTransform.sizeDelta = new Vector2(parentWidth / 3, parentWidth / 3);
    }

    private void Start()
    {
        startPosition = rectTransform.position;
        parentRadius = (transform.parent.GetComponent<RectTransform>().rect.width) / 2;
    }

    //===============================================================
    // INPUT HANDLING
    //===============================================================

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDragging)
            return;

        float xDistance = (eventData.position.x - startPosition.x);
        float yDistance = (eventData.position.y - startPosition.y);
        double distance = Math.Sqrt(xDistance * xDistance + yDistance * yDistance);

        if (distance <= parentRadius)
        {
            transform.position = eventData.position;
        }
        else
        {
            float xPos = ((eventData.position.x - startPosition.x) * parentRadius / (float)distance) + startPosition.x;
            float yPos = ((eventData.position.y - startPosition.y) * parentRadius / (float)distance) + startPosition.y;
            transform.position = new Vector2(xPos, yPos);
        }

        float xValue = (transform.position.x - startPosition.x) / parentRadius;
        float yValue = (transform.position.y - startPosition.y) / parentRadius;

        if (parentJoystick != null)
        {
            parentJoystick.SetInputValues(xValue, yValue);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;

        transform.position = startPosition;

        if (parentJoystick != null)
        {
            parentJoystick.SetInputValues(0f, 0f);
        }
    }
}