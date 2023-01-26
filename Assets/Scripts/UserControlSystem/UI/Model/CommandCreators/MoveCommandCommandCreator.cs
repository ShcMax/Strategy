using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;

public class MoveCommandCommandCreator : CommandCreatorBase<IMoveCommand>
{
    [Inject] private AssetContext _context;

    private Action<IMoveCommand> _creationsCallback;

    [Inject]
    private void Init(Vector3Value groundClicks)
    {
        groundClicks.OnNewValue += onNewValue;
    }

    private void onNewValue(Vector3 groundClick)
    {
        _creationsCallback?.Invoke(_context.Inject(new MoveCommand(groundClick)));
        _creationsCallback = null;
    }

    protected override void classSpecificCommandCreation(Action<IMoveCommand> creationCallback)
    {
        _creationsCallback = creationCallback;
    }
    public override void ProcessCancel()
    {
        base.ProcessCancel();
        _creationsCallback = null;
    }
}
