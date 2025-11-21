using System;

public class Comment
{
    private string _author;
    private string _text;

    public Comment(string author, string text)
    {
        _author = author;
        _text = text;
    }

    public string Author { get { return _author; } }
    public string Text { get { return _text; } }

    public override string ToString()
    {
        return $"{Author}: {Text}";
    }
}
