using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrearCodicoPorEstructura
{
    struct campo
    {
   
        public string nombre;
        public string tipo;
        public int tamaño;
    }
    class Estructura
    {


        public string nombreEstructura;
        public List<campo> listaCampos = new List<campo>();
        public void cargarEstructura()
        {
            int fin;
            Console.WriteLine("Ingrese el nombre de la estructura :");
            this.nombreEstructura = Console.ReadLine();
            do
            {
                Console.Write("Ingrese un campo :");
                campo nuevo = new campo();
                nuevo.nombre = Console.ReadLine();
                Console.Write("Ingrese un tipo :");
                nuevo.tipo = Console.ReadLine();
                if(nuevo.tipo == "char")
                {
                    Console.Write("Ingrese un tamaño :");
                    nuevo.tamaño = Convert.ToInt32(Console.ReadLine());
                }
                
                

                listaCampos.Add(nuevo);

                Console.Write("1 = sigue, 0 = fin :");
                fin = Convert.ToInt32(Console.ReadLine());
            } while (fin == 1);
            
        }

        public void harcodear()
        {
            this.nombreEstructura = "Pantalla";
            campo nuevo = new campo();
            nuevo.nombre = "id";
            nuevo.tipo = "int";
            listaCampos.Add(nuevo);
            nuevo.nombre = "nombre";
            nuevo.tipo = "char";
            nuevo.tamaño = 30;
            listaCampos.Add(nuevo);
            nuevo.nombre = "precio";
            nuevo.tipo = "float";
            listaCampos.Add(nuevo);
            nuevo.nombre = "dias";
            nuevo.tipo = "int";
            listaCampos.Add(nuevo);
            nuevo.nombre = "libre";
            nuevo.tipo = "int";
            listaCampos.Add(nuevo);
        }
        public void mostrarEstructura()
        {
            Console.WriteLine("#include <stdio.h> \n" + "#include <stdlib.h> \n" + "#include <string.h> \n" + "#define MAX 3 \n");
            Console.WriteLine("typedef struct {");
            foreach (campo c in listaCampos)
            {
                if(c.tipo == "char")
                {
                    Console.WriteLine("  " + c.tipo + " " + c.nombre + "["+ c.tamaño + "];");
                }
                else
                {
                    Console.WriteLine("  " + c.tipo + " " + c.nombre + ";");
                }
                
            }
            Console.WriteLine("}e" + this.nombreEstructura + ";");
            
        }

    }
}
