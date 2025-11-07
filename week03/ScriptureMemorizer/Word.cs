using System;

public class Word
{
    private string _text;
    private bool _hidden;

    public Word(string text)
    {
        _text = text;
        _hidden = false;
    }

    // Returns whether this word is currently hidden
    public bool IsHidden { get { return _hidden; } }

    // Hide the word
    public void Hide()
    {
        _hidden = true;
    }

    // Display the word: if hidden, replace letters with underscores but keep punctuation
    public string Display()
    {
        if (!_hidden) return _text;

        char[] chars = _text.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            if (char.IsLetter(chars[i]))
            {
                chars[i] = '_';
            }
        }
        return new string(chars);
    }

    // Original text (for tests or saving)
    public string Text { get { return _text; } }
}
