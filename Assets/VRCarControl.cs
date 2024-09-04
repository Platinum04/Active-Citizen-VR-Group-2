using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;
using VehicleBehaviour;
using UnityEngine.InputSystem;


public class VRCarControl : MonoBehaviour
{
    // Reference to the XR Knob
    [SerializeField] private XRKnob xrKnob;

    // Reference to the car controller
    [SerializeField] private VehicleBehaviour.WheelVehicle carController;

    public float throttle;

    public InputActionProperty pinchanimact;
    public InputActionProperty lpinchanimact;

    void Update()
    {
        if (xrKnob != null && carController != null)
        {
            // Get the current value of the knob (0 to 1)
            float knobValue = xrKnob.value;

            // Map the knob value (0 to 1) to the car's steering value (-1 to 1)
            float steeringValue = Mathf.Lerp(-15f, 15f, knobValue);

            // Apply the steering value to the car
            carController.Steering = steeringValue;

            carController.Throttle = pinchanimact.action.ReadValue<float>() - lpinchanimact.action.ReadValue<float>();  //Mathf.Clamp(throttle, -1f, 1f);
        }
    }
    public void CheckSteering()
    {
        carController.Steering = Mathf.Lerp(carController.SteerAngle, -carController.SteerAngle, xrKnob.value);
    }
}



