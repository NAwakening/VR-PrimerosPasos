using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] Transform m_playerTransform;
    [SerializeField] NavMeshAgent m_agent;
    [SerializeField] float m_speed;

    private void Start()
    {
        m_agent.speed = m_speed;
    }

    void Update()
    {
        m_agent.SetDestination(m_playerTransform.position);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Weapon"))
        {
            gameObject.SetActive(false);
        }
    }
}
