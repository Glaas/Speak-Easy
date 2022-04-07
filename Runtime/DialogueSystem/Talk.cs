using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Talk : MonoBehaviour
{

    [HideInInspector]
    public PlayerStates playerState = PlayerStates.Idle;
    [HideInInspector]
    public List<GameObject> talkers;
    public Color playerChatBubbleColor = Color.white;
    [HideInInspector]
    public GameObject target;

    public float maxDistance = 5f;

    public KeyCode talkKey = KeyCode.E;

    private void Update()
    {
        talkers = new List<GameObject>(GameObject.FindGameObjectsWithTag("NPC"));
        if (talkers.Count > 0)
        {
            target = talkers.OrderBy(x => Vector3.Distance(x.transform.position, transform.position)).First().gameObject;
        }

        if (Input.GetKeyDown(talkKey) && target != null && Vector3.Distance(target.transform.position, transform.position) < maxDistance)
        {
            TalkToNPC();
        }
    }
    void TalkToNPC()
    {
        target.GetComponent<DialogueContainer>().Talk(playerState);
    }
    public void EndConversation()
    {
        playerState = PlayerStates.Idle;
    }
}
public enum PlayerStates
{
    Idle,
    Talking,
}