﻿using FragranceRecommendation.Common.ValidationAttributes;

namespace FragranceRecommendation.DTOs.FragranceDTOs;

public class AddFragranceDto
{
    [Required]
    [StringLength(30, MinimumLength = 3)]
    public string? Name { get; set; }

    [Required]
    [Gender]
    public char Gender { get; set; }

    [Required]
    [BatchYear]
    public int? BatchYear { get; set; }
}