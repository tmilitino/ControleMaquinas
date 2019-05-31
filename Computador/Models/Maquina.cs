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

        public Maquina(string id, string chave, Setor setor, string marca)
        {
            Id = id;
            Chave = chave;
            Setor = setor;
            Marca = marca;
        }

        public string Id { get; set; }

        public string Chave { get; set; }

        [Required]
        public int SetorId { get; set; }


        [Required]
        [ForeignKey("SetorId")]
        public Setor Setor { get; private set; } = new Setor();

        public string Marca { get; set; }



    }

}
