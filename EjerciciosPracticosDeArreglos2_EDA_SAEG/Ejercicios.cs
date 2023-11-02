using System;
using System.Net;
using System.Runtime.Intrinsics.Arm;
using System.Xml.Linq;

namespace EjerciciosPracticosDeArreglos2_EDA_SAEG
{
    public class Ejercicios
    {
        //Solicitar valores numéricos en dos arreglos distintos y almacenar
        //el resultado de la suma de los valores en cada posicion. Luego
        //mostrar el contenido del tercer array
        public void Ejercicio1()
        {
            Console.WriteLine("Ingrese la longitud de los arrays: ");
            int longitud = Convert.ToInt32(Console.ReadLine());
            int[] array1 = new int[longitud];
            int[] array2 = new int[longitud];
            int[] resultados = new int[longitud];

            for(int i = 0; i < longitud; i++)
            {
                Console.WriteLine($"Ingrese el valor a la posicion {i+1} del primer array:");
                array1[i] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Ingrese el valor a la posicion {i+1} del segundo array: ");
                array2[i] = Convert.ToInt32(Console.ReadLine());
                resultados[i] = array1[i] + array2[i];
            }
            for(int i = 0; i < longitud; i++)
            {
                Console.WriteLine($"La suma de {array1[i]} + {array2[i]} = {resultados[i]}");
            }
        }
        //Buscar un elemento ingresado desde el teclado en un arreglo y guardar las posiciones 
        //en otro arreglo. Si hay más de una coincidencia, indicar igualmente la posición.
        public void Ejercicio2()
        {
            int[] arrayParaBusqueda = new int[10] { 0, 1, 2, 3, 5, 6, 7, 8, 9, 10 };
            int[] posicionDeLaBusqueda = new int[10];
            int contador = 0;
            Console.WriteLine("Ingrese el número que desea buscar: ");
            int valorDeBusqueda = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < arrayParaBusqueda.Length; i++)
            {
                if (arrayParaBusqueda[i] == valorDeBusqueda)
                {
                    posicionDeLaBusqueda[contador] = i;
                    contador++;
                }
                else if(i ==  arrayParaBusqueda.Length - 1 && arrayParaBusqueda[i] != valorDeBusqueda)
                {
                    Console.WriteLine($"El valor {valorDeBusqueda} no se encuentra en el arreglo");
                    break;
                }
            }
            if (contador > 0)
                for (int i = 0; i < contador; i++)
                    Console.WriteLine($"El número {valorDeBusqueda} esta en la posicion {posicionDeLaBusqueda[i]}");
        }
        //Solicitaremos los IDs(números) de los alumnos de dos clases y los guardaremos en dos
        //arreglos con los nombres 'álgebra' y 'análisis'. Queremos mostrar a todos los alumnos 
        //que están inscritos en ambas asignaturas. Estos alumnos se guardarán en un tercer arreglo,
        //el cual se mostrará. También se indicará el número de alumnos que se repiten.
        public void Ejercicio3()
        {
            Console.WriteLine("Ingresa la cantidad de alumnos que hay en la clase de algebra: ");
            int[] alumnosDeAlgebra = new int[Convert.ToInt32(Console.ReadLine())];
            Console.WriteLine("Ingresa la cantidad de alumnos que hay en la clase de analisis: ");
            int[] alumnosDeAnalisis = new int[Convert.ToInt32(Console.ReadLine())];
            for (int i = 0; i < alumnosDeAlgebra.Length; i++)
            {
                if(i == 0)
                {
                    Console.WriteLine($"Ingrese el ID alumno de algebra: ");
                    alumnosDeAlgebra[i] = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine($"Ingrese el ID alumno de algebra: ");
                    alumnosDeAlgebra[i] = Convert.ToInt32(Console.ReadLine());
                    for (int j = 0; j < i; j++)
                    {
                        if (alumnosDeAlgebra[i] == alumnosDeAlgebra[j])
                        {
                            i--;
                            Console.WriteLine("El alumno ya habia sido ingresado a esta clase, vuelvelo a intentar!");
                            break;
                        }
                    }
                }

            }
            for(int i = 0; i < alumnosDeAnalisis.Length; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine($"Ingrese el ID alumno de analisis: ");
                    alumnosDeAnalisis[i] = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine($"Ingrese el ID alumno de analisis: ");
                    alumnosDeAnalisis[i] = Convert.ToInt32(Console.ReadLine());
                    for (int j = 0; j < i; j++)
                    {
                        if (alumnosDeAlgebra[i] == alumnosDeAlgebra[j])
                        {
                            i--;
                            Console.WriteLine("El alumno ya habia sido ingresado a esta clase, vuelvelo a intentar!");
                            break;
                        }
                    }
                }
            }
            int[] compartenClase = CompartenClase(alumnosDeAnalisis, alumnosDeAlgebra);
            Console.WriteLine($"La cantidad de alumnos inscritos en ambas materias son {compartenClase.Length}");
            Console.WriteLine("Y sus ID's son: ");
            for(int i = 0; i < compartenClase.Length; i++)
            {
                Console.WriteLine(compartenClase[i]);
            }
        }
        //Método de apoyo para el Método Ejercicio3
        public int[] CompartenClase(int[] clase1, int[] clase2)
        {
            int contador = 0;
            if (clase1.Length > clase2.Length)
            {
                for (int i = 0; i < clase1.Length; i++)
                {
                    for(int j = 0; j < clase2.Length; j++)
                    {
                        if (clase1[i] == clase2[j])
                        {
                            contador++;
                        }
                    }
                }
                int [] claseCompartida = new int[contador];
                for (int i = 0; i < clase1.Length; i++)
                {
                    for (int j = 0; j < clase2.Length; j++)
                    {
                        if (clase1[i] == clase2[j])
                        {
                            claseCompartida[i] = clase1[i];
                        }
                    }
                }
                return claseCompartida;
            }
            else
            {
                for (int i = 0; i < clase2.Length; i++)
                {
                    for (int j = 0; j < clase1.Length; j++)
                    {
                        if (clase2[i] == clase1[j])
                        {
                            contador++;
                        }
                    }
                }
                int[] claseCompartida = new int[contador];
                for (int i = 0; i < clase2.Length; i++)
                {
                    for (int j = 0; j < clase1.Length; j++)
                    {
                        if (clase2[i] == clase1[j])
                        {
                            claseCompartida[i] = clase2[i];
                        }
                    }
                }
                return claseCompartida;
            }
        }
        //Solicitar por entrada de teclado el tamaño de un arreglo de números y luego ingresar
        //los valores númericos para llenarlo. Los valores no deben repetirse. Al finalizar, mostrar
        //el contenido del arreglo con los valores ingresados

        public void Ejercicio4()
        {
            Console.WriteLine("Ingresa la cantidad de elementos deseas agregar en el array: ");
            int[] arraySimple = new int[Convert.ToInt32(Console.ReadLine())];
            for (int i = 0; i < arraySimple.Length; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine($"Ingresa el valor {i+1} a tu array: ");
                    arraySimple[i] = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine($"Ingresa el valor {i + 1} a tu array: ");
                    arraySimple[i] = Convert.ToInt32(Console.ReadLine());
                    for (int j = 0; j < i; j++)
                    {
                        if (arraySimple[i] == arraySimple[j])
                        {
                            i--;
                            Console.WriteLine($"El valor {arraySimple[i]} esta repetido en la posiciom {j} \nIntentolo nuevamente!");
                            break;
                        }
                    }
                }
                Console.WriteLine();
            }
            for(int i = 0; i < arraySimple.Length; i++)
            {
                Console.WriteLine($"Posicion {i+1}: {arraySimple[i]}");
            }

        }
        //Dado un arreglo de N notas, cada una en un rando de 0 a 20, calcule el promedio
        //de las notas aprobadas y el promedio de las notas desaprobadas. Ademas, indique
        //la cantidad de notas aprobadas y desaprobadas en el arreglo. Los rangos son:
        // Deficiente 0-5 Regular 6-10 Buenos 11-15 Excelentes 16-20
        public void Ejercicio5()
        {
            Console.WriteLine("Ingresa la cantidad de calificaciones a evaluar: ");
            int[] arrayCalificaciones = new int[Convert.ToInt32(Console.ReadLine())];
            int aprobados = 0;
            int reprobados = 0;
            string[] arrayResultados = new string[arrayCalificaciones.Length];
            for (int i = 0; i < arrayCalificaciones.Length; i++)
            {
                Console.WriteLine($"Ingresa la calificacion {i +1}: ");
                arrayCalificaciones[i] = Convert.ToInt32(Console.ReadLine());
                arrayResultados[i] = TipoDeResultados(arrayCalificaciones[i]); 
                if (arrayResultados[i] == "Deficientes" || arrayResultados[i] == "Regulares")
                    reprobados++;
                else
                    aprobados++;
                Console.WriteLine();
            }
            double promedio = (Convert.ToDouble(reprobados)/Convert.ToDouble(arrayResultados.Length))*100;
            Console.WriteLine($"La cantidad de alumnos reprobados es de: {reprobados}.\nEn un salon de {arrayCalificaciones.Length}");
            Console.WriteLine($"Y en promedio es de: {promedio}%");
            Console.WriteLine($"Tipo de calificaciones reprobatorias: \nDeficientes 0-5: {ContadorPorTipoDeCalificacion(arrayResultados, "Deficientes")}" +
                $"\nRegulares 6-10: {ContadorPorTipoDeCalificacion(arrayResultados, "Regulares")}\n");

            promedio = (Convert.ToDouble(aprobados) / Convert.ToDouble(arrayResultados.Length)) * 100;
            Console.WriteLine($"La cantidad de alumnos aprobados es de: {aprobados}.\nEn un salon de {arrayCalificaciones.Length}");
            Console.WriteLine($"Y en promedio es de: {promedio}%");
            Console.WriteLine($"Tipo de calificaciones aprobatorias: \nBuenos 11-15: {ContadorPorTipoDeCalificacion(arrayResultados,"Buenos")}" +
                $"\nExcelentes 16-20: {ContadorPorTipoDeCalificacion(arrayResultados,"Excelentes")}");
        }
        //Sub-Métodos para evaluar las calificaciones y evitar tanto código en el Método Ejecicio5
        public string TipoDeResultados(int calificacionIngresada)
        {
            if(calificacionIngresada < 0 || calificacionIngresada > 20)
            {
                return "Deficientes";
            }
            else if(calificacionIngresada >=0 && calificacionIngresada <= 5)
            {
                return "Deficientes";
            }
            else if(calificacionIngresada >=6 && calificacionIngresada <= 10)
            {
                return "Regulares";
            }
            else if (calificacionIngresada >= 11 && calificacionIngresada <= 15)
            {
                return "Buenos";
            }
            else
            {
                return "Excelentes";
            }
        }
        public int ContadorPorTipoDeCalificacion(string[] arrayConTipoDeDatos, string datoQueBuscamosContar) 
        {
            int contador = 0;
            for (int i = 0; i < arrayConTipoDeDatos.Length; i++)
            {
                if (arrayConTipoDeDatos[i] == datoQueBuscamosContar)
                    contador++;    
            }
            return contador;
        }
    }
}
