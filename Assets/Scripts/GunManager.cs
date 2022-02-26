using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    [SerializeField] private WeaponData weaponData;
    [SerializeField] private Animator kickBackAnimator;
    [SerializeField] private GameObject barrelEnd;
    [SerializeField] private Transform casingEjectPos;

    private bool isShooting;
    private bool isShootingAuto;

    void Update(){
        if(isShootingAuto){
            if(!isShooting){
                StartCoroutine(FireRate());
            }
        }
    }

    public void PullTrigger(){
        if(!isShooting){
            StartCoroutine(FireRate());
        }
    }

    public void PullTriggerContinuous(){
        // trigger pulled for automatic weapons
        isShootingAuto = true;
    }

    public void ReleaseTriggerContinuous(){
        //trigger released for automatic weapons
        isShootingAuto = false;
    }

    private void FireProjectile(){
        
        kickBackAnimator.Play(weaponData.animationName);
        EjectCasing();

        RaycastHit hit;
        if(Physics.Raycast(barrelEnd.transform.position, barrelEnd.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity)){
            Debug.Log("raycast hit");
        }
    }

    IEnumerator FireRate(){
        isShooting = true;
        FireProjectile();
        yield return new WaitForSeconds(weaponData.fireRate);
        isShooting = false;
    }

    private void EjectCasing(){
        GameObject tempCase = Instantiate(weaponData.bulletCase, casingEjectPos.position, casingEjectPos.rotation) as GameObject;
        // tempCase.GetComponent<Rigidbody>().velocity = new Vector3(transform.localPosition.x,transform.localPosition.y,0);
        tempCase.GetComponent<Rigidbody>().AddRelativeForce(1,1,0 * 2, ForceMode.Impulse);
    }
}
