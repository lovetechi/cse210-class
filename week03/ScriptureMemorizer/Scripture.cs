using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private ScriptureReference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    // Create a Scripture from a reference and the scripture text
    public Scripture(ScriptureReference reference, string text)
    {
        _reference = reference;
        // Split on spaces to keep punctuation attached to words
        _words = text.Split(' ').Select(t => new Word(t)).ToList();
    }

    // Return a display string including the reference and the text (with hidden words masked)
    public string GetDisplayText()
    {
        var displayWords = _words.Select(w => w.Display());
        return $"{_reference}\n{string.Join(" ", displayWords)}";
    }

    // Hide up to 'count' words. Picks randomly from the words that are not yet hidden.
    public void HideRandomWords(int count)
    {
        var remaining = _words.Where(w => !w.IsHidden).ToList();
        if (remaining.Count == 0) return;

        int toHide = Math.Min(count, remaining.Count);
        for (int i = 0; i < toHide; i++)
        {
            int idx = _random.Next(remaining.Count);
            remaining[idx].Hide();
            remaining.RemoveAt(idx);
        }
    }

    // True when all words are hidden
    public bool AllHidden()
    {
        return _words.All(w => w.IsHidden);
    }

    // Count of visible words
    public int VisibleCount()
    {
        return _words.Count(w => !w.IsHidden);
    }
}
