using UnityEngine;

namespace RPG.Core
{
    public class ActionScheduler : MonoBehaviour
    {
        IAction currentAction;
        public void StartAction(IAction action)
        {
            if (currentAction == null) return;
            if(currentAction != null)
            {
                print($"Cancelling {action}...");
                currentAction.Cancel();
            }
            currentAction = action;

        }
    }
}