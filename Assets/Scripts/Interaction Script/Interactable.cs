using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string promptMessage;

    public void BaseInteract(RaycastHit hitInfo, BaseClone baseClone)
    {
        Interact(hitInfo, baseClone);
    }
    protected virtual void Interact(RaycastHit hitInfo, BaseClone baseClone)
    {
        Debug.Log("Interacted with" + promptMessage);
    }
}
