using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedObject : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectedValue;        
    [SerializeField] private GameObject _mainBuildingPrefab;
    [SerializeField] private MainBuilding mainBuilding;

    [Header("SelectedZoneBuildings")]
    [SerializeField] private GameObject _selectedMainBuildingZone;

    void Start()
    {
        _selectedValue.OnSelected += OnSelected;
        OnSelected(_selectedValue.CurrentValue);      
    }

    private void OnSelected(ISelectable selected)
    {        
        if (selected != null && _mainBuildingPrefab.GetComponent<MainBuilding>())
        {            
            _selectedMainBuildingZone.SetActive(true);            
        }
        else
        {
            _selectedMainBuildingZone.SetActive(false);            
        }        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
