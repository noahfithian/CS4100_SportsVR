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

    public override void OnNetworkSpawn()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (!IsOwner) return;

        var xrOrigin = FindObjectOfType<XROrigin>(); // Locate XR Origin in the scene

        if(xrOrigin == null) {
            Debug.Log("Failed to get the XR Origin");
        }

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
