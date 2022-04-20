using UnityEngine;
using UnityEngine.Events;

public class DialogueContainer : MonoBehaviour
{
    public GameObject prefabUI;
    [HideInInspector]
    public GameObject clone;
    ChatBubble bubble;
    public Color NPC_color = Color.white;
    [HideInInspector]
    public int conversationsIndex = 0;
    [HideInInspector]
    public int linesIndex = 0;

    public Conversation[] conversations;

    private Talk talk;

    public UnityEvent onStartConversation;
    public UnityEvent onNextLine;
    public UnityEvent onEndConversation;

    public void CreateBubble()
    {
        clone = Instantiate(prefabUI, FindObjectOfType<Canvas>().transform);
        bubble = clone.GetComponent<ChatBubble>();
    }

    public void Talk(PlayerStates state)
    {
        switch (state)
        {
            case PlayerStates.Idle:
                CreateBubble();
                talk.playerState = PlayerStates.Talking;
                GoToNextLine(conversationsIndex, linesIndex);
                break;
            case PlayerStates.Talking:
                GoToNextLine(conversationsIndex, linesIndex);
                break;
        }
    }

    void GoToNextLine(int conv_Index, int lines_Index)
    {
        bubble.OpenBubble();

        if (conversationsIndex == 0 && linesIndex == 0) onStartConversation.Invoke();

        if (conversationsIndex < conversations.Length)
        {
            if (linesIndex < conversations[conv_Index].Lines.Count)
            {
                if (conversations[conversationsIndex].talker == Conversation.Talker.NPC)
                {
                    bubble.AssignBubbleColor(NPC_color);
                }
                else
                {
                    bubble.AssignBubbleColor(FindObjectOfType<Talk>().playerChatBubbleColor);
                }
                onNextLine.Invoke();
                bubble.SetText(Formatter(conversations[conversationsIndex].TalkerName, conversations[conv_Index].Lines[linesIndex]));
                this.linesIndex++;
            }
            else
            {
                if (conversationsIndex < conversations.Length - 1)
                {
                    conversationsIndex++;
                }
                EndConversation();
            }
        }
        else
        {
            EndConversation();
        }
    }

    void EndConversation()
    {
        this.linesIndex = 0;
        bubble.CloseBubble();
        talk.EndConversation();
        onEndConversation.Invoke();
        Destroy(clone, 1);
    }

    string Formatter(string NPCName, string content)
    {
        if (NPCName == string.Empty) return content;
        return "<b>" + NPCName + "</b>\n" + content;
    }

    private void Update()
    {
        if (clone != null)
        {
            clone.transform.position = Camera.main.WorldToScreenPoint(transform.position) + new Vector3(0, 80, 0);
        }
    }
    private void Awake()
    {
        talk = FindObjectOfType<Talk>();
    }
}


