using System;
using System.ComponentModel.DataAnnotations;

namespace Admin.Api.DTOs;

public class UpdateSkillRequest
{
    public string Name { get; set; } = string.Empty;

    [Range(1, 100)]
    public int Level { get; set; } = 0;

}
