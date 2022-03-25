using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="data",menuName ="Buildtyp")]
public class BuildFunktion: ScriptableObject
{
    public string buildname;
    public string workername;
    public string stuff="leer";
    private int prodktionsValue;
    public static  float timeProPodukt;
    private static bool   IsWorking;
    private static float FinishedProduktValue;
    private Worker Arbeiter;
    
   // private Sprite Workerimage;

    private void Awake()
    {
        IsWorking = false;
        FinishedProduktValue = 0;
    }

    
    public void SetWorker(bool sendWorker,Worker abeitsloser) 
    {
        IsWorking = sendWorker;
        Arbeiter = abeitsloser;
    }
    public int CreatProdukt() 
    { 
        Debug.Log(FinishedProduktValue);
        if (IsWorking) 
        {          
            if (FinishedProduktValue < 0.99f) 
            { 
            FinishedProduktValue += 0.01f;
            }
            if (FinishedProduktValue == 1f) 
            {
                return prodktionsValue;
            }
            else 
            {
                return 0;
            }
        }
        else 
        {
            return 0;
        }
       
    }
    
    // Start is called before the first frame update
}
