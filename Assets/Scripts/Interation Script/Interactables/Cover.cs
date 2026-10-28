using UnityEngine;

public class Cover : Interactable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interact()
    {
        //base.Interact();
        // put the logic here that u need like the movment for the AI stuff
        Debug.Log("you called for cover");
    }
}
