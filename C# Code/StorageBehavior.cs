using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageBehavior : StateMachineBehaviour
{
    private GameObject System,Build;
    private Worker Wr;
    private Slot place;
    public float Timer=0.5f;
    private float speed = 1f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Wr = animator.gameObject.GetComponent<Worker>();
        System = GameObject.Find("BuildManager");
        Build = Wr.getFreeStorage();
        if (Build != null) 
        { 
        place = Build.GetComponent<Slot>();
        }             
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //LagerVoll:  // wird aufgerufen wenn alle lager Voll sind
        if (Build != null) // ist build nicht gleich null
        {
            if (place.CheckHasPlace(Wr.Value,Wr.Stuff) == true) 
            { 
            float dir = Vector2.Distance(animator.transform.position, Build.transform.position);// übergebe die aktuelle distanz

            if (dir < 0.1f)
            {
                if (Wr.Value > 0)
                {
                    
                        Timer -= Time.deltaTime;
                        if (Timer < 0f)
                        {
                            place.setItem(Wr.Stuff, 1);
                            Wr.Value -= 1;
                            System.GetComponent<BuildSystem>().Chance();
                            Debug.Log(Wr.Stuff);
                            Timer = 0.5f;
                        }
                    
                    

                }
                    else 
                    {
                        animator.SetBool("HasStuff", false);
                        animator.SetBool("NewStuff", false);
                        animator.SetBool("OnBuilding", false);
                        animator.SetBool("OnStorage", true);
                    }
               
            }
            else
            {
                animator.transform.position = Vector2.MoveTowards(animator.transform.position, Build.transform.position, speed * Time.deltaTime);
            }
        }
            else if (Wr.Value == 0) 
            {
                    animator.SetBool("HasStuff", false);
                    animator.SetBool("NewStuff", false);
                    animator.SetBool("OnBuilding", false);
                    animator.SetBool("OnStorage", true);
            }
            else 
            { 
                Debug.Log("lager Voll");
                Build = Wr.getFreeStorage();
            }
         }


        else if (Build==null)
        {
            Wr.WorkPlace.GetComponent<Animator>().SetBool("FoundYeri", false);
            Wr.WorkPlace.GetComponent<Animator>().Play("YeriYok");
            animator.StopPlayback();
            Build = Wr.getFreeStorage();
            if (Build != null) { place = Build.GetComponent<Slot>(); }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Debug.Log(place.itemname[0]);
        System.GetComponent<BuildSystem>().Chance();
        Wr.Stuff = "leer";
        Wr.Value = 0;
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
