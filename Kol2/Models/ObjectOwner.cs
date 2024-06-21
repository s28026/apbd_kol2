﻿using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kol2.Models;

[Table("Object_Owner")]
[PrimaryKey(nameof(ObjectId), nameof(OwnerId))]
public class ObjectOwner
{
    public int ObjectId { get; set; }
    
    public int OwnerId { get; set; }

    [ForeignKey(nameof(ObjectId))] public Object Object { get; set; } = null!;
}