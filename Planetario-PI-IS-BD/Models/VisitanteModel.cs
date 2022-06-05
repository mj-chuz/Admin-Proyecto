using System;
using System.ComponentModel.DataAnnotations;

namespace Planetario.Models {
  public class VisitanteModel {

    public class FechaFutura : ValidationAttribute {
      public override bool IsValid(object valor) {
        return valor != null && (DateTime)valor < DateTime.Now;
      }
    }

    [Required(ErrorMessage = "Es necesario que ingrese su nombre")]
    [Display(Name = "Nombre*")]
    [RegularExpression("^[a-zA-ZÀ-ÿ ]*$", ErrorMessage = "No se permiten caracteres especiales")]
    public String Nombre { get; set; }

    [Required(ErrorMessage = "Es necesario que ingrese su primer apellido")]
    [Display(Name = "Primer apellido*")]
    [RegularExpression("^[a-zA-ZÀ-ÿ]*$", ErrorMessage = "No se permiten caracteres especiales")]
    public String PrimerApellido { get; set; }

    [Display(Name = "Segundo apellido:")]
    [RegularExpression("^[a-zA-ZÀ-ÿ]*$", ErrorMessage = "No se permiten caracteres especiales")]
    public String SegundoApellido { get; set; }

    [Required(ErrorMessage = "Es necesario que ingrese su nacionalidad")]
    [Display(Name = "Nacionalidad*")]
    public String Pais { get; set; }

    [Required(ErrorMessage = "Es necesario que ingrese su correo")]
    [EmailAddress(ErrorMessage = "Correo inválido")]
    [Display(Name = "Correo*")]
    public String Correo { get; set; }

    [Required(ErrorMessage = "Es necesario que ingrese su número de identificación ")]
    [RegularExpression("^[a-zA-ZÀ-ÿ0-9]*$", ErrorMessage = "No se permiten caracteres especiales")]
    [Display(Name = "Número de identificación*")]
    public String NumeroIdentificacion { get; set; }

    [Required(ErrorMessage = "Es necesario que seleccione su género")]
    [Display(Name = "Género*")]
    public String Genero { get; set; }

    [FechaFutura(ErrorMessage = "La fecha de nacimiento debe ser anterior a la fecha actual")]
    [Required(ErrorMessage = "Es necesario que seleccione su fecha de nacimiento")]
    [Display(Name = "Fecha de nacimiento*")]
    public DateTime FechaDeNacimiento { get; set; }

    [Required(ErrorMessage = "Es necesario que ingrese su nivel educativo")]
    [Display(Name = "Nivel educativo*")]
    public String NivelEducativo { get; set; }

    public String TituloActividadInscrita { get; set; }

    public DateTime FechaActividadInscrita { get; set; }
  }
}