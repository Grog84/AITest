﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Navmesh
{
    public class NavMeshTarget : MonoBehaviour
    {

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    //transform.position = hit.transform.position;
                    transform.position = hit.point;
                }
            }
        }
    }
}