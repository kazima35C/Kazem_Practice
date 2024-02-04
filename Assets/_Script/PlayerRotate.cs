using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{

    public class PlayerRotate : MonoBehaviour
    {
        [SerializeField] private Transform mesh;
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private bool staticYRotate = true;
        private Vector3 worldPosition=Vector3.one;
        private readonly int maxDistanceRay = 100;
        public void UpdateRotate()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitData, maxDistanceRay, layerMask))
            {
                worldPosition = new Vector3(hitData.point.x, staticYRotate ? mesh.transform.position.y : hitData.point.y, hitData.point.z);
            }
            mesh.LookAt(worldPosition);
        }

    }
}
