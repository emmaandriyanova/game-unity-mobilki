using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestWall : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player" && other.GetComponent<Pickup>().id == 2)
        {
            Destroy(other.gameObject);
            animator.SetTrigger("isTriggered");
        }
    }
}
