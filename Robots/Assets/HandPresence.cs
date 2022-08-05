using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.XR;
using Vector2 = System.Numerics.Vector2;

public class HandPresence : MonoBehaviour
{
   
    private InputDevice targetDevice;

    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics =
            InputDeviceCharacteristics.Right |
            InputDeviceCharacteristics.Controller; // Get input device from right controller 
       
        InputDevices.GetDevices(devices); //List of all input devices
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices); // List of devices with characteristics
        
        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics); // Name and characteristics of the right device
        }

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        if (targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue)
        {
            Debug.Log("PrimaryButtonPressed");
        }

        

        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.2f)
        {
            Debug.Log("Trigger pulled" + triggerValue );
        }

        
       
    }
}