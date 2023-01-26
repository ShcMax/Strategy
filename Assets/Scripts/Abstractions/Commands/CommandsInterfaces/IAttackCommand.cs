using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackCommand : ICommand
{
    public IAttackable Target { get ;} 
}
