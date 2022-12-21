using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommandExecutor
{
    void ExecuteCommand(object command);
}
