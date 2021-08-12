using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Obstacles
{
    public class SimpleWall : BaseObstacle
    {
        private void OnCollisionEnter(Collision target)
        {
            if (target.gameObject.CompareTag("Player"))
            {
                //var force = transform.position - target.transform.position;
                //force.Normalize();
                foreach (ContactPoint contact in target.contacts)
                {
                    contact.otherCollider.attachedRigidbody.AddForce(-1 * contact.normal * magnitude, ForceMode.Impulse);
                }

            }
        }
    }
}