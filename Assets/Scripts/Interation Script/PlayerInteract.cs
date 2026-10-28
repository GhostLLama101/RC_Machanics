using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private new LayerMask mask;

    [SerializeField] private float distance = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo; // var to store are hit information
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Debug.Log(hitInfo.collider.GetComponent<Interactable>().promptMessage);
            }
        }
    }
}
