using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "AttackMFer", story: "[check] distance, if [close] attack, else change [state]", category: "Action", id: "c2591656d1a716424da441053b1635bc")]
public partial class AttackMFerAction : Action
{
    [SerializeReference] public BlackboardVariable<EnemyDetection> Check;
    [SerializeReference] public BlackboardVariable<EnemyAttack> Close;
    [SerializeReference] public BlackboardVariable<AIState> State;
    private float AttackDistance = 2;

    protected override Status OnUpdate()
    {
        if (Check.Value.PlayerDistance() <= AttackDistance)
        {
            Close.Value.AttackPlayer();
        }
        else
            State.Value = AIState.Chase;

        return Status.Success;
    }
}

