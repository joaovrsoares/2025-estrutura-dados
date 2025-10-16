# QuickSort

QuickSort é um eficiente algoritmo de ordenação baseado na estratégia de dividir e conquistar. Desenvolvido por Tony Hoare em 1959, é um dos algoritmos de ordenação mais utilizados devido à sua performance na prática.

## Como Funciona

O algoritmo segue estas etapas:

1. **Escolha do pivô**: Seleciona um elemento do array como pivô.
2. **Particionamento**: Reorganiza o array de modo que elementos menores que o pivô fiquem à esquerda e maiores à direita.
3. **Recursão**: Aplica o mesmo processo recursivamente nas sub-partições.

## Implementação

```c#
public void quickSort(int[] arr, int inicio, int fim) {
    if (inicio < fim) {
        int indicePivo = particionar(arr, inicio, fim);
        quickSort(arr, inicio, indicePivo - 1);
        quickSort(arr, indicePivo + 1, fim);
    }
}

private int particionar(int[] arr, int inicio, int fim) {
    int pivo = arr[fim];
    int i = inicio - 1;
    
    for (int j = inicio; j < fim; j++) {
        if (arr[j] <= pivo) {
            i++;
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
    
    int temp = arr[i + 1];
    arr[i + 1] = arr[fim];
    arr[fim] = temp;
    
    return i + 1;
}
```

## Complexidade

- **Caso médio**: O(n log n)
- **Pior caso**: O(n²) - ocorre quando o pivô sempre é o menor ou maior elemento
- **Melhor caso**: O(n log n)

## Vantagens

- Eficiente na prática
- Baixa sobrecarga
- Implementações in-place (sem memória adicional significativa)

## Desvantagens

- Instável (pode alterar a ordem de elementos iguais)
- Performance pode degradar para O(n²) em casos específicos