using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddStuffBehavior : StateMachineBehaviour
{
    private bool isEnded;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
 /*  override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        isEnded = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (isEnded) 
        {
            animator.SetBool("HasStuff",true);
            animator.SetBool("onSurfes", true);
        }
    }
    public void AdddingStuff() 
    {
        isEnded = true;
    }*/
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Worker Wr = animator.gameObject.GetComponent<Worker>();
        switch (animator.gameObject.name) 
        {
            case "J�ger": Wr.Value = 4; Wr.Stuff = "Holz";
                          animator.SetBool("HasStuff", true); break;
        }
       // Debug.Log("erreicht");
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
