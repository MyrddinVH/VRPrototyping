using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{

    [SerializeField] private Animator gunBlowBack;
    [SerializeField] private GameObject bullet;

    private bool isShooting;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PullTrigger(){
        isShooting = true;
        gunBlowBack.Play("PistolBlowBack");
    }

    public void ResetShooting(){
        
    }
}
