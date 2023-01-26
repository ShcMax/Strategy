using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CommandCreatorBase<T> where T : ICommand
{
    public ICommandExecutor ProcessCommandExecutors(ICommandExecutor commandExecutor, Action<T> callback)
    {
        var classSpecificExecutor = commandExecutor as CommandExecutorBase<T>;
        if (classSpecificExecutor != null)
        {
            classSpecificCommandCreation(callback);
        }
        return commandExecutor;
    }

    protected abstract void classSpecificCommandCreation(Action<T> creationCallback);

    public virtual void ProcessCancel()
    {

    }
}
