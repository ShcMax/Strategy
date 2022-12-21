using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProduceUnitCommand : ICommand
{
    GameObject UnitPrefab { get; }
}
   

