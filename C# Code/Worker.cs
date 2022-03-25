using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Tilemaps;

public class Worker :MonoBehaviour
{
    public GameObject WorkPlace { get; set; }
    private GameObject FreeStorage;
    public string Stuff { get; set; }
    public int Value { get; set;}
    public float Speed; //{ get { return 1f; } }
    
    public GameObject getFreeStorage() 
    {
        float dis=3000;
        FreeStorage = null;
        GameObject[] store = GameObject.FindGameObjectsWithTag("Lager");
        foreach(GameObject data in store) 
        {
            if (data.GetComponent<Slot>().CheckIsFull()==true) 
            {
                if (dis > Vector3.Distance(transform.position, data.transform.position)) 
                {
                    FreeStorage = data;
                    dis = Vector3.Distance(transform.position, data.transform.position);
                }
            }
            
         /*   if (FreeStorage == null) 
            {
            FreeStorage = data;
            dis = Vector2.Distance(transform.position, FreeStorage.transform.position);   
            }
            else if (dis > Vector2.Distance(transform.position,data.transform.position)) 
            {
                dis = Vector2.Distance(transform.position, data.transform.position);
                FreeStorage = data;
            }
            */


        }
        //if (HatGefunden==false) { FreeStorage = null; }
        return FreeStorage;
        
    }
  

    public void EndOfAnime(string Vector) 
    { 
    gameObject.GetComponent<Animator>().SetBool(Vector, false);
    }
}
