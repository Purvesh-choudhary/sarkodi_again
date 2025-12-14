using UnityEngine;

public class AnimatorOffset : MonoBehaviour
{
    void Start()
    {
        Animator animator = GetComponent<Animator>();
        animator.Play(0, 0, Random.value);
        animator.speed = Random.Range(0.9f, 1.1f);
    }
}
