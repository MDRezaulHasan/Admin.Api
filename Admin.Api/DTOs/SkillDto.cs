using System;
using System.ComponentModel.DataAnnotations;

namespace Admin.Api.DTOs;

public class SkillDto
{
    [Required(ErrorMessage = "Skill name is required.")]
    [StringLength(20)]
    public string Name { get; set; }=string.Empty;
    
    [Required(ErrorMessage = "Skill level is required.")]
    [Range(1,100)]
    public decimal Level { get; set; }=0;
}
