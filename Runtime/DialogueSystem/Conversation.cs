using System.Collections.Generic;
using System;

[Serializable]
public struct Conversation
{
    public bool isPlayerTalking;
    public string TalkerName;
    public List<string> Lines;
}
