using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack2Behaviour : StateMachineBehaviour
{
    BossBehaviour boss;
    Vector2 curretnDrop;
    bool onLine1 = true;
    Vector2 direction;
    float lastDrop;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = animator.GetComponent<BossBehaviour>();
        curretnDrop = boss.P1_0.localPosition;
        onLine1 = true;
        direction = (boss.P1_1.localPosition - boss.P1_0.localPosition).normalized;
        lastDrop = Mathf.NegativeInfinity;

        DropeFruit();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(lastDrop + boss.Attack2Length / boss.Attack2Length < Time.fixedTime)
        {

            DropeFruit();
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    private void DropeFruit()
    {
        if(onLine1 && Vector2.Distance(curretnDrop, boss.P1_0.localPosition) > boss.Attack2Length)
        {
            curretnDrop += direction * boss.Attack2Length;
            Instantiate(boss.BadFruitPrefab).transform.localPosition = curretnDrop;

        }
        else if (onLine1)
        {
            curretnDrop = boss.P1_1.localPosition;
            Instantiate(boss.BadFruitPrefab).transform.localPosition = curretnDrop;
            onLine1 = false;
            curretnDrop = boss.P2_0.localPosition;
            direction = (boss.P2_1.localPosition - boss.P2_0.localPosition).normalized;
        }
        else if (!onLine1 && Vector2.Distance(curretnDrop, boss.P2_1.localPosition) > boss.Attack2Length)
        {
            curretnDrop = boss.P1_1.localPosition;
            Instantiate(boss.BadFruitPrefab).transform.localPosition = curretnDrop;
            
        }
        else
        {
            curretnDrop = boss.P2_1.localPosition;
            Instantiate(boss.BadFruitPrefab).transform.localPosition = curretnDrop;
            onLine1 = true;
            curretnDrop = boss.P1_0.localPosition;
            direction = (boss.P1_1.localPosition - boss.P1_0.localPosition).normalized;
        }
        lastDrop = Time.fixedTime;
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
