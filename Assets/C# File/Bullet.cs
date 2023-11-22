using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Flags]
    public enum EProjectileType
    {
        Common = 1,
        Rare = 2,
        Legendary = 4
    }

    [SerializeField] private EProjectileType bulletType;

    public EProjectileType BulletType
    {
        get { return bulletType; }
    }
}
