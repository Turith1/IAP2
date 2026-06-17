using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "FoundPlayer", story: "if player is [found] change [state]", category: "Action", id: "7d57c6e111f41bb49e67d9279b4a51a3")]
public partial class FoundPlayerAction : Action
{
    [SerializeReference] public BlackboardVariable<EnemyDetection> Found;
    [SerializeReference] public BlackboardVariable<AIState> State;

    protected override Status OnUpdate()
    {
        if (Found.Value.DetectPlayer())
        {
            State.Value = AIState.Chase;
        }
        else
            State.Value = AIState.Patrol;

        return Status.Success;
    }
}

