using UnityEngine;
using RPG.Movement;
using System.Net;
namespace RPG.Combat {

    public class Fighter : MonoBehaviour
    {
        [SerializeField] float weaponRange = 2f;

        Transform target;

        private void Update()
        {
            //exits fighting early if there is no target
            if (target == null) return;
            //if target is not null and is not in range, move to target
            if (!GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Mover>().Stop();
            }
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
        }
        public void Cancel()
        {
            target = null;
        }
    }
}

