using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coloring : MonoBehaviour
{
    public SpriteRenderer[] Sp;
    public Color col;

    private Color ground;
    private Color Build;

    private void Start()
    {
        ground = Sp[0].color;
        Build  = Sp[0].color;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Untagged")) 
        { 
        foreach(SpriteRenderer data in Sp) 
            {
                data.color = col;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("EmptyBuilding")|| collision.CompareTag("WorkingBuilding")) 
        {
            Sp[0].color = ground;
            Sp[1].color = Build;
        }
    }

    public Color GetColor() 
    {
        return ground;
    }
}
