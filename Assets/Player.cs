using Unity.Netcode;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem.XR;

public class NetworkedVRPlayer : NetworkBehaviour
{
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;

    private void Start()
    {
        if (!IsOwner) return;

        // Attach the XR Camera and controllers to track the local player
        Camera mainCamera = Camera.main;
        if (mainCamera != null) 
            head = mainCamera.transform;
    }

    private void Update()
    {
        if (!IsOwner) return;

        // Get VR positions from Unity's XR system
        head.position = InputTracking.GetLocalPosition(XRNode.Head);
        head.rotation = InputTracking.GetLocalRotation(XRNode.Head);

        leftHand.position = InputTracking.GetLocalPosition(XRNode.LeftHand);
        leftHand.rotation = InputTracking.GetLocalRotation(XRNode.LeftHand);

        rightHand.position = InputTracking.GetLocalPosition(XRNode.RightHand);
        rightHand.rotation = InputTracking.GetLocalRotation(XRNode.RightHand);
    }
}
