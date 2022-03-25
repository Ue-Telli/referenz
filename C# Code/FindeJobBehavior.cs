using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindeJobBehavior : StateMachineBehaviour
{
    private GameObject build;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        build = GameObject.FindGameObjectWithTag("EmptyBuilding");
       /* if(build != null)
        {
        build.GetComponent<Animator>().StopPlayback();
        }   */    
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(build != null) 
        {
            build.GetComponent<Animator>().StopPlayback();
            animator.gameObject.GetComponent<Worker>().WorkPlace = build;
            build.tag = "WorkingBuilding";
            build.GetComponent<Building>().worker = animator.gameObject;
            animator.gameObject.name = build.GetComponent<Building>().BuildF.workername;
            animator.gameObject.tag = "Arbeiter";
            animator.SetBool("HasWork", true);
        }
        else { build = GameObject.FindGameObjectWithTag("EmptyBuilding"); }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
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
