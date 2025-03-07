using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] Transform m_playerTransform;
    [SerializeField] NavMeshAgent m_agent;

    private void Start()
    {
        
    }

    void Update()
    {
        m_agent.Move(m_playerTransform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Weapon"))
        {
            gameObject.SetActive(false);
        }
    }
}
