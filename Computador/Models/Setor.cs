using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Computador.Models
{
    public class Setor
    {
        public Setor()
        {
        }

        public Setor(int id, string nome, List<Maquina> maquinas)
        {
            Id = id;
            Nome = nome;
            Maquinas = maquinas;
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public List<Maquina> Maquinas { get; set; } = new List<Maquina>();
    }
}
