using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Qualities { Poor, Normal, Epic, Legendary, Spectaular, PrettyFrigginGood }

[CreateAssetMenu(fileName = "NewWeapon", menuName = "MattGame/Weapon")]
public class Weapon : ScriptableObject
{
    public Qualities weaponQuality;
    public float damage;
    public float attackSpeed;
    public string weaponSound;
}
