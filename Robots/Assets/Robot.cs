using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.AI;



public class Robot : MonoBehaviour
{
   
    public float speed = 1.0f;
    public InputActionProperty moveButton;
    public NavMeshAgent agent ;
    private bool arrived = false;
    public InputActionProperty homeButton;
    // Start is called before the first frame update
    void Start()
    {
       // transform.Rotate(0.0f, 270.0f, 0.0f, Space.Self);
       moveButton.EnableDirectAction();
       moveButton.action.performed += _ => MovetoObjectA();
       homeButton.EnableDirectAction();
       homeButton.action.performed += _ => MovetoObjectB();
      



    }

    // Update is called once per frame
    void Update()
    {
        
        if (agent.remainingDistance > 0 && agent.remainingDistance <= 5)
        {
            agent.isStopped = true;
            
            Debug.Log("arrived");
            if (agent.isStopped)
            {
                Debug.Log(agent.remainingDistance);
            }
           
        }
    }

    public void MovetoObjectA()
    {
        
        
        if (agent.isActiveAndEnabled) // check if Agent is on the way
        {
            Debug.Log("move");
        }

       
        agent.SetDestination(GameObject.Find("CapsuleA").transform.position);
      
       
      
      
       
            
           
        
       
        
        
    }

    public void MovetoObjectB()
    {
        Debug.Log("moving home");
        agent.stoppingDistance = 4.0f;
        agent.SetDestination(GameObject.Find("HomeBox").transform.position);
        
       
    }

    public void TTS()
    {
        
    }
}