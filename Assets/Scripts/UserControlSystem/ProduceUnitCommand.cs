using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public sealed class ProduceUnitCommand : IProduceUnitCommand
{
    public GameObject UnitPrefab => _unitPrefab;
    [InjectAsset("Chomper")] private GameObject _unitPrefab;

    private void Do()
    {
        Debug.LogError("Run through Reflection");
    }
}
