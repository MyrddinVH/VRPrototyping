using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new gun", menuName = "guns")]
public class WeaponData : ScriptableObject
{
    public GameObject bulletCase;
    public int ammo;
    public float fireRate;
    public string animationName;
    public float casingLifeTime;
    public AudioClip gunFire;
    public AudioClip reload;
    public AudioClip noAmmo;
    public AudioClip magInserted;
}
