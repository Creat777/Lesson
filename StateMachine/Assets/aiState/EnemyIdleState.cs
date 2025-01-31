using UnityEngine;

public partial class StateMachine
{
    public class EnemyIdleState : IState
    {
        private StateMachine stateMachine;

        public EnemyIdleState(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }
        
        public void Enter()
        {
            Debug.Log("Entered Idle State");
        }
        
        public void Update(GameObject obj)
        {
            Vector3 enemy_pos = obj.transform.position;
            Vector3 player_pos = obj.GetComponent<aiState>().Player.transform.position;
            float dis = Vector3.Distance(enemy_pos, player_pos);
            //Debug.Log(dis);

            if (Input.GetKeyDown(KeyCode.W)) // 체크 코드
            {
                // 일정 거리 안에 player가 오면
                //if (dis < 6)
                {
                    stateMachine.ChangeState(new EnemyWalkingState(stateMachine));
                }
            }
        }

        public void Exit()
        {
            Debug.Log("Exiting Idle State");
        }
    }
}
