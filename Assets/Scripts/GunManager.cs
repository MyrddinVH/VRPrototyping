using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{

    [SerializeField] private Animator gunBlowBack;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject barrelEnd;
    [SerializeField] private string blowBackAnimName;


    [SerializeField] private float fireRate = .1f;
    [SerializeField] private float bulletSpeed;

    private bool isShooting;
    private bool isShootingAuto;



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
        
        gunBlowBack.Play(blowBackAnimName);

        RaycastHit hit;
        if(Physics.Raycast(barrelEnd.transform.position, barrelEnd.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity)){
            Debug.Log("raycast hit");
        }

        // GameObject bullet = Instantiate(bulletPrefab, barrelEnd.transform.position, barrelEnd.transform.rotation);
        // bullet.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * (bulletSpeed * -1));
    }

    IEnumerator FireRate(){
        isShooting = true;
        FireProjectile();
        yield return new WaitForSeconds(fireRate);
        isShooting = false;
    }
}
