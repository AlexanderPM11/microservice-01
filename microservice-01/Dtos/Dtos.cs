using System;
using System.ComponentModel.DataAnnotations;

namespace microservice_01.Dtos
{
    public record ItemDto(
        Guid Id, 
        string Name, 
        string Description, 
        decimal Price, 
        DateTimeOffset CreatedDate
    );

    public record CreateItemDto(
        [Required(ErrorMessage = "El nombre es obligatorio.")] string Name, 
        string Description, 
        [Range(0, 1000, ErrorMessage = "El precio debe estar entre {1} y {2}.")] decimal Price
    );

    public record UpdateItemDto(
        [Required(ErrorMessage = "El nombre es obligatorio.")] string Name, 
        string Description, 
        [Range(0, 1000, ErrorMessage = "El precio debe estar entre {1} y {2}.")] decimal Price
    );
}
