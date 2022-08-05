using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Selection : MonoBehaviour
{
    public HandModel[] handModel;

    public ArmModel[] armModel;

   
   [SerializeField] private Transform CustomizerSpot = default;
   [SerializeField] private Transform ArmSpot = default;

    private List<GameObject> hands = new List<GameObject>();
       private List<GameObject> arms;


        public int currentHand = 0;
    public int currentArm = 0;
   
        


 public void Start()
    {     
       if( CustomizerSpot.childCount == 0)
       {
           foreach (var hand in handModel)
        {   
            GameObject h = Instantiate(hand.HandPrefab,CustomizerSpot);
            h.SetActive(false);
            hands.Add(h);

        }

         /*   foreach (var arm in armModel)
        {
            GameObject a = Instantiate(arm.ArmPrefab,CustomizerSpot);
            a.SetActive(false);
            arms.Add(a);
        }*/

            hands[currentHand].SetActive(true); 
           // arms[currentArm].SetActive(true);
       }
      }  
        
        
      


     void  ShowPreviousHand(){
    hands[currentHand].SetActive(false);
    currentHand--;
     if(currentHand < 0)
        {
        currentHand += hands.Count;
        } 
        hands[currentHand].SetActive(true);
    }

    void  ShowNextHand(){
     hands[currentHand].SetActive(false);
     currentHand = (currentHand +1)% hands.Count;
     hands[currentHand].SetActive(true);
}


}


