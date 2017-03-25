using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sugerencias.Logica
{
    class Palabra
    {
        public string Contenido { get; set; }
        public bool EsArticulo { get; set; }
        public int CantidadLetras { get; }

        public  Palabra(string contenido)
        {
            this.Contenido = contenido;
            this.CantidadLetras = contenido.Length;
            bool articulo = Articulo().Result;
            EsArticulo = articulo;
        }

        private async Task<bool> Articulo()
        {
            string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),"Utiles","conectores.txt");
            if (File.Exists(ruta)){
                using(var archivo = new StreamReader(ruta))
                {
                    string linea;
                    while((linea =  await archivo.ReadLineAsync())!=null){
                        if (linea.Equals(this.Contenido))
                            return true;
                    }
                }
            }
            else
            {
                throw new FileNotFoundException("No hay un archivo con conectores",ruta);
            }
            return false;
        }

    }
}
