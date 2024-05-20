using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTiltAnimations : MonoBehaviour
{
  
        public Transform[] Pos;
        public float LateralTiltSpeed;

        public Transform originTransform; 

        private float _timer = 0.0f;

        public int IdPos;

        Vector3 offset;
        private void Start()
        {
            originTransform = transform;
        }

        // Update is called once per frame
        private void Update()
        {
            _timer += Time.deltaTime;
            //LateralTiltSpeed *= Time.deltaTime;
            //transform.position = Vector3.Lerp(transform.position, Pos[IdPos].position, LateralTiltSpeed);
            //if ((transform.rotation.z < Pos[IdPos].rotation.z) || (transform.rotation.z > Pos[IdPos].rotation.z))
                transform.rotation = Quaternion.Slerp(originTransform.rotation, Pos[IdPos].rotation, LateralTiltSpeed*Time.deltaTime);
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
