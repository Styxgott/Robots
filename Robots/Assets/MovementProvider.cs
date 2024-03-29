﻿using System;


using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;



public class MovementProvider : LocomotionProvider

{  

     public float speed = 1.0f;

    public List<XRController> controllers = null;

    private CharacterController characterController = null;

    private Camera head;



    protected override void Awake()

    {

        characterController = GetComponent<CharacterController>();
       

        head = GetComponent<XROrigin>().Camera;



    }



    private void Start()

    {

        PositionController();

    }



    private void Update()

    {

        PositionController();

        CheckforInput();

    }



    private void PositionController()

    {

        float headHeight = Mathf.Clamp(head.transform.localPosition.y,1,2);

        characterController.height = headHeight;



        Vector3 newCenter = Vector3.zero;

        newCenter.y = characterController.height/2;

        newCenter.y = characterController.skinWidth;



        newCenter.x = head.transform.localPosition.x;

        newCenter.z = head.transform.localPosition.z;



        characterController.center = newCenter;

    }



    private void CheckforInput()

    {

        foreach (var controller in controllers)

        {

            if(controller.enableInputActions)

            {

                CheckForMovement(controller.inputDevice);

            }

        }

    }



    private void CheckForMovement( InputDevice device)

    {

        if(device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 position))

        {

            StartMove(position);

        }

    }



    private void StartMove( Vector2 position){

       

        Vector3 direction = new Vector3(position.x, 0,position.y );

        Vector3 headRotation = new Vector3(0,head.transform.eulerAngles.y,0);

        direction = Quaternion.Euler(headRotation)* direction;



        Vector3 movement = direction * speed;

        characterController.Move(movement * Time.deltaTime);

    }



}

