using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour
{

    [SerializeField] Animator animator;
    [SerializeField] float rollTimer = 2f;

    [SerializeField] Sprite[] diceFace;
    [SerializeField] SpriteRenderer spriteRenderer;
    public int diceValue = 0;

    [Header("Dice Chances (Total should be 100)")]
    [SerializeField] int chance1 = 25;
    [SerializeField] int chance2 = 25;
    [SerializeField] int chance3 = 25;
    [SerializeField] int chance4 = 20;
    [SerializeField] int chance8 = 5;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public IEnumerator Roll()
    {
        animator.enabled = true;
        AudioManager.Instance.DiceRoll();
        yield return new WaitForSeconds(rollTimer);
        animator.enabled = false;

        diceValue = GetSpecialDiceValue();
        spriteRenderer.sprite = diceFace[GetSpriteIndex(diceValue)];
    }

    int GetSpecialDiceValue()
    {
        int totalChance = chance1 + chance2 + chance3 + chance4 + chance8;
        int roll = Random.Range(0, totalChance);

        if (roll < chance1) 
            return 1;
        roll -= chance1;
    
        if (roll < chance2) 
            return 2;
        roll -= chance2;
        
        if (roll < chance3) 
            return 3;
        roll -= chance3;
        
        if (roll < chance4) 
            return 4;
        
        return 8;
    }


    int GetSpriteIndex(int value)
    {
        switch (value)
        {
            case 1: return 0;
            case 2: return 1;
            case 3: return 2;
            case 4: return 3;
            case 8: return 4;
            default: return 0;
        }
    }

    void OnMouseDown()
    {
        if(MatchManager.Instance.canRoll)
        {
            Debug.Log("Clicked On Dice !");
            MatchManager.Instance.PlayGame();
        }
    }



}
