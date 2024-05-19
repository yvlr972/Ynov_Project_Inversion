using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTiltAnimations : MonoBehaviour
{
  
        public Transform[] Pos;
        public float LateralTiltSpeed;

        private float _timer = 0.0f;

        public int IdPos;

        Vector3 offset;
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
            _timer += Time.deltaTime;
            //transform.position = Vector3.Lerp(transform.position, Pos[IdPos].position, LateralTiltSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, Pos[IdPos].rotation, LateralTiltSpeed);
        }

        public void setNormal()
        {
            IdPos = 0;
        }

        public void setTiltLeft()
        {
            IdPos = 1;
        }

        public void setTiltRight()
        {
            IdPos = 2;
        }
 

}
