using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmwandlerBehavior : StateMachineBehaviour
{
    private GameObject wr;
    private string Rohstoff;
    private int RS_value;
    private string produziertesStuff;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        wr = animator.GetComponent<Building>().worker;
        produziertesStuff = animator.GetComponent<Building>().BuildF.stuff;
        Rohstoff = wr.GetComponent<Worker>().Stuff;
        //RS_value = wr.GetComponent<Worker>().Value;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        switch (Rohstoff) 
        {
            case "Holz":  wr.GetComponent<Worker>().Stuff = produziertesStuff;
                          wr.GetComponent<Worker>().Value = 10;break;
            case "Tier":
                wr.GetComponent<Worker>().Stuff = produziertesStuff;
                wr.GetComponent<Worker>().Value = 10; break;
        }
        wr.GetComponent<Animator>().SetBool("NewStuff",true);
        wr.GetComponent<Animator>().Play("GoToStorge");
        animator.StopPlayback();
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
