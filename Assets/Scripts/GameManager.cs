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

        // Always rotate card up to show its image
        card.targetRotation = 90;
        card.targetHeight = 0.05f;

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
            firstSelectedCard.targetRotation = -90;
            secondSelectedCard.targetRotation = -90;

            firstSelectedCard.targetHeight = 0.01f;
            secondSelectedCard.targetHeight = 0.01f;

        }

        // Reset
        firstSelectedCard = null;
        secondSelectedCard = null;

        canClick = true;
    }
}
