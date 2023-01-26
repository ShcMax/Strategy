using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUnit : MonoBehaviour, ISelectable, IAttackable
{
    [SerializeField] private float _health = 100;
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Transform _pivotPoint;

    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;
    public Transform PivotPoint => _pivotPoint;
}


    
