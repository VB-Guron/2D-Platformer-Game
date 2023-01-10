using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropping : MonoBehaviour
{
      [SerializeField] private GameObject Crown;
      [SerializeField] private Transform place;

    public void DropCrown()
    {
        Instantiate(Crown, transform.position, transform.rotation);
        
    }  
}
