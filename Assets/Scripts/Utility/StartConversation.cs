using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*This is a basic helper script Ethan wrote to start scenes without using a trigger volume, which refused to start due to a weird navigation bug. If I was smart I would write this in a way that it would get the scene name then case switch it, but this is crunch and I'm lazy*/
public class StartConversation : MonoBehaviour
{
    public string inkTag;

    private void Start()
    {
        UI.Instance.StartConversation(inkTag);
    }
}