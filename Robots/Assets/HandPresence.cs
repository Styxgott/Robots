using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Quaternion = UnityEngine.Quaternion;


public class HandPresence : MonoBehaviour
{
   
    private InputDevice targetDevice;
    private XRRig rig;
    private CharacterController character;
    private float speed = 1.0f;
    public XRNode inputSource;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        rig = GetComponent<XRRig>();
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics leftControllerCharacteristics =
            InputDeviceCharacteristics.Left |
            InputDeviceCharacteristics.Controller; // Get input device from right controller 
        //InputDevices.GetDeviceAtXRNode(inputSource);
        InputDevices.GetDevices(devices); //List of all input devices
        InputDevices.GetDevicesWithCharacteristics(leftControllerCharacteristics, devices); // List of devices with characteristics
        
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
     Quaternion head = Quaternion.Euler(0, Camera.transform.eulerAngles.y, 0);

        if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out UnityEngine.Vector2 axisValue))
        {
            Debug.Log(axisValue.x +"" + axisValue.y);
            UnityEngine.Vector3 direction = head * new UnityEngine.Vector3(axisValue.x, 0, axisValue.y);
            character.Move(direction * speed * Time.deltaTime);
        }
        

        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.2f)
        {
            Debug.Log("Trigger pulled" + triggerValue );
        }

        
       
    }
}