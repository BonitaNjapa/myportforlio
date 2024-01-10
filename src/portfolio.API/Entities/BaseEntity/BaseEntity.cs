using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace portfolio.API.Entities.BaseEntity;

// public class BaseEntity<T>
// {
//     public T Id { get; set; }

//     protected BaseEntity(T id)
//     {
//         Id = id;
//         CreatedAt = DateTime.UtcNow;
//         IsDeleted = false;
//     }
//     public DateTime CreatedAt { get; set; }
//     public DateTime UpdatedAt { get; set; }
//     public bool IsDeleted { get; set; }
// }

public abstract class BaseEntityClass
{
    public Guid Id { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
    public bool IsDeleted { get; init; }
}