using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arvores
{
    /*
        <T> O Tsão é a especificação de um 
        Tipo Genérico (Generics)
    */
    public class TreeNode<T>
    {
        // O atributo data do tipo generic (Tsão) armazenará o valor de fato
        public T? Data { get; set; }
        // O atributo Parent será a referência ao nó pai da árvore
        public TreeNode<T>? Parent { get; set; }
        // O atributo Children é uma lista dos nós filhos, também do tipo T genérico
        public List<TreeNode<T>> Children { get; set; } = new List<TreeNode<T>>();

        public int GetHeight()
        {
            int height = 1;
            TreeNode<T> current = this;
            
            while (current.Parent != null)
            {
                height++;
                current = current.Parent;
            }

            return height;
        }
    }
}