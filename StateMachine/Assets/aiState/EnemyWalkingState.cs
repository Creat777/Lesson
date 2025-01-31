using UnityEngine;

public partial class StateMachine
{
    public class EnemyWalkingState : IState
    {
        private StateMachine stateMachine;

        public EnemyWalkingState(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }
        public void Enter()
        {
            Debug.Log("Entered Walking State");
        }

        public void Update(GameObject obj)
        {
            Vector3 enemy_pos = obj.transform.position;
            Vector3 player_pos = obj.GetComponent<aiState>().Player.transform.position;
            float dis = Vector3.Distance(enemy_pos, player_pos);

            Vector3 Dir = player_pos - enemy_pos;
            Dir = Dir.normalized * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.I))
            {
                stateMachine.ChangeState(new EnemyIdleState(stateMachine));
            }
            else
            {
                enemy_pos += Dir;
            }

            obj.transform.position = enemy_pos;

            

            /*if (Input.GetKeyDown(KeyCode.A)) // 체크 코드
            {
                stateMachine.ChangeState(new EnemyAttackState(stateMachine));
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                stateMachine.ChangeState(new EnemyIdleState(stateMachine));
            }*/
        }

        public void Exit()
        {
            Debug.Log("Exiting Walking State");
        }


    }
}
