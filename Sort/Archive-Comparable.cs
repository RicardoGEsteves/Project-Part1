using System;

namespace Project_Part1
{
    //Classe para implementar o IComparable no Archive por Nome
    internal class Archive_Comparable : IComparable<Archive>
    {
        public String Name { get; set; }
        public DateTime ArchivedDate { get; set; }
        public int IdentificationNumber { get; set; }

        //Método que vai definir a Comparação
        public int CompareTo(Archive other)
        {
            throw new NotImplementedException();
        }
    }
}