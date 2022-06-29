using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "HandModel", menuName = "Hand")]
public class HandModel : ScriptableObject
{
    [SerializeField] private string partName = default;
    [SerializeField] private GameObject handPrefab = default;
    
    public string PartName => partName;
    public GameObject HandPrefab => handPrefab;
}
