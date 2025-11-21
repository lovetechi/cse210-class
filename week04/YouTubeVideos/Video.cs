using System;
using System.Collections.Generic;

public class Video
{
    private string _title;
    private string _author;
    private int _lengthSeconds;
    private List<Comment> _comments;

    public Video(string title, string author, int lengthSeconds)
    {
        _title = title;
        _author = author;
        _lengthSeconds = lengthSeconds;
        _comments = new List<Comment>();
    }

    public string Title { get { return _title; } }
    public string Author { get { return _author; } }
    public int LengthSeconds { get { return _lengthSeconds; } }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    public IEnumerable<Comment> GetComments()
    {
        return _comments;
    }

    public override string ToString()
    {
        TimeSpan t = TimeSpan.FromSeconds(_lengthSeconds);
        string length = string.Format("{0}:{1:D2}", (int)t.TotalMinutes, t.Seconds);
        return $"Title: {_title}\nAuthor: {_author}\nLength: {length}\nComments: {GetNumberOfComments()}";
    }
}
