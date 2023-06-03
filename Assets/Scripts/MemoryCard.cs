using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour
{
    public int identifier;

    public void OnMouseDown()
    {
        FindObjectOfType<GameManager>().CardClicked(this);
    }
}
