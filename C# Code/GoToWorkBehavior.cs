using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoToWorkBehavior : StateMachineBehaviour
{
    private GameObject Build;
    private Worker Wr;
  

    private float speed =1f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Wr = animator.gameObject.GetComponent<Worker>();
       // System = GameObject.Find("BuildManager");
       // if (animator.GetBool("HasStuff")&& animator.GetBool("OnBuilding")) 
       // {
       // Build = Wr.getFreeStorage();
      //  place = Build.GetComponent<Slot>();
        //}
       // else 
       // { 
        Build = Wr.WorkPlace; 
        //}
        
        //speed = animator.gameObject.GetComponent<Worker>().Speed;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        if(Build != null) // ist build nicht gleich null
        {
            float dir = Vector2.Distance(animator.transform.position, Build.transform.position);// übergebe die aktuelle distanz
            
            if(dir < 0.1f) {    // ist abstand kleine als 0.1 
                
                    //erreichen vom Arbeitsplatz
                    if (animator.GetBool("HasStuff") == false)  
                    {
                        animator.SetBool("OnBuilding", true); // wenn der arbeiter kein material hat setze am gebäude auf war
                    }
                    else if (animator.GetBool("HasStuff") == true && animator.GetBool("NewStuff") == false) //abreiter hat zeug  und aber kein berarbeitetes
                    {
                        Build.GetComponent<Animator>().Play("verarbeitung"); // starte die animation vom gebäude
                        animator.StopPlayback();                        // stope animation vom arbeiter
                        animator.SetBool("OnStorage", false);           // am lager auf falsch gesetzt
                    }
                    else if (animator.GetBool("HasStuff") == true && animator.GetBool("NewStuff") == true) // rohstoff bearbeitet
                    { 
                    animator.SetBool("OnBuilding", true); // setze onbuliding auf wahr
                    } 
                //
                
                }
               /* else
                {
                    // erreichen vom Lager
                place.setItem(Wr.Stuff, Wr.Value);
                    Debug.Log(Wr.Stuff);
                System.GetComponent<BuildSystem>().Chance();
                animator.GetComponent<Worker>().Stuff = "leer";
                animator.GetComponent<Worker>().Value = 0;
                animator.SetBool("HasStuff", false);
                animator.SetBool("NewStuff", false);
                animator.SetBool("OnBuilding", false);
                animator.SetBool("OnStorage", true);
               // Build = Wr.WorkPlace;
                //blol.text = Build.GetComponent<Building>().GetAllValueOfItem("Holz").ToString();
                }
                
            } */
            else { // wenn abstand zu größ ist dann bewege arbeiter
                animator.transform.position = Vector2.MoveTowards(animator.transform.position, Build.transform.position, speed * Time.deltaTime);
                 }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      /* if(animator.GetBool("HasStuff") && animator.GetBool("OnBuilding")) 
        {
            switch (Wr.Stuff) 
            {
               // case "Holz":Wr.Stuff = "Latten"; Wr.Value= Wr.Value*2 ;break;
              //  case "Tier": Wr.Stuff = "Fleisch"; Wr.Value = Wr.Value * 2; break;
            }
        }*/
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
