using System;
using System.Collections.Generic;

class PromptGenerator
{
    private List<string> _prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "What was a challenge I faced today and how did I respond?",
        "What am I grateful for today?",
        "If I had one thing I could do over today, what would it be?",
        "What made me smile today?",
        "What did I learn today?"
    };

    private Random _random = new Random();

    public string GetRandomPrompt()
    {
        int idx = _random.Next(0, _prompts.Count);
        return _prompts[idx];
    }
}
