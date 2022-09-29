using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class Selection : MonoBehaviour
{
    public HandModel[] HandModels;
    public Transform HandSpot;
    private int currentHand = 0;
    private List<GameObject> hands;
    public InputActionProperty arrowleft;
      public InputActionProperty arrowright;

    private void Start()
    {
        hands = new List<GameObject>();
        foreach (var model in HandModels)
        {
            GameObject go = Instantiate(model.handPrefab,HandSpot.position,Quaternion.identity);
            go.SetActive(false);
            hands.Add(go);
            
        }

        ShowHandFromList();
        arrowleft.EnableDirectAction();
        arrowleft.action.performed += _ => OnClickPrev();
        arrowright.EnableDirectAction();
        arrowright.action.performed += _ => OnClickNext();

    }

    void ShowHandFromList()
    {
        hands[currentHand].SetActive(true);
    }

    public void OnClickNext()
    {
        hands[currentHand].SetActive(false);
        if (currentHand < hands.Count - 1)
        {
            currentHand++;
        }
        else currentHand = 0;
    }
    
    public void OnClickPrev()
    {
        hands[currentHand].SetActive(false);
        if (currentHand == 0)
        {
            currentHand = hands.Count - 1;

        }
        else currentHand--;

    }
}