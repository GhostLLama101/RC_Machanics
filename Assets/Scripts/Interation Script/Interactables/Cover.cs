using UnityEngine;
using UnityEngine.AI;

public class Cover : Interactable
{
    protected override void Interact(RaycastHit hitInfo, IClone clone)
    {
        //base.Interact();
        // put the logic here that u need like the movment for the AI stuff
        clone.MoveTo(hitInfo.point);
    }
}
