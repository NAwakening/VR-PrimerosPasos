using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] Transform m_playerTransform;
    [SerializeField] NavMeshAgent m_agent;
    [SerializeField] float m_speed;
    [SerializeField] Animator m_anim;

    private void Start()
    {
        
    }

    void Update()
    {
        if (m_agent.isActiveAndEnabled)
        {
            m_agent.SetDestination(m_playerTransform.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Weapon"))
        {
            m_agent.enabled = false;
            m_anim.enabled = false;
            StartCoroutine(DeactivateEnemy());
        }
    }

    public void StartEnemy()
    {
        m_agent.enabled = true;
        m_anim.enabled = true;
        m_agent.speed = m_speed;
    }

    IEnumerator DeactivateEnemy()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("Im disapearing" + gameObject.name);
        gameObject.SetActive(false);
    }
}
