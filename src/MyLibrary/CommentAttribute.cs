using System;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class CommentAttribute : Attribute
{
    public string Comment { get; }
    
    public CommentAttribute(string comment)
    {
        Comment = comment;
    }
}
