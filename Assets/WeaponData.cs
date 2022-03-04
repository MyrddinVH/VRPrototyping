using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new gun", menuName = "guns")]
public class WeaponData : ScriptableObject
{
    public GameObject bulletCase;
    public float fireRate;
    public string animationName;
}
