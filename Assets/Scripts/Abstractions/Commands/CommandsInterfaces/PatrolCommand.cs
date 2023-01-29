using UnityEngine;
public class PatrolCommand : IPatrolCommand
{
    public Vector3 From { get; }
    public Vector3 To { get; }
}