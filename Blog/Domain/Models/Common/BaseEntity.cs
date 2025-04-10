namespace Blog.api.Domain.Models.Common;

public abstract class BaseEntity<TId> where TId : notnull
{
    public TId? Id { get; set; }
}

public abstract class BaseEntity : BaseEntity<int>;