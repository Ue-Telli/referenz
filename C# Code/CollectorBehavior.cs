using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CollectorBehavior : StateMachineBehaviour
{
    private GameObject Building;
    private Worker Wr;
    private string buildname;
    private float speed = 1f;
    private Building bully;
    private Tilemap tm;
    private Vector3Int treepos;
     //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Wr = animator.gameObject.GetComponent<Worker>();
        Building = Wr.WorkPlace;
        bully = Building.GetComponent<Building>();
        buildname = bully.BuildF.buildname;
        tm = bully.map;
        
        switch (buildname) 
        {
            case "Jäger": bully.FindAllTile("tree");
                          treepos=bully.GetNextTile(); break;
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
   override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
        //Vector3 test = tm.CellToWorld(bully.GetNextTile());
        Vector3Int player = tm.WorldToCell(animator.transform.position);  
        if (bully.cellPos != treepos) 
        {
            float dir = Vector3Int.Distance(player, treepos);

            if (dir > 0.01f) 
            {
                animator.transform.position = Vector3.MoveTowards(animator.transform.position, tm.CellToWorld(treepos), speed * Time.deltaTime);
            }
            else 
            {
                switch (buildname) 
                {
                    case "Jäger":tm.SetTile(treepos,null);

                        //bully.FindAllTile("tree");
                        //treepos = bully.GetNextTile();
                        animator.SetBool("OnBuilding", false);
                        animator.SetBool("onSurfes", true); break;
                                 //animator.SetBool("HasStuff",true) 
                }
               
            }
        }
        else 
        {
            treepos = bully.GetNextTile();
            //Debug.Log(treepos);
           // Debug.Log(bully.cellPos);
        }
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
