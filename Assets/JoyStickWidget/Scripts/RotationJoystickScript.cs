using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityPosEvent : UnityEvent<float> { }

public class RotationJoystickScript : MonoBehaviour
{
    //===============================================================
    // CONFIGURABLE PARAMETERS
    //===============================================================

    [Header("Target")]
    [SerializeField] private Transform target;

    [Header("Rotation parameters")]
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private bool invertXAxis = false;
    [SerializeField] private bool invertYAxis = false;
    [SerializeField] private bool useLocalRotation = true;

    [Header("Rotation axes")]
    [SerializeField] private bool rotateAroundX = true;
    [SerializeField] private bool rotateAroundY = true;
    [SerializeField] private bool rotateAroundZ = false;

    //===============================================================
    // PRIVATE VARIABLES
    //===============================================================

    private float xInput = 0f;
    private float yInput = 0f;
    private float previousXInput = 0f;
    private float previousYInput = 0f;
    private RectTransform joystickBG;
    private RectTransform joystickHandle;

    public UnityPosEvent OnXRotationChange;
    public UnityPosEvent OnYRotationChange;

    //===============================================================
    // INITIALIZATION
    //===============================================================

    private void Awake()
    {
        joystickBG = GetComponentInChildren<UnityEngine.UI.Image>(true).rectTransform;

        joystickHandle = GetComponentInChildren<UnityEngine.UI.RawImage>(true).rectTransform;

        if (OnXRotationChange == null)
            OnXRotationChange = new UnityPosEvent();

        if (OnYRotationChange == null)
            OnYRotationChange = new UnityPosEvent();
    }

    private void Start()
    {
        if (joystickHandle != null)
        {
            float parentWidth = joystickBG.rect.width;
            joystickHandle.sizeDelta = new Vector2(parentWidth / 3, parentWidth / 3);
        }
    }

    //===============================================================
    // UPDATE LOGIC
    //===============================================================

    private void Update()
    {
        if (target != null)
        {
            ApplyRotation();
        }

        if (xInput != previousXInput)
        {
            OnXRotationChange.Invoke(xInput);
            previousXInput = xInput;
        }

        if (yInput != previousYInput)
        {
            OnYRotationChange.Invoke(yInput);
            previousYInput = yInput;
        }
    }

    //===============================================================
    // ROTATION LOGIC
    //===============================================================

    private void ApplyRotation()
    {
        if (xInput == 0 && yInput == 0)
            return;

        float xFactor = invertXAxis ? -1f : 1f;
        float yFactor = invertYAxis ? -1f : 1f;

        Vector3 rotationAmount = Vector3.zero;

        if (rotateAroundX)
            rotationAmount.x = yInput * rotationSpeed * yFactor * Time.deltaTime;

        if (rotateAroundY)
            rotationAmount.y = xInput * rotationSpeed * xFactor * Time.deltaTime;

        if (rotateAroundZ)
            rotationAmount.z = (xInput + yInput) * rotationSpeed * 0.5f * Time.deltaTime;

        if (useLocalRotation)
        {
            target.Rotate(rotationAmount, Space.Self);
        }
        else
        {
            target.Rotate(rotationAmount, Space.World);
        }
    }

    //===============================================================
    // API PUBLIQUE
    //===============================================================

    public void SetInputValues(float x, float y)
    {
        xInput = x;
        yInput = y;
    }

    public void SetTargetTransform(Transform target)
    {
        this.target = target;
    }

    public void SetRotationSpeed(float speed)
    {
        rotationSpeed = speed;
    }

    public void ToggleAxisInversion(string axis)
    {
        if (axis.ToLower() == "x")
            invertXAxis = !invertXAxis;
        else if (axis.ToLower() == "y")
            invertYAxis = !invertYAxis;
    }

    public void ToggleRotationAxis(string axis)
    {
        if (axis.ToLower() == "x")
            rotateAroundX = !rotateAroundX;
        else if (axis.ToLower() == "y")
            rotateAroundY = !rotateAroundY;
        else if (axis.ToLower() == "z")
            rotateAroundZ = !rotateAroundZ;
    }
}