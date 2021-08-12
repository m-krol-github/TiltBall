using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

namespace Pickup
{
    public class SimpleWatch : BasePickup
    {
        [Header("PickEffect"), SerializeField]
        private ParticleSystem pickEffect;

        public override void InitPickup(ClassManager classManager)
        {
            base.InitPickup(classManager);
            this.pickupType = 1;
        }

        protected override void Update()
        {
            base.Update();
        }
    }
}