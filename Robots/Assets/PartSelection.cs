using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PartSelection : MonoBehaviour
{
    public HandModel[] handModel;
    public Transform CustomizerSpot;

    private List<GameObject> hands;
    public int currentHand = 0;

 public void Start()
    {
        
        hands = new List<GameObject>();
        Vector3 pos = new Vector3(-9,2.5,-2.1);
        foreach (var handModel in handModel)
        {
            GameObject go = Instantiate(handModel, pos.transform.position, Quaternion.identity);
            go.SetActive(false);
            go.transform.SetParent(CustomizerSpot);
            hands.Add(go);

        }
      ShowPartFromList();
      
       
   

}
 void ShowPartFromList(){
            hands[currentHand].SetActive(true);
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

