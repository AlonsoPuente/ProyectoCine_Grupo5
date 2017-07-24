//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoreCine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Persona
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Persona()
        {
            this.Ticket = new HashSet<Ticket>();
        }
    
        public int CodPersona { get; set; }
        [Required]
        [Display(Name = "Apellido paterno de la persona")]
        public string Paterno { get; set; }
        [Required]
        [Display(Name = "Apellido materno de la persona")]
        public string Materno { get; set; }
        [Required]
        [Display(Name = "Nombres de la persona")]
        public string Nombres { get; set; }
        [Required]
        [Display(Name = "Dirección de la persona")]
        public string Direccion { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name ="Dirección de correo")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
        [Required]
        [MaxLength(8)]
        [Display(Name = "Número de documento (DNI)")]
        public Nullable<int> NroDocumento { get; set; }
        [Display(Name = "Foto de la persona")]
        public string foto { get; set; }
        [Display(Name = "Archivos del documento")]
        public string doc { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
