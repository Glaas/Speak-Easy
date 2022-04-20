using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

using System;

[CreateAssetMenu(fileName = "_Conversation", menuName = "SpeakEasy/Conversation", order = 1)]
public class Conversation : ScriptableObject
{
    public enum Talker
    {
        Player,
        NPC
    }
    public Talker talker;
    public string TalkerName;
    public List<string> lines;
}