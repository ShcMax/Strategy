using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CommandButtonsModel
{
    public event Action<ICommandExecutor> OnCommandAccepted;
    public event Action OnCommandSent;
    public event Action OnCommandCancel;

    [Inject] private CommandCreatorBase<IProduceUnitCommand> _unitProducer;
    [Inject] private CommandCreatorBase<IAttackCommand> _attacker;
    [Inject] private CommandCreatorBase<IStopCommand> _stopper;
    [Inject] private CommandCreatorBase<IMoveCommand> _mover;
    [Inject] private CommandCreatorBase<IPatrolCommand> _patroller;

    private bool _commandIsPending;

    public void OnCommandButtonClicked(ICommandExecutor commandExecutor)
    {
        if (_commandIsPending)
        {
            processCancel();
        }
        _commandIsPending = true;
        OnCommandAccepted.Invoke(commandExecutor);

        _unitProducer.ProcessCommandExecutors(commandExecutor, command => executeCommandWrapper(commandExecutor, command));
        _attacker.ProcessCommandExecutors(commandExecutor, command => executeCommandWrapper(commandExecutor, command));
        _stopper.ProcessCommandExecutors(commandExecutor, command => executeCommandWrapper(commandExecutor, command));
        _mover.ProcessCommandExecutors(commandExecutor, command => executeCommandWrapper(commandExecutor, command));
        _patroller.ProcessCommandExecutors(commandExecutor, command => executeCommandWrapper(commandExecutor, command));
    }

    public void executeCommandWrapper(ICommandExecutor commandExecutor, object command)
    {
        commandExecutor.ExecuteCommand(command);
        _commandIsPending = false;
        OnCommandSent?.Invoke();
    }

    public void OnSelectionChanged()
    {
        _commandIsPending = false;
        processCancel();
    }

    private void processCancel()
    {
        _unitProducer.ProcessCancel();
        _attacker.ProcessCancel();
        _stopper.ProcessCancel();
        _mover.ProcessCancel();
        _patroller.ProcessCancel();

        OnCommandCancel?.Invoke();
    }
}
