using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionBehaviour : StateMachineBehaviour
{
   public KeyCode key;
   public string nextTrigger;
   override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
       if (Input.GetKeyDown(key))
       {
           animator.SetTrigger(nextTrigger);
       }
   }
}
