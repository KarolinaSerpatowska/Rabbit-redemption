using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit : StateMachineBehaviour {

    public GameObject player;
    public GameObject swordGamepad;
    public GameObject swordKeyboard;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        player = animator.gameObject;
        if(animator.gameObject.name == "PaladinGamepad")
        {
            Instantiate(swordGamepad, player.transform.position + (player.transform.forward * 3), player.transform.rotation);
        }
        else
        {
            Instantiate(swordKeyboard, player.transform.position + (player.transform.forward * 3), player.transform.rotation);
        }
        
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
