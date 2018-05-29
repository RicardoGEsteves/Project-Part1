using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_Part1
{
    internal class Project_Engine
    {
        private List<Archive> archives = new List<Archive>()
        {
            new Archive(){Name="2017Dec", ArchivedDate = new DateTime(2017, 12, 22), IdentificationNumber = 5965},
            new Archive(){Name="2016Dec", ArchivedDate = new DateTime(2016, 12, 21), IdentificationNumber = 3065},
            new Archive(){Name="2017Nov", ArchivedDate = new DateTime(2017, 11, 30), IdentificationNumber = 5635},
            new Archive(){Name="2017Dec-2", ArchivedDate = new DateTime(2017, 12, 29), IdentificationNumber = 5995},
            new Archive(){Name="2017Out", ArchivedDate = new DateTime(2017, 11, 02), IdentificationNumber = 5105},
            new Archive(){Name="2015Dec", ArchivedDate = new DateTime(2015, 12, 31), IdentificationNumber = 1569},
            new Archive(){Name="2017Out-2", ArchivedDate = new DateTime(2017, 11, 15), IdentificationNumber = 5166},
        };

        //Criar um atributo -> uma nova pilha (stack) vazia
        private Stack<Archive> stackArchives = new Stack<Archive>();
        //Criar um atributo -> uma nova fila (queue) vazia
        private Queue<Archive> queueArchives = new Queue<Archive>();
        //Criar dois Arrays como atributos
        private Archive[] arrayOfStack = new Archive[7];
        private Archive[] arrayOfQueue = new Archive[7];

        //Construtor -> Inicia os métodos de construção das pilhas e fila, e respetivos comportamentos
        public Project_Engine()
        {
            //Run();
            RunSort();
        }

        //Método responsável por correr os restantes métodos pela ordem pretendida ( pode ser necessário efetuar ajustes)
        private void Run()
        {
            SaveStack();
            SaveQueue();
            PrintDataStructures();
            CopyTo("queue");
            CopyTo("stack");
            FilterData();
            PrintAllData();
            Console.ReadKey();
        }

        //Método que guarda os valores da lista "archives" na pilha criada nos atributos
        private void SaveStack()
        {
            foreach (Archive element in archives)
            {
                stackArchives.Push(element);
            }
        }

        //Método que guarda os valores da lista "archives" na fila criada nos atributos
        private void SaveQueue()
        {
            foreach (Archive element in archives)
            {
                queueArchives.Enqueue(element);
            }
        }

        //Método responsável por imprimir os dados que estão na fila e na pilha
        //O resultado da consola deve respeitar as respetivas regras de FIFO e FILO
        private void PrintDataStructures()
        {
            Console.WriteLine("Stack: ");
            foreach (Archive element in stackArchives)
            {
                Console.WriteLine(element.Name);
               
            };
            Console.WriteLine("Queue: ");
            foreach (Archive element in queueArchives)
            {
                Console.WriteLine(element.Name);

            }
        }

        //Método para copiar para os Arrays
        //Pode ser necessário ajustar/apagar/editar este método, além de acrescentar informação
        //ATENÇÃO: Assegurar que a lista original só tem os dados que não foram enviados para o Array
        private void CopyTo(string type)
        {
            if (type.Equals("queue"))
            {
                Queue<Archive> filteredQueue = FilterData();
                List<Archive> tempList = queueArchives.Except(filteredQueue).ToList();
                queueArchives = new Queue<Archive>(tempList);
                    
                archives.CopyTo(arrayOfQueue, 0);
                //...
            }
            else
            if (type.Equals("stack"))
            {
                archives.CopyTo(arrayOfStack, 0);
                //...
                stackArchives.Clear();
            }
        }

        //Método para filtrar a queue, deve devolver uma queue que tenha apenas os arquivos dos ultimos 3 meses
        private Queue<Archive> FilterData()
        {
            Queue<Archive> nova = new Queue<Archive>(queueArchives.Where(u => (u.ArchivedDate < new DateTime(2017, 10, 05))).ToList());

            return nova;
        }

        // Método responsável por imprimir os arrays, a queue e a stack na sua versão final (dados ordenados por IdentificationNumber)
        // Devem escrever informação ao utilizador, p.e. Stack: {1, 2 , 5}
        private void PrintAllData()
        {
            arrayOfQueue = arrayOfQueue.OrderBy(v => v.IdentificationNumber).ToArray();

            arrayOfStack = arrayOfStack.OrderBy(p => p.IdentificationNumber).ToArray();

            Console.WriteLine("Order Queue: ");
            foreach (Archive element in arrayOfQueue)
            {
                Console.WriteLine(element.Name);

            };
            Console.WriteLine("Order Stack: ");
            foreach (Archive element in arrayOfStack)
            {
                Console.WriteLine(element.Name);

            }
            //...
        }

        //-----------------------------------------------------A PARTIR DAQUI, ENTREGA PARA DIA 5/01 -----------------------------------------------------------
        // Necessário alterar as classes que estão na pasta Sort

        //Método responsável por correr os métodos de Sort pela ordem pretendida
        private void RunSort()
        {
            CopyListToArray();
            SortArray();
        }

        //Método responsável por copiar a lista original para um Array e guardá-lo nos dos arrays dos atributos
        private void CopyListToArray()
        {
            archives.CopyTo(arrayOfQueue);
            //...
        }

        // método responsável por chamar o algoritmo de BubbleSort e o Comparable -> Imprime na consola ambos os Arrays
        private void SortArray()
        {
            //Print archives order by IdentificationNumber
            Console.WriteLine("sort");
            archives.Sort();

            foreach (Archive a in archives)
            {
                Console.WriteLine(a.IdentificationNumber);
            }

            Console.WriteLine("bubblesort");

            SortAlgorithm.BubbleSort(arrayOfQueue, arrayOfQueue.Length);

            //Print array order by IdentificationNumber
            foreach (Archive a in arrayOfQueue)
            {
                Console.WriteLine(a.IdentificationNumber);
            }

            Console.ReadKey();
        }
    }

}
    
