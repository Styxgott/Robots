using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ArmModel", menuName = "Arm")]
public class ArmModel : ScriptableObject
{
  
[SerializeField] private string partName = default;
    [SerializeField] private GameObject armPrefab = default;
    
    public string PartName => partName;
    public GameObject ArmPrefab => armPrefab;
}
