using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Selection : MonoBehaviour
{
    public HandModel[] handModel;
    public ArmModel[] armModel;
    public HeadModel[] headModel;
    public LegModel[] legModel;
    public FootModel[] footModel;


    public Transform CustomizerSpot;

    private List<GameObject> hands;
    private List<GameObject> arms;
    private List<GameObject> heads;
    private List<GameObject> legs;
    private List<GameObject> foots;


    public int currentHand = 0;
    public int currentArm = 0;
    public int currentHead = 0;
    public int currentLeg = 0;
    public int currentFoot = 0;
        


 public void Start()
    {     
       
        
        hands = new List<GameObject>();
        
       
        foreach (var hand in handModel)
        {   
            GameObject h = Instantiate(hand.part,CustomizerSpot.position , Quaternion.identity)  ;
            h.SetActive(false);
            h.transform.SetParent(CustomizerSpot);
            hands.Add(h);

        }
       /* foreach(var arm in armModel)
        {
             GameObject a = Instantiate(arm.part, new Vector3(-10,5,-3)  , Quaternion.identity)  ;
            a.SetActive(false);
            a.transform.SetParent(CustomizerSpot);
            arms.Add(a);
        }

    foreach(var head in headModel)
        {
             GameObject h = Instantiate(head.part,CustomizerSpot.position , Quaternion.identity)  ;
            h.SetActive(false);
            h.transform.SetParent(CustomizerSpot);
            heads.Add(h);
        }
    
    foreach(var leg in legModel)
        {
             GameObject l = Instantiate(leg.part,CustomizerSpot.position , Quaternion.identity)  ;
            l.SetActive(false);
            l.transform.SetParent(CustomizerSpot);
            legs.Add(l);
        }

         foreach(var foot in footModel)
        {
             GameObject f = Instantiate(foot.part,CustomizerSpot.position , Quaternion.identity)  ;
            f.SetActive(false);
            f.transform.SetParent(CustomizerSpot);
            foots.Add(f);
        }
        */
        ShowPartFromList();
      
}
    

 void ShowPartFromList(){
            hands[currentHand].SetActive(true);
            arms[currentArm].SetActive(true);

        }
     
    
   void Update(){
       if(Input.GetKeyDown(KeyCode.A)){
           ShowPreviousHand();
       }
        if(Input.GetKeyDown(KeyCode.D)){
           ShowNextHand();
       }
   }


 public void  ShowPreviousHand(){
    hands[currentHand].SetActive(false);
    currentHand--;
     if(currentHand < 0)
        {
        currentHand += hands.Count;
        } 
        hands[currentHand].SetActive(true);
    }

public void  ShowNextHand(){
     hands[currentHand].SetActive(false);
     currentHand = (currentHand +1)% hands.Count;
     hands[currentHand].SetActive(true);
}

}


