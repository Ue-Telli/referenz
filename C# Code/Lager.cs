using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class Lager : MonoBehaviour
{
    public List<Slot> warehouse= new List<Slot>();

    private void Start()
    {
        NewWareHouse();
    }
    public void NewWareHouse() 
    {
        Slot[] allSluts = FindObjectsOfType(typeof(Slot)) as Slot[];
        foreach (Slot data in allSluts) 
        {
            warehouse.Add(data);
           // Debug.Log(data.gameObject.name);
        }
    }
    public void SetResorce(string name,int itemValue) 
    {
        Slot[] allSluts = FindObjectsOfType(typeof(Slot)) as Slot[];
        foreach (Slot data in allSluts)
        {
           foreach(Elemente item in data.Slot1) 
            {
                int wert = item.value + itemValue;
                if (item.name == name && wert < 10)
                {
                    item.value += itemValue;
                    break;
                }
               else if (item.name == "leer")
                {
                    item.name = name;
                    item.value = itemValue;
                    break;
                }
            }
        }
    }

    public Transform GetFreeStorage()
    {
       Transform p;
        /*Slot[] allSluts = FindObjectsOfType(typeof(Slot)) as Slot[];
         foreach (Slot data in allSluts)
         {
             p = data.transform;
             continue;
             foreach (Elemente item in data.Slot1)
             {
                 int wert = item.value + value;
                 if (item.name == name && wert<10)
                 {
                     p=data.transform;
                     break;
                 }

             }
         }
        p = warehouse[0].transform;
        return p;
    } 

    // Start is called before the first frame update

}*/
