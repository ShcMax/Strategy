using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveCommand : ICommand
{
    public Vector3 Target { get; }
}
