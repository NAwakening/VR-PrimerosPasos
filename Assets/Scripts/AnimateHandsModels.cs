using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class AnimateHandsModelOnInput
{
    public string animationProperty;
    public InputActionProperty actionProperty;
}

public class AnimateHandsModels : MonoBehaviour
{
    [SerializeField] List<AnimateHandsModelOnInput> animationInputs;
    [SerializeField] Animator animator; 
    
    // Update is called once per frame
    void Update()
    {
        foreach (AnimateHandsModelOnInput animationInput in animationInputs)
        {
            float actionValue = animationInput.actionProperty.action.ReadValue<float>();
            animator.SetFloat(animationInput.animationProperty, actionValue);
        }
    }
}
