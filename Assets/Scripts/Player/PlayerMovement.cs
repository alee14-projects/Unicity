/*******************************************************************************
*
*    Unicity (Project SimLife): A Sims clone written in Unity C#
*    Copyright (C) 2019 Unicity Development Team
*
*    This software is protected by the copyright and licensing rights held
*    by the Unicity Development Team. (2019)
*
*********************************************************************************/
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent> ();
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButtonDown(0))
       {
           RaycastHit hit;
           Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
           if(Physics.Raycast(ray, out hit, Mathf.Infinity))
           {
               agent.SetDestination(hit.point);
           }
       }
    }
}
