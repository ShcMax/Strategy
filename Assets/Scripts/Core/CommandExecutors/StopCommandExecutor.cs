using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCommandExecutor : CommandExecutorBase<IStopCommand>
{
    public override void ExecuteSpecificCommand(IStopCommand command)
    {
        Debug.Log($"{name} is stopped!");
    }
}
