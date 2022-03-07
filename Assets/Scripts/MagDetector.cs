using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagDetector : MonoBehaviour
{
    [SerializeField] private GunManager gunManager;

    void OnTriggerEnter(Collider collider){
        gunManager.MagInserted();
    }
}
