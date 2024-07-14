using System;

public class Program
{
    public static void Main()
    {

        //vetor de faturamento diário ao longo do ano de 2023
        DateTime[] dias2023 = new DateTime[365];
        DateTime dataAtual = new DateTime(2023, 1, 1);

        Random numAleatorio = new Random();
        decimal[] faturamentoDiario = new decimal[365];

        for (int i = 0; i < faturamentoDiario.Length; i++)
        {
            if (dataAtual.DayOfWeek == DayOfWeek.Saturday || dataAtual.DayOfWeek == DayOfWeek.Sunday)
            {
                faturamentoDiario[i] = 0;
                dataAtual = dataAtual.AddDays(1); // Avançando para o próximo dia
            }
            else
            {
                dias2023[i] = dataAtual;
                faturamentoDiario[i] = numAleatorio.Next(1, 3000);
                dataAtual = dataAtual.AddDays(1); // Avançando para o próximo dia
            }
        }

        var resultados = AnalisarFaturamentoAnual(faturamentoDiario);

        Console.WriteLine($"Menor faturamento diário: R${resultados.Item1}");
        Console.WriteLine($"Maior faturamento diário: R${resultados.Item2}");
        Console.WriteLine($"Número de dias com faturamento acima da média: {resultados.Item3}");
    }

    public static Tuple<decimal, decimal, int> AnalisarFaturamentoAnual(decimal[] faturamentoDiario)
    {
        decimal menorFaturamento = decimal.MaxValue;
        decimal maiorFaturamento = decimal.MinValue;
        decimal totalFaturamento = 0;
        int diasComFaturamento = 0;


        foreach (decimal valor in faturamentoDiario)
        {
            if (valor > 0) 
            {
                if (valor < menorFaturamento)
                {
                    menorFaturamento = valor;
                }
                if (valor > maiorFaturamento)
                {
                    maiorFaturamento = valor;
                }
                totalFaturamento += valor;
                diasComFaturamento++;
            }
        }


        decimal mediaAnual = diasComFaturamento > 0 ? totalFaturamento / diasComFaturamento : 0;

        int diasAcimaMedia = 0;
        foreach (decimal valor in faturamentoDiario)
        {
            if (valor > mediaAnual)
            {
                diasAcimaMedia++;
            }
        }
        return Tuple.Create(menorFaturamento, maiorFaturamento, diasAcimaMedia);
    }
}
