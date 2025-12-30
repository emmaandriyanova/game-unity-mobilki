using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCloud : MonoBehaviour
{
    public Animator[] clouds;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Animator animator in clouds)
            {
                animator.SetTrigger("New Trigger");
            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Animator animator in clouds)
            {
                animator.SetTrigger("New Trigger");
            }
        }
    }
}
