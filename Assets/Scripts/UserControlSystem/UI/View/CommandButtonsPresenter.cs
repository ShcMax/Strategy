using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;

public class CommandButtonsPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectable;
    [SerializeField] private CommandButtonsView _view;    

    [Inject] private CommandButtonsModel _model;

    private ISelectable _currentSelectable;
    
    void Start()
    {
        _view.OnClick += _model.OnCommandButtonClicked;
        _model.OnCommandSent += _view.UnblockAllInteractions;
        _model.OnCommandCancel += _view.UnblockAllInteractions;
        _model.OnCommandAccepted += _view.BlockInteraction;
        _selectable.OnSelected += OnSelected;

        OnSelected(_selectable.CurrentValue);
        
    }
    
    private void OnSelected(ISelectable selectable)
    {
        if (_currentSelectable == selectable)
        {
            return;
        }

        if(selectable != null)
        {
            _model.OnSelectionChanged();
        }
        _currentSelectable = selectable;

        _view.Clear();

        if (selectable != null)
        {
            var commandExecutors = new List<ICommandExecutor>();
            commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
            _view.MakeLayout(commandExecutors);
        }
    }

    //private void OnButtonClick(ICommandExecutor commandExecutor)
    //{
    //    var unitProducer = commandExecutor as CommandExecutorBase<IProduceUnitCommand>;
    //    if(unitProducer != null)
    //    {
    //        unitProducer.ExecuteSpecificCommand(_context.Inject(new ProduceUnitCommand()));
    //        return;
    //    }
    //    var attacker = commandExecutor as CommandExecutorBase<IAttackCommand>;
    //    if(attacker != null)
    //    {
    //        attacker.ExecuteSpecificCommand(_context.Inject(new AttackCommand()));
    //        return;
    //    }
    //    var stopper = commandExecutor as CommandExecutorBase<IStopCommand>;
    //    if(stopper != null)
    //    {
    //        stopper.ExecuteSpecificCommand(_context.Inject(new StopCommand()));
    //        return;
    //    }
    //    var mover = commandExecutor as CommandExecutorBase<IMoveCommand>;
    //    if(mover != null)
    //    {
    //        mover.ExecuteSpecificCommand(_context.Inject(new MoveCommand()));
    //        return;
    //    }
    //    var patrol = commandExecutor as CommandExecutorBase<IPatrolCommand>;
    //    if(patrol != null)
    //    {
    //        patrol.ExecuteSpecificCommand(_context.Inject(new PatrolCommand()));
    //        return;
    //    }
    //    throw new ApplicationException($"{nameof(CommandButtonsPresenter)}.{nameof(OnButtonClick)}:Unknown type of command executor: {commandExecutor.GetType().FullName}!");        
    //}
}
