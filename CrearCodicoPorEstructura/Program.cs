using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrearCodicoPorEstructura
{
    class Program
    {
        static void Main(string[] args)
        {
            Estructura estr = new Estructura();

            estr.cargarEstructura();
            //estr.harcodear();
            Console.Clear();
            estr.mostrarEstructura();
            cabeceras(estr);
            principal(estr);
            harcodeo(estr);
            prepararVector(estr);
            buscarlibre(estr);
            mostrarCampos(estr);
            mostrarUnElemento(estr);
            cantidadDeElementosCargados(estr);
            mostrarElementosCargados(estr);
            proximoId(estr);
            buscarEntePorId(estr);
            Alta(estr);
            Baja(estr);
            Modifica(estr);
            Menu(estr);

            Console.ReadLine();
        }

        public static void principal(Estructura e)
        {
            Console.WriteLine("\n\nint main(void)");
            Console.WriteLine("{");
            Console.WriteLine("  setbuf(stdout, NULL);");
            string listaIni = "e" + e.nombreEstructura + " listaDe" + e.nombreEstructura + "s[MAX];";
            string lista =  " listaDe" + e.nombreEstructura + "s";
            Console.WriteLine("  " + listaIni );
            Console.WriteLine(@"    prepararVector" + e.nombreEstructura + "( " + lista + ", MAX);");
            Console.WriteLine(@"    //harcodear" + e.nombreEstructura + "( " + lista + " );");
            Console.WriteLine(@"    //mostrar" + e.nombreEstructura + "Cargados( " + lista + ", MAX, \"Listado\");");
            Console.WriteLine(@"   menu" + e.nombreEstructura + "(" + lista +", MAX);");
            Console.WriteLine("}\n");
            Console.WriteLine("\n");
        }

        public static void cabeceras(Estructura e)
        {
            Console.Write("\nvoid harcodear" + e.nombreEstructura + "(e" + e.nombreEstructura + " lista[]);");
            Console.Write("\nvoid prepararVector" + e.nombreEstructura + "( e" + e.nombreEstructura + " lista[], int cantidad);");
            Console.Write("\nint buscarLibre" + e.nombreEstructura + "( e" + e.nombreEstructura + " lista[], int cantidad);");
            Console.Write("\nvoid mostrarCampos" + e.nombreEstructura + "();");
            Console.Write("\nvoid mostrarUn" + e.nombreEstructura + "( e" + e.nombreEstructura + " elemento);");
            Console.Write("\nint cantidadDe" + e.nombreEstructura + "Cargados( e" + e.nombreEstructura + " lista[] , int cantidad);");
            Console.Write("\nint mostrar" + e.nombreEstructura + "Cargados( e" + e.nombreEstructura + " lista[] , int cantidad, char mensaje[]);");
            Console.Write("\nint proximoID" + e.nombreEstructura + "( e" + e.nombreEstructura + " lista[] , int cantidad);");
            Console.Write("\n\nint buscar" + e.nombreEstructura + "PorID( e" + e.nombreEstructura + " lista[] , int cantidad , int id );");
            Console.Write("\n\nint alta" + e.nombreEstructura + "( e" + e.nombreEstructura + " lista[] , int cantidad  );");
            Console.Write("\nint baja" + e.nombreEstructura + "( e" + e.nombreEstructura + " lista[] , int cantidad  );");
            Console.Write("\nint modifica" + e.nombreEstructura + "( e" + e.nombreEstructura + " lista[] , int cantidad  );");
            Console.Write("\nvoid menu" + e.nombreEstructura + "(e" + e.nombreEstructura + " lista[] , int cantidad);             ");
            Console.WriteLine("\n");
        }



        public static void harcodeo(Estructura e)
        {
            Console.WriteLine("\nvoid harcodear" + e.nombreEstructura + "(e"+ e.nombreEstructura + " lista[])\n{\n");
            int i;
            campo c;
            for(i = 0; i<e.listaCampos.Count - 1; i++)
            {
                c = e.listaCampos[i];
                switch(c.tipo)
                {
                    case "int":
                        Console.Write("  int " + c.nombre + "s[3] = {10,11,12};\n");
                        break;
                    case "float":
                        Console.Write("  float " + c.nombre + "s[3] = {10.2,11.7,12.6};\n");
                        break;
                    case "char":
                        Console.Write("   char " + c.nombre + "s[3]["+c.tamaño.ToString() + "] = {\"alfa\",\"beta\",\"gamma\"};\n");
                        break;

                }
            }
            
            campo d = e.listaCampos[i];
            Console.Write("  int " + d.nombre + "s[3] = {0,0,0};\n");

            Console.Write("\nfor(int i = 0; i < 3; i++) \n{\n");
            foreach (campo f in e.listaCampos)
            {
                switch (f.tipo)
                {
                    case "int":
                    case "float":
                        Console.Write("   lista[i]." + f.nombre + " = " + f.nombre + "s[i];\n");
                        break;

                    case "char":
                        Console.Write("   strcpy(lista[i]." + f.nombre + " , " + f.nombre + "s[i]);\n");
                        break;

                }

            }
            Console.Write("\n  }\n}");
            Console.WriteLine("\n");

        }

        public static void  prepararVector(Estructura e)
        {
            Console.Write("\nvoid prepararVector" + e.nombreEstructura + "( e" + e.nombreEstructura + " lista[], int cantidad)\n{\n");
            Console.Write("\n   for(int i = 0; i<cantidad; i++)\n   {\n");
            Console.Write("\n         lista[i]."+(e.listaCampos[e.listaCampos.Count -1]).nombre +" = 1;\n    }\n}");
            Console.WriteLine("\n");
        }

        public static void buscarlibre(Estructura e)
        {
            Console.Write("\nint buscarLibre" + e.nombreEstructura + "( e" + e.nombreEstructura + " lista[], int cantidad)\n{\n");
            Console.Write("\nint respuesta = -1;\n");
            Console.Write("\nif(lista != NULL && cantidad > 0)\n{\n");
            Console.Write("\n   for(int i = 0; i<cantidad; i++)\n   {\n");
            
            Console.Write("\n       if(lista[i]." + (e.listaCampos[e.listaCampos.Count - 1]).nombre + " == 1)\n       {\n");
            Console.Write("\n         respuesta = i;\n          break;\n      } \n    } \n }\n");
            Console.Write("\n return respuesta; \n}");
            Console.WriteLine("\n");
        }

        public static void mostrarCampos(Estructura e)
        {
            Console.Write("\n\nvoid mostrarCampos" + e.nombreEstructura + "()\n{\n");
            string cadena = "     printf(\"";
            int tam = 0;
            int limite = e.listaCampos.Count - 1;
            for (int i = 0; i < limite;  i++)
            {
                campo c = e.listaCampos[i];
                if(c.tipo != "char")
                {
                    tam = c.nombre.Length;
                }
                else
                {
                    tam = c.tamaño;
                }
                 cadena += "| %" + tam.ToString() + "s ";
            
            }
            
            cadena += " |" + @" \n" +"\",";
            for (int i = 0; i < limite; i++)
            {
                campo c = e.listaCampos[i];
                cadena += "\"" + c.nombre.ToUpper() + "\"";
                if(i < limite - 1)
                {
                    cadena += ",";
                }

            }
            cadena += " );\n";
            Console.Write(cadena);
            Console.Write("}\n");
            Console.WriteLine("\n");
        }


        public static void mostrarUnElemento(Estructura e)
        {
            Console.Write("\n\nvoid mostrarUn" + e.nombreEstructura + "( e" + e.nombreEstructura + " elemento)\n{\n");
            string cadena = "     printf(\"";
            int tam = 0;
            string mascara = "";
            int limite = e.listaCampos.Count - 1;
            for (int i = 0; i < limite; i++)
            {
                campo c = e.listaCampos[i];
                if (c.tipo != "char")
                {
                    tam = c.nombre.Length;
                }
                else
                {
                    tam = c.tamaño;
                }
                switch(c.tipo)
                {
                    case "int":
                        mascara = "d";
                        break;
                    case "float":
                        mascara = ".2f";
                        break;
                    case "char":
                        mascara = "s";
                        break;
                }
                cadena += "| %" + tam.ToString() + mascara +" ";

            }
            cadena += " | " + @" \n" + "\",";
            for (int i = 0; i < limite; i++)
            {
                campo c = e.listaCampos[i];
                cadena += "elemento." + c.nombre;
                if (i < limite -1 )
                {
                    cadena += ",";
                }
            }
            cadena += " );\n";
            Console.Write(cadena);
            Console.Write("}\n");
            Console.WriteLine("\n");
        }



        public static void cantidadDeElementosCargados(Estructura e)
        {
            Console.Write("\n\nint cantidadDe" + e.nombreEstructura + "Cargados( e" + e.nombreEstructura + " lista[] , int cantidad)\n{\n");

            Console.Write("\nint respuesta = 0;\n");
            Console.Write("\nif(lista != NULL && cantidad > 0)\n{\n");
            Console.Write("\n   for(int i = 0; i<cantidad; i++)\n   {\n");

            Console.Write("\n       if(lista[i]." + (e.listaCampos[e.listaCampos.Count - 1]).nombre + " == 0)\n       {\n");
            Console.Write("\n         respuesta++;\n       } \n    } \n}");
            Console.Write("\n return respuesta; \n}");
            Console.WriteLine("\n");
        }


        public static void mostrarElementosCargados(Estructura e)
        {
            Console.Write("\n\nint mostrar" + e.nombreEstructura + "Cargados( e" + e.nombreEstructura + " lista[] , int cantidad, char mensaje[])\n{\n");

            Console.Write("\nint error = 1; \n int NoHayParaMostrar = 1;\n int cantidadElementosPorPagina = 10;\n float resto;");
            Console.Write("\nif(lista != NULL && cantidad > 0 && cantidadDe" + e.nombreEstructura + "Cargados( lista,cantidad) > 0)\n{\n");
            Console.Write("   printf(\" %s " +@"\n" + "\", mensaje);\n");
            Console.Write("   mostrarCampos" + e.nombreEstructura + "();\n");
            Console.Write("   for(int i = 0; i<cantidad; i++)\n   {\n");
            Console.Write("       if(lista[i]." + (e.listaCampos[e.listaCampos.Count - 1]).nombre + " == 0)\n       {\n");
            Console.Write("             error = 0;\n");
            Console.Write("             resto  = i % cantidadElementosPorPagina;\n");
            Console.Write("             if ( resto  == 0 && i > 0 )\n");
            Console.Write("             {\n");
            Console.Write("                   inputChar(\"Pulse enter para continuar : \");\n");
            Console.Write("                      mostrarCampos" + e.nombreEstructura + "();\n");
            Console.Write("             }      \n");
            Console.Write("            NoHayParaMostrar = 0;      \n");
            Console.Write("          mostrarUn" + e.nombreEstructura + "(lista[i]);\n");
            Console.Write("      }         \n");
            Console.Write("  }         \n");
            Console.Write("  if(  NoHayParaMostrar )  \n");
            Console.Write("  {  \n");
            Console.Write("       printf(\" no hay elementos para mostrar" + @"\n"+"\"); \n");
            Console.Write("  }  \n  }\n");
            Console.Write("return error;\n}\n");
            Console.WriteLine("\n");
        }


        public static void proximoId(Estructura  e)
        {
            Console.Write("\n\nint proximoID" + e.nombreEstructura + "( e" + e.nombreEstructura + " lista[] , int cantidad)\n{\n");
            Console.Write("\n   int max = 0;");
            Console.Write("\n   if(lista != NULL && cantidad > 0 && cantidadDe" + e.nombreEstructura + "Cargados( lista,cantidad) > 0)\n");
            Console.Write("\n   {");
            Console.Write("\n     for(int i = 0; i<cantidad; i++)\n");
            Console.Write("\n     {");
            Console.Write("\n       if((lista[i]." + (e.listaCampos[e.listaCampos.Count - 1]).nombre + " == 0 && max < lista[i]."+ (e.listaCampos[0]).nombre + "))\n" );
            Console.Write("\n        {");
            Console.Write("\n         max = lista[i]."+ e.listaCampos[0].nombre + ";");
            Console.Write("\n         }");
            Console.Write("\n      }");
            Console.Write("\n      max++;");
            Console.Write("\n    }");
            Console.Write("\n   return max;");
            Console.Write("\n}");
            Console.WriteLine("\n");
        }

        /*int buscarContratoPorID(eContrato lista[],int cantidad, int id) */
        public static void buscarEntePorId(Estructura e)
        {
            Console.Write("\n\nint buscar" + e.nombreEstructura + "PorID( e" + e.nombreEstructura + " lista[] , int cantidad , int id )");
            Console.Write("\n{");
            Console.Write("\n   int encontrado = -1;");
            Console.Write("\n   if(lista != NULL && cantidad > 0 && cantidadDe" + e.nombreEstructura + "Cargados( lista,cantidad) > 0)");
            Console.Write("\n   {");
            Console.Write("\n     for(int i = 0; i<cantidad; i++)\n");
            Console.Write("\n     {");
            Console.Write("\n       if((lista[i]." + (e.listaCampos[e.listaCampos.Count - 1]).nombre + " == 0 && lista[i]." + (e.listaCampos[0]).nombre + " == id))\n");
            Console.Write("\n        {");
            Console.Write("\n         encontrado = i;");
            Console.Write("\n         }");
            Console.Write("\n      }");
            Console.Write("\n    }");
            Console.Write("\n   return encontrado;");
            Console.Write("\n}");
            Console.WriteLine("\n");
        }

        public static void Alta(Estructura e)
        {
            string cadena = "";
            Console.Write("\nint alta" + e.nombreEstructura + "( e" + e.nombreEstructura + " lista[] , int cantidad  )");
            Console.Write("\n{");
            Console.Write("\n     int error = 1;");
            Console.Write("\n     int indice;");
            Console.Write("\n     int id;");
            Console.Write("\n      e"  +e.nombreEstructura +" nuevo;");
            Console.Write("\n      int opcion;");
            Console.Write("\n      if( lista != NULL && cantidad != 0)");
            Console.Write("\n       {");
            Console.Write("\n                indice = buscarLibre" + e.nombreEstructura + "( lista, cantidad );");
            Console.Write("\n                 if( indice > -1)");
            Console.Write("\n                  {");
            Console.Write("\n                       printf(\"alta de " + e.nombreEstructura + @"\n" +"\");" );
            Console.Write("\n                       id = proximoID" + e.nombreEstructura +"( lista, cantidad);");
            int i = 0;
            cadena += "\n                        nuevo." + e.listaCampos[i].nombre + " = id;";
            for( i = 1; i< e.listaCampos.Count - 1; i++)
            {
                switch(e.listaCampos[i].tipo)
                {
                    case @"int":
                        cadena += "\n                        nuevo." + e.listaCampos[i].nombre + " = inputInt(\" ingrese el " + e.listaCampos[i].nombre + " : \");"; 
                        break;
                    case @"float":
                        cadena += "\n                        nuevo." + e.listaCampos[i].nombre + " = inputFloat(\" ingrese el " + e.listaCampos[i].nombre + " : \");";
                        break;
                    case @"char":
                        cadena += "\n                        " + "inputString(\" Ingrese " + e.listaCampos[i].nombre + " : \", nuevo." + e.listaCampos[i].nombre + " , " + e.listaCampos[i].tamaño + "); ";
                        break;
                }
            }
            cadena += "\n                        nuevo." + e.listaCampos[i].nombre + " = 0;";

            Console.Write(cadena);
            Console.Write("\n                         opcion = inputIntDesdeHasta(\"Confirma con 1, cancela con 2 : \",1,2);");
            Console.Write("\n                         error = 2;");
            Console.Write("\n                         if(opcion == 1)");
            Console.Write("\n                         {");
            Console.Write("\n                              lista[indice] = nuevo;");
            Console.Write("\n                              error = 0;");
            Console.Write("\n                          }");
            Console.Write("\n                  }");
            Console.Write("\n                  else");
            Console.Write("\n                   {");
            Console.Write("\n                          printf(\""+@"\n No hay más espacio disponible \n" + "\");");
            Console.Write("\n                    }");
            Console.Write("\n            }");
            Console.Write("\n    return error;");
            Console.Write("\n}");
            Console.WriteLine("\n");

        }

        public static void Baja(Estructura e)
        {

            Console.Write("\nint baja" + e.nombreEstructura + "( e" + e.nombreEstructura + " lista[] , int cantidad  )");
            Console.Write("\n{");
            Console.Write("\n     int error = 1;");
            Console.Write("\n     int indice;");
            Console.Write("\n     int id;");

            Console.Write("\n      if( lista != NULL && cantidad != 0)");
            Console.Write("\n       {");
            Console.Write("\n                mostrar" + e.nombreEstructura + "Cargados(lista, cantidad, \"Eliminar " + e.nombreEstructura + "s\"); ");
            Console.Write("\n                id = inputInt(\" Ingrese el ID desde el listado: \");");
            Console.Write("\n                indice = buscar" + e.nombreEstructura + "PorID( lista, cantidad , id);");
            Console.Write("\n                 if( indice > -1)");
            Console.Write("\n                  {");
            Console.Write("\n                       mostrarCampos" + e.nombreEstructura + "();");
            Console.Write("\n                       mostrarUn" + e.nombreEstructura + "( lista[indice]);");
            Console.Write("\n                       error = 2;");

            Console.Write("\n                        if( inputIntDesdeHasta(\"Confirma con 1, cancela con 2 : \",1,2) == 1)");

            Console.Write("\n                         {");
            Console.Write("\n                              lista[indice]." + e.listaCampos[e.listaCampos.Count - 1].nombre +" = 1;");
            
            Console.Write("\n                              error = 0;");
            Console.Write("\n                          }");
            Console.Write("\n                  }");
            Console.Write("\n                  else");
            Console.Write("\n                   {");
            Console.Write("\n                          printf(\"" + @"\n No se encontró el registro buscado \n" + "\");");
            Console.Write("\n                    }");

            Console.Write("\n            }");
            Console.Write("\n            else");
            Console.Write("\n            {");
            Console.Write("\n                 printf(\"" + @"\n No hay elementos para mostrar \n" + "\");");
            Console.Write("\n                 error = 1;");
            Console.Write("\n            }");
            Console.Write("\n    return error;");
            Console.Write("\n}");
            Console.WriteLine("\n");

        }




        public static void Modifica(Estructura e)
        {


            Console.Write("\nint modifica" + e.nombreEstructura + "( e" + e.nombreEstructura + " lista[] , int cantidad  )");
            Console.Write("\n{");
            Console.Write("\n      int error = 1;");
            Console.Write("\n      if( lista != NULL && cantidad != 0)");
            Console.Write("\n     {");
            Console.Write("\n      int indice;");
            Console.Write("\n      int id;");
            Console.Write("\n      e" + e.nombreEstructura + " provisorio;");
            Console.Write("\n      int opcion;");
            
            

            Console.Write("\n                mostrar" + e.nombreEstructura + "Cargados( lista, cantidad, \" Listado para modificar \");");
            Console.Write("\n                id = inputInt(\" Ingrese el id del registro a modificar ; \");");
            Console.Write("\n                indice = buscar" + e.nombreEstructura + "PorID( lista, cantidad, id );");
            Console.Write("\n                 if( indice > -1)");
            Console.Write("\n                  {");
            Console.Write("\n                       mostrarUn" + e.nombreEstructura + "( lista[indice]);");
            Console.Write("\n                       provisorio = lista[indice];");
            int i;
            for(i = 1; i<e.listaCampos.Count - 1; i++)
            {
                campo c = e.listaCampos[i];
                Console.Write("\n                      printf(\" " + i.ToString() + " - " + c.nombre +@"\n" + " \"); ");
            }
            
            Console.Write("\n                     opcion = inputIntDesdeHasta(\"Elija opción del 1 al " + i.ToString() + "\",1," + i.ToString() + ");  ");
            Console.Write("\n                     error = 2;");
            Console.Write("\n                     switch(opcion)");
            Console.Write("\n                     {");

            for (i = 1; i < e.listaCampos.Count - 1; i++)
            {
                campo c = e.listaCampos[i];
                Console.Write("\n                      case " + i.ToString() + ": ");
                switch(c.tipo)
                {
                    case "char":
                        Console.Write("\n                       inputString(\" Ingrese " + c.nombre + " : \" , provisorio." + c.nombre + " , " + c.tamaño + ");");
                        break;
                    case "int":
                        Console.Write("\n                        provisorio." + c.nombre + " = inputInt(\" Ingrese " + c.nombre + " \");");
                        break;
                    case "float":
                        Console.Write("\n                        provisorio." + c.nombre + " = inputFloat(\" Ingrese " + c.nombre + " \");");
                        break;
                }
                Console.Write("\n                            break;");
            }
            Console.Write("\n                       } ");
            Console.Write("\n                       opcion = inputIntDesdeHasta(\"Confire pulsando 1 , cancela con 0 \",0,1);");



            Console.Write("\n                       if(opcion)     ");
            Console.Write("\n                      {     ");
            Console.Write("\n                           lista[indice] = provisorio;");
            Console.Write("\n                           error = 0;");
            Console.Write("\n                      }     ");
            Console.Write("\n                     ");
            Console.Write("\n                 }           ");
            Console.Write("\n       }              ");

           

            Console.Write("\n    return error;");
            Console.Write("\n}");
            Console.WriteLine("\n");

        }

        public static void Menu(Estructura e)
        {

            Console.Write("\nvoid menu" + e.nombreEstructura + "(e" + e.nombreEstructura + " lista[] , int cantidad)             ");
            Console.Write("\n{                                                                        ");
            Console.Write("\n    int opcion;                                                                     ");
            Console.Write("\n    int tope = 6;                                                                     ");
            Console.Write("\n    int resultado;                                                                     ");
            Console.Write("\n    do                                                                        ");
            Console.Write("\n      {                                                                  ");
            Console.Write("\n       resultado = 0;                                                       ");
            Console.Write("\n       printf(\" MENU " + e.nombreEstructura.ToUpper() +  @"\n" + "\");                                      ");
            Console.Write("\n       printf(\" 1 - alta  "+ @"\n" +"\");                                             ");
            Console.Write("\n       printf(\" 2 - baja " + @"\n"+ "\");                                             ");
            Console.Write("\n       printf(\" 3 - modifica " + @"\n" + "\");                                             ");
            Console.Write("\n       printf(\" 4 - listar " + @"\n" + "\");                                             ");
            Console.Write("\n       printf(\" 5 - carga datos de ejemplo " + @"\n" + "\");                           ");
            Console.Write("\n       printf(\" 6 - salir " + @"\n" + "\");                                             ");
            Console.Write("\n       opcion = inputIntDesdeHasta(\" OPCION: \",1,tope);");
            Console.Write("\n       switch(opcion)                                                       ");
            Console.Write("\n       {                                                                 ");
            Console.Write("\n             case 1:                                                           ");
            Console.Write("\n                resultado = alta" + e.nombreEstructura + "(lista, cantidad);    ");
            Console.Write("\n                break;                                                        ");
            Console.Write("\n             case 2:                                                           ");
            Console.Write("\n                resultado = baja" + e.nombreEstructura + "(lista, cantidad);   ");
            Console.Write("\n                break;                                                        ");
            Console.Write("\n             case 3:                                                           ");
            Console.Write("\n                resultado = modifica" + e.nombreEstructura + "(lista, cantidad);   ");
            Console.Write("\n                break;                                                        ");
            Console.Write("\n             case 4:                                                           ");
            Console.Write("\n                mostrar" + e.nombreEstructura + "Cargados(lista, cantidad, \" Listado \");   ");
            Console.Write("\n                break;                                                        ");
            Console.Write("\n             case 5:                                                           ");
            Console.Write("\n                harcodear" + e.nombreEstructura + "(lista);   ");
            Console.Write("\n                break;                                                        ");
            Console.Write("\n       }                                                           ");
            Console.Write("\n       switch(resultado)                                               ");
            Console.Write("\n       {                                                               ");
            Console.Write("\n                  case 0:                                                         ");
            Console.Write("\n                      printf(\" ok " + @"\n" + "\");                                  ");
            Console.Write("\n                  break;                                                         ");
            Console.Write("\n                  case 1:                                                         ");
            Console.Write("\n                      printf(\" operacion terminada con error " + @"\n" + "\");                                                      ");
            Console.Write("\n                  break;                                                         ");
            Console.Write("\n                  case 2:                                                         ");
            Console.Write("\n                      printf(\" operacion cancelada por el usuario " + @"\n" + "\");;                                                      ");
            Console.Write("\n                   break;                                                         ");


           
            Console.Write("\n       }                                                              ");
            
            Console.Write("\n    }while(opcion != tope);                                              ");
            Console.Write("\n }                                                                       ");
            Console.WriteLine("\n");
        }







    }


}
