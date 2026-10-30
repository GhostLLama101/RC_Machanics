using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private new LayerMask mask;
    [SerializeField] private float distance = 3;
    
    //List<IClone> clones = new List<IClone>(); 
    [SerializeField] private int cursor = 0;
    [SerializeField] private List<BaseClone> cloneObjects; // list to hold the clone objects that you will be 
    
    private PlayerUI playerUI;
    private InputManager inputManager;
    private BaseClone selected;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.updateText(string.Empty);
        // create a ray at the center of the camera
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo; // var to store are hit information
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.updateText(interactable.promptMessage);
                if (inputManager.onfoot.Interact.triggered)
                {
                    SelectClone();
                    interactable.BaseInteract(hitInfo, selected);
                }
            }
        }
    }
    
    public void SelectClone()
    {
        if (cloneObjects.Count == 0) throw new MissingComponentException("No clone found");
        
        selected = cloneObjects[cursor];
        
        cursor++;
        if (cursor >= cloneObjects.Count) // if the cursor position is the same as the size then go to the front of the list
        {
            cursor = 0;
        } 
    }
}
