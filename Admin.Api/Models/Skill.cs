using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Admin.Api.Models;

public class Skill
{
public Guid Id { get; set; }

[Required]
public string Name { get; set; }=string.Empty;

[Required]
[Range(0,100)]
public decimal Level { get; set; }=0;

[Required]
public DateTimeOffset CreateAt { get; set; }

}
