using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClienteDotNet.Models.DTO
{
    public class Lembrete
    {
        public int Id { get; set; }

        [Display(Name = "Título")]
        public string Title { get; set; }

        [Display(Name ="Mensagem")]
        public string Body { get; set; }
    }
}