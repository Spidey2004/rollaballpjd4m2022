using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolBehaviour : StateMachineBehaviour
{
    public EnemyController _myEnemyController;
    
    // OnStateEnter é chamado quando uma transição começa e a máquina de estados começa a avaliar este estado
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _myEnemyController = animator.gameObject.GetComponent<EnemyController>();
        _myEnemyController.SetDistance(_myEnemyController.distanceToFollow); // Define a distância do inimigo para seguir o jogador
        Debug.Log(_myEnemyController.name + " entrou no estado Patrol.");
    }

    // OnStateUpdate é chamado em cada frame de atualização entre OnStateEnter e OnStateExit callbacks
    // OnStateUpdate é chamado em cada frame de atualização entre OnStateEnter e OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Verifique a distância entre o inimigo e o ponto de patrulha atual
        _myEnemyController.CheckPatrolPointDistance();
        float distance = _myEnemyController._enemyFSM.GetFloat("Distance");
        
        // Se o inimigo estiver próximo o suficiente do ponto de patrulha atual, avance para o próximo ponto
        if (distance <= 0.5f)
        {
            _myEnemyController.UpdatePatrolPoint(); // Avance para o próximo ponto de patrulha
            _myEnemyController.SetDestinationToPatrolRoute(); // Defina o destino do inimigo como o ponto de patrulha atual
        }
        Debug.Log(_myEnemyController.name + " entrou no estado Patrol,OnStateUpdate.");
    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log(_myEnemyController.name + " saiu do estado Patrol.");
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
