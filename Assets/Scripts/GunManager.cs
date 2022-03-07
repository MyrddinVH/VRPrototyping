using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    [Tooltip("the weapondata for the desired gun")]
    [SerializeField] private WeaponData weaponData;
    [Tooltip("object with the animator attached for the kickback")]
    [SerializeField] private Animator kickBackAnimator;
    [Tooltip("end of the barrel, where the raycast will be fired from")]
    [SerializeField] private GameObject barrelEnd;
    [Tooltip("the position casings will be ejected from")]
    [SerializeField] private Transform casingEjectPos;
    [Tooltip("the prefab for the impact sparks")]
    [SerializeField] private GameObject impactSparks;
    [Tooltip("source where all the gun audio will be played from")]
    [SerializeField] private AudioSource SFX;
    [Tooltip("muzzleflash prefab")]
    [SerializeField] private ParticleSystem muzzleFlash;

    private bool isShooting;
    private bool isShootingAuto;
    private int ammoCurrent;

    void Update(){
        if(isShootingAuto){
            if(!isShooting){
                StartCoroutine(FireRate());
            }
        }
    }

    public void PullTrigger(){ // pull the triger once. for single shot weapons like pistols
        if(!isShooting){
            StartCoroutine(FireRate());
        }
    }

    public void PullTriggerContinuous(){ // start automatic fire
        isShootingAuto = true;
    }

    public void ReleaseTriggerContinuous(){ // end automatic fire
        isShootingAuto = false;
    }

    private void FireProjectile(){ // shoot raycast if gun is allowed to fire
        if(ammoCurrent != 0){
            kickBackAnimator.Play(weaponData.animationName);
            SFX.PlayOneShot(weaponData.gunFire);
            muzzleFlash.Play();
            ammoCurrent = ammoCurrent - 1;
            EjectCasing();

            RaycastHit hit;
            if(Physics.Raycast(barrelEnd.transform.position, barrelEnd.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity)){
                GameObject hitSparks = Instantiate(impactSparks, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
        else{
            SFX.PlayOneShot(weaponData.noAmmo);
        }
    }

    IEnumerator FireRate(){ // handles the fire rate of the weapon
        isShooting = true;
        FireProjectile();
        yield return new WaitForSeconds(weaponData.fireRate);
        isShooting = false;
    }

    private void EjectCasing(){ // ejects a casing object from the gun when fired
        GameObject tempCase = Instantiate(weaponData.bulletCase, casingEjectPos.position, casingEjectPos.rotation) as GameObject;
        tempCase.GetComponent<Rigidbody>().AddRelativeForce(1,1,0 * 2, ForceMode.Impulse);
        Destroy(tempCase, weaponData.casingLifeTime);
    }

    public void MagInserted(){
        SFX.PlayOneShot(weaponData.magInserted);
        ammoCurrent = weaponData.ammo;
    }

    public void EjectMag(){
        
    }
}
