using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dal.Model; 

namespace Dal.Model{

    public class Computador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id   {get; set;}
    
        [Required]
        [Display(Name = "nome invalido")]
        [Range(1,20)]
        public string Nome  {get; set;}

        [Required]
        [Display(Name = "descrição invalida")]
        [Range(1,20)]
        public string descricao  {get; set;}

        [Required]
        [Display(Name = "preço invalido")]
        [Range(1,20)]
        public float preco  {get; set;}

    }
}        