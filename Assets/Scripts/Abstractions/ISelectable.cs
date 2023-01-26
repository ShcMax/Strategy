using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public interface ISelectable: IHealthHolder
    {
        float Health { get; }
        float MaxHealth { get; }
        Sprite Icon { get; }
    }
