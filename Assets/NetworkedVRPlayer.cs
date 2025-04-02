using Unity.Netcode;
using UnityEngine;
using UnityEngine.XR;
using Unity.XR.CoreUtils;
using System.Collections.Generic;

public class NetworkedVRPlayer : NetworkBehaviour
{
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;

    private XROrigin xrOrigin;

    public override void OnNetworkSpawn()
    {
        if (IsOwner) // Only the local player should control their own movement
        {
            xrOrigin = FindObjectOfType<XROrigin>(); // Locate XR Origin in the scene
        }
    }

    private void Update()
    {
        if (!IsOwner || xrOrigin == null) return;

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
