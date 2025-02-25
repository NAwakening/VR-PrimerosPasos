using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VRMap
{
    public Transform VRTarget;
    public Transform IKTarget;
    public Vector3 positionOffset;
    public Vector3 rotationOffset;

    public void Map()
    {
        IKTarget.position = VRTarget.TransformPoint(positionOffset);
        IKTarget.rotation = VRTarget.rotation * Quaternion.Euler(rotationOffset);
    }
}

public class IKAttachTargetWithOrigin : MonoBehaviour
{
    [SerializeField] float turnSmooth;
    [SerializeField] VRMap head;
    [SerializeField] VRMap leftHand;
    [SerializeField] VRMap rightHand;

    [SerializeField] Vector3 headOffset;
    [SerializeField] float bodyOffset;

    // Update is called once per frame
    void Update()
    {
        transform.position = head.IKTarget.position + headOffset;
        float temp_rotationY = head.VRTarget.eulerAngles.y;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.eulerAngles.x, temp_rotationY, transform.eulerAngles.z), turnSmooth);
        head.Map();
        leftHand.Map();
        rightHand.Map();
    }
}
