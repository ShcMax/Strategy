using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;


public class ProduceUnitCommandCommandCreator : CommandCreatorBase<IProduceUnitCommand>
{
    [Inject] private AssetsContext _context;

    protected override void classSpecificCommandCreation(Action<IProduceUnitCommand> creationCallback)
    {
        creationCallback?.Invoke(_context.Inject(new ProduceUnitCommandHeir()));
    }
}
