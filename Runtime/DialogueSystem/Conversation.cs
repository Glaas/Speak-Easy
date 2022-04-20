using System.Collections.Generic;
using System;

[Serializable]
public struct Conversation
{
    public enum Talker
    {
        Player,
        NPC
    }
    public Talker talker;
    public string TalkerName;
    public List<string> Lines;
}
