using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    public GameObject[] handModel;
    private List<GameObject> hands;
    private int currentHand = 0;
    void Start()
    {
        hands = new List<GameObject>();
        foreach(var hand in handModel)
            GameObject h = Instantiate(hand, new Vector3(-9f,2.5f,2.0f),Quaternion.identity);
        h.SetActive(false);
        h.transform.SetParent(CustomizerSpot);
        hands.Add(h);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
