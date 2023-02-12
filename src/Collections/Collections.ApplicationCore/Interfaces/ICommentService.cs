namespace Collections.ApplicationCore.Interfaces;

public interface ICommentService
{
    public Task WriteComment(int itemId, string commentBody);
}