using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{

    [SerializeField] Animator animator;
    [SerializeField] float rollTimer = 2f;

    [SerializeField] Sprite[] diceFace;
    [SerializeField] SpriteRenderer spriteRenderer;
    public int diceValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // // Update is called once per frame
    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         StartCoroutine(Roll());
    //     }
    // }

    public IEnumerator Roll()
    {
        animator.enabled = true;
        yield return new WaitForSeconds(rollTimer);
        animator.enabled = false;
        diceValue = Random.Range(1, 6);
        spriteRenderer.sprite = diceFace[diceValue-1];
    }
}
