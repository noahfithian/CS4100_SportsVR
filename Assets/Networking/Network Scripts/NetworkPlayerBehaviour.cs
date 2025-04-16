using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class NetworkPlayerBehaviour : NetworkBehaviour
{
    public Transform root, head, leftHand, rightHand;

    public Renderer[] meshToDisable;
    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            foreach (var item in meshToDisable)
            {
                item.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOwner) 
        { 
            root.position = VRRigReferences.instance.root.position;
            root.rotation = VRRigReferences.instance.root.rotation;

            head.position = VRRigReferences.instance.head.position;
            head.rotation = VRRigReferences.instance.head.rotation;

            leftHand.position = VRRigReferences.instance.leftHand.position;
            leftHand.rotation = VRRigReferences.instance.leftHand.rotation;

            rightHand.position = VRRigReferences.instance.rightHand.position;
            rightHand.rotation = VRRigReferences.instance.rightHand.rotation;
        }
    }
}
