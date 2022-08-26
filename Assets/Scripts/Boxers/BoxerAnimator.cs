using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxerAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void RightHandPunch() =>
        animator.SetTrigger("RightPunch");

    public void LeftHandPunch() =>
        animator.SetTrigger("LeftPunch");

    public void TakeHit() =>
        animator.SetTrigger("TakeHit");

    public void Knockdown() =>
       animator.SetTrigger("Knockdown");

    public void Getup() =>
        animator.SetTrigger("Getup");


}
