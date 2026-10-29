using System.Collections.Generic;
using PlasticGui.WebApi.Responses;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private new LayerMask mask;

    [SerializeField] private float distance = 3;
    
    List<IClone> clones = new List<IClone>(); // list to hold the clone objects that you will be 
    [SerializeField] private int cursor = 0;
    
    private PlayerUI playerUI;
    private InputManager inputManager;
    
    private IClone selected;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
        
        // make a function to get all clones by types on your team and it should put them in a list.

        selected = FindFirstObjectByType<CloneSniper>();
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
                    interactable.BaseInteract(hitInfo, selected);
                }
            }
        }
    }
    
    public void SelectClone()
    {
        if (clones.Count == 0) throw new MissingComponentException("No clone found");
        
        selected = clones[cursor];
        
        cursor++;
        if (clones.Count > cursor) // if the cursor position is the same as the size then go to the front of the list
        {
            cursor = 0;
        } 
        
    }
}
