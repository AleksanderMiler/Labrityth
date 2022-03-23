using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Camera myCamera;
    public GameObject player;
    public Transform myRenderPlane;
    public Transform myColliderPlane;
    public Portal otherportal;
    PortalCamera portalCamera;
    PortalTeleporter portalTeleporter;
    public Material material;
    float myAngle;


    private void Awake()
    {
        portalCamera.playerCamera = player.gameObject.transform.GetChild(0);
        portalTeleporter = myColliderPlane.gameObject.GetComponent<PortalTeleporter>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
