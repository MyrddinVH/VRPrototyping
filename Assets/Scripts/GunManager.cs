using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{

    [SerializeField] private Animator gunBlowBack;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject barrelEnd;


    [SerializeField] private float fireRate = .1f;
    [SerializeField] private float bulletSpeed;

    private bool isShooting;


    public void PullTrigger(){
        Debug.Log("trigger pulled");
        if(!isShooting){
            StartCoroutine(FireRate());
        }
    }

    private void FireProjectile(){
        Debug.Log("fire");
        gunBlowBack.Play("PistolBlowBack");
        GameObject bullet = Instantiate(bulletPrefab, barrelEnd.transform.position, barrelEnd.transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * (bulletSpeed * -1));
    }

    IEnumerator FireRate(){
        isShooting = true;
        Debug.Log(isShooting);
        FireProjectile();
        yield return new WaitForSeconds(fireRate);
        isShooting = false;
        Debug.Log(isShooting);
    }
}
