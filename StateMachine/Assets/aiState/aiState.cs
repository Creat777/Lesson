using UnityEngine;

public class aiState : MonoBehaviour
{
    public player Player;

    private StateMachine stateMachine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stateMachine = new StateMachine();
        stateMachine.ChangeState(new StateMachine.EnemyIdleState(stateMachine));
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update(gameObject);
    }
}
