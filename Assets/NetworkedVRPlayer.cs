using Unity.Netcode;
using UnityEngine;
using UnityEngine.XR;
using Unity.XR.CoreUtils;
using System.Collections.Generic;

public class NetworkedVRPlayer : NetworkBehaviour
{
    [SerializeField]
    private Transform root;
    [SerializeField]
    private Transform head;
    [SerializeField]
    private Transform leftHand;
    [SerializeField]
    private Transform rightHand;

    [SerializeField]
    private Renderer[] meshesToDisable;

    public override void OnNetworkSpawn()
    {
        // Disable meshes that shouldn't be seen in first-person
        DontDestroyOnLoad(gameObject);
        if(IsOwner) {
            foreach(var item in meshesToDisable) {
                item.enabled = false;
            }
        }
    }

    private void Update()
    {
        if (!IsOwner) return;

        var xrOrigin = FindObjectOfType<XROrigin>(); // Locate XR Origin in the scene

        if(xrOrigin == null) {
            Debug.Log("Failed to get the XR Origin");
            return;
        }

        // Make sure root position is synced (just in case)
        root.position = xrOrigin.transform.position;
        root.rotation = xrOrigin.transform.rotation;

        // Track headset movement
        head.position = xrOrigin.Camera.transform.position;
        head.rotation = xrOrigin.Camera.transform.rotation;

        // Find the simulator transforms manually
        leftHand.position = xrOrigin.transform.Find("Camera Offset/Left Controller").position;
        leftHand.rotation = xrOrigin.transform.Find("Camera Offset/Left Controller").rotation;

        rightHand.position = xrOrigin.transform.Find("Camera Offset/Right Controller").position;
        rightHand.rotation = xrOrigin.transform.Find("Camera Offset/Right Controller").rotation;
    }
}
