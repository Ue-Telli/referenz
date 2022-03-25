using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public Vector3 position { get; set; }
    public string guid { get; set; }
    public string[] itemname = new string[3];
    public int[] itemvalue = new int[3] {0,0,10};
    private bool[] IsFull=new bool[4] { false,false,true,true};
    private bool hasFreePlace = true;
    //fehler ist hier irgendwo

    private void Awake()
    {
        position = transform.position;
    }
    public void setItem(string name, int value) 
    {
        for (int i =0; i< itemname.Length; i++) 
        {
            int freePlatz = itemvalue[i] + value;
            if(itemname[i] == name && freePlatz < 11) 
            {
                itemvalue[i] += value;
                if (itemvalue[i] > 9) 
                {
                    IsFull[i] = true;              
                }
                break;
            }
            else if(itemname[i] == "") 
            {
                itemname[i] = name;
                itemvalue[i] = value;
                break;
            }
            
        }
        /*int i = 0;
        foreach (string zeug in itemname)
        {
            
            int freePlatz = itemvalue[i] + value;
            if (zeug == name && freePlatz < 11)
            {
                itemvalue[i] +=  value;
                continue;
            }
            else if (zeug == null)
            {
                itemname[i] = name;
                itemvalue[i] += value;
                continue;
            }
            i++;*/
        //itemname[0] = name;
        //itemvalue[0] += value;
        
    }
    public bool CheckIsFull() 
    {
    /*foreach(int data in itemvalue) 
        {
            if (data<11)
            {
                IsFull = false;
                break;
            }
            else
            {
                IsFull = true;   
            }         
        }*/
        return hasFreePlace;
    }
    // der fehler ist hier
    public bool CheckHasPlace(int value, string name) 
    {
        int insgesamt;        
        int i = 0;

        foreach (int data in itemvalue) 
        {   
            if (itemname[i] == name|| itemname[i]=="")
            {   
                insgesamt = data + value;
                if (IsFull[i] == false && insgesamt < 11) 
                {
                    hasFreePlace = true;
                    break;
                }
                else if(IsFull[i] == true) 
                {
                hasFreePlace = false;
                }
            }
            else 
            {
                hasFreePlace = false;
            }          
            i++;
        }
        return hasFreePlace;
    }
       // hasFreePlace = false;
       /* foreach (int data in itemvalue)
        {
            insgesamt = data + value;
            if (data > 9) { IsFull[i] = true; }
            if (i != itemvalue.Length)
            {
                if (IsFull[i] == false && IsFull[i + 1] == false)
                {
                    insgesamt = data + value + itemvalue[i + 1];
                    if (insgesamt < 20)
                    {
                        hasFreePlace = true;
                        break;
                    }
                }
                else if (IsFull[i]==false&& insgesamt<10) 
                {
                    hasFreePlace = true;
                    break;
                }
                else { hasFreePlace = false; }
                
            }
            i++;
        }*/
    
    /* struct Item
    {
        public string itemname { get; set; }
        public int itemvalue { get; set; }
    }
    private Item[] item = new Item[4];

    public void DropIn(string name,int value) {
        
        
    }*/
 }
