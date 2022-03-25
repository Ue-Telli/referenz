/*using Unity.Mathematics;
using Unity.Entities;
using UnityEngine;
using Unity.Transforms;

public struct Movement : IComponentData 
{
    public float movementSpeed;
    public int2 starPos;
    public int2 endpos;

}   

public class MovementSystem: ComponentSystem 
{ 
protected override void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Entities.ForEach((Entity entity, ref Translation transe) =>
            {
                // EntityManager.AddComponentData(entity, new Movement);
            }
                );
        }
    }
}*/