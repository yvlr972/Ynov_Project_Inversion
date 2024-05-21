using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTiltAnimations : MonoBehaviour
{
  
        public Transform[] Pos;
        public float LateralTiltSpeed;

        public Transform originTransform; 

        private float _timer = 0.0f;

        public int IdPos = 0;

        Vector3 offset;
        private void Start()
        {
            //originTransform.rotation = transform.rotation;
        }

        // Update is called once per frame
        private void Update()
        {
            _timer += Time.deltaTime;
        //LateralTiltSpeed *= Time.deltaTime;
        //transform.position = Vector3.Lerp(transform.position, Pos[IdPos].position, LateralTiltSpeed);
        //if ((transform.rotation.z < Pos[IdPos].rotation.z) || (transform.rotation.z > Pos[IdPos].rotation.z))
        //transform.rotation = Quaternion.Lerp(originTransform.rotation, Pos[IdPos].rotation, LateralTiltSpeed);

            transform.rotation = transform.rotation * Quaternion.AngleAxis(Pos[IdPos].rotation.z * Time.deltaTime * LateralTiltSpeed, Vector3.forward);
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
