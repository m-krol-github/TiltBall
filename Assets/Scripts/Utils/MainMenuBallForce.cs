using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Utils
{
    public class MainMenuBallForce : MonoBehaviour
    {
        public Vector3 direction;
        public float force;

        [SerializeField]
        private Rigidbody rb;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        private void Update()
        {
            var move = direction * force * Time.deltaTime;

            rb.AddForce(move);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Wall")
            {
                direction = -direction;
            }
        }
    }
}