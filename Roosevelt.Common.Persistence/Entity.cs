using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Roosevelt.Common.Persistence;

public abstract class Entity<TKey> : IEntity<TKey>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public TKey Id { get; set; }

    object IEntity.Id
    {
        get => Id;
        set => Id = value is TKey key ? key : throw new InvalidOperationException();
    }
}