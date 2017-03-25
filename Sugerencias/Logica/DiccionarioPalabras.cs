using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sugerencias.Logica
{
    class DiccionarioPalabras
    {
        public List<Palabra> Diccionario { get; }

        public DiccionarioPalabras(string texto, char separador)
        {
            Diccionario = new List<Palabra>();
            string[] palabras = texto.Split(separador);
            foreach(var palabra in palabras)
            {
                var nueva = new Palabra(palabra);
                Diccionario.Add(nueva);
            }
        }
    }
}
