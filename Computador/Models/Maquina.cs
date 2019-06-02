using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Computador.Models
{
    public class Maquina
    {
        public Maquina()
        {
        }

        public Maquina(string id, string chave, int setorId, string marca)
        {
            Id = id;
            Chave = chave;
            SetorId = setorId;
            Marca = marca;
        }

        [Key]
        [Required]
        public string Id { get; set; }

        public string Chave { get; set; }

       
        public int SetorId { get; set; }


        
        [ForeignKey("SetorId")]
        public Setor Setor { get; private set; }

        public string Marca { get; set; }



    }

}
