using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRRigReferences : MonoBehaviour
{
    public static VRRigReferences instance;
    public Transform root, head, leftHand, rightHand;

    private void Awake() => instance = this;

}
