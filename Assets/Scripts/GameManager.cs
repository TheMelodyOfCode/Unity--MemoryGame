using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MemoryCard firstSelectedCard;
    public MemoryCard secondSelectedCard;

    private bool canClick = true;

    public void CardClicked(MemoryCard card)
    {
        if (canClick == false) return;

        card.transform.localEulerAngles = new Vector3(90,0,0);

        if (firstSelectedCard == null)
        {
            firstSelectedCard = card;
        }
        else
        {
            // Second card clicked
            secondSelectedCard = card;
            canClick = false;

            Invoke("CheckMatch", 1);
        }
    }

    public void CheckMatch()
    {
        // Result
        if (firstSelectedCard.identifier == secondSelectedCard.identifier)
        {
            Destroy(firstSelectedCard.gameObject);
            Destroy(secondSelectedCard.gameObject);
        }
        else
        {
            firstSelectedCard.transform.localEulerAngles = new Vector3(-90, 0, 0);
            secondSelectedCard.transform.localEulerAngles = new Vector3(-90, 0, 0);
        }

        // Reset
        firstSelectedCard = null;
        secondSelectedCard = null;

        canClick = true;
    }
}
