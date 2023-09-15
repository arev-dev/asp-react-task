using System;
using System.Collections.Generic;

namespace ReactProject.models;

public partial class Task
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? TypeTask { get; set; }
}
