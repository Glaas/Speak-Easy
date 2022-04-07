using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChatBubble : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;

    void Awake()
    {
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
    }
    //Uses DOTween to fade in and out the chat bubble
    public void OpenBubble()
    {
        transform.localScale = Vector3.one;
    }
    public void CloseBubble()
    {
        transform.localScale = Vector3.zero;
    }
    //Will assign a new color to the image of the chat bubble
    //Pro-tip: I recommend using the eye dropper in the inspector and clicking on your NPC to pick a color!
    public void AssignBubbleColor(Color color)
    {
        GetComponentInChildren<Image>().color = color;
    }
    public void SetText(string text)
    {
        textMeshPro.text = text;
    }
}


