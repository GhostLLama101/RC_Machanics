using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string promptMessage;

    public void BaseInteract(RaycastHit hitInfo, IClone clone)
    {
        Interact(hitInfo, clone);
    }
    protected virtual void Interact(RaycastHit hitInfo, IClone clone)
    {
        Debug.Log("Interacted with" + promptMessage);
    }
}
