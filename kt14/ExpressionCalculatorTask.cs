using System;
using System.Collections.Generic;

class ExpressionCalculatorTask
{
    public static void Execute()
    {
        Console.Write("Введите арифметическое выражение: ");
        string expression = Console.ReadLine();

        if (string.IsNullOrEmpty(expression))
        {
            Console.WriteLine("Выражение не должно быть пустым.");
            return;
        }

        var operators = new Dictionary<char, int>
        {
            { '+', 1 },
            { '-', 1 },
            { '*', 2 },
            { '/', 2 }
        };

        try
        {
            var postfix = ConvertToPostfix(expression, operators);
            double result = EvaluatePostfix(postfix);
            Console.WriteLine($"Результат: {result}");
        }
        catch (Exception)
        {
            Console.WriteLine("Ошибка в выражении.");
        }
    }

    private static List<string> ConvertToPostfix(string expression, Dictionary<char, int> operators)
    {
        var output = new List<string>();
        var stack = new Stack<char>();

        foreach (char token in expression)
        {
            if (char.IsDigit(token))
            {
                output.Add(token.ToString());
            }
            else if (operators.ContainsKey(token))
            {
                while (stack.Count > 0 && operators.ContainsKey(stack.Peek()) && operators[stack.Peek()] >= operators[token])
                {
                    output.Add(stack.Pop().ToString());
                }
                stack.Push(token);
            }
        }

        while (stack.Count > 0)
        {
            output.Add(stack.Pop().ToString());
        }

        return output;
    }

    private static double EvaluatePostfix(List<string> postfix)
    {
        var stack = new Stack<double>();

        foreach (string token in postfix)
        {
            if (double.TryParse(token, out double number))
            {
                stack.Push(number);
            }
            else
            {
                double b = stack.Pop();
                double a = stack.Pop();
                stack.Push(token switch
                {
                    "+" => a + b,
                    "-" => a - b,
                    "*" => a * b,
                    "/" => a / b,
                    _ => throw new InvalidOperationException("Неизвестный оператор")
                });
            }
        }

        return stack.Pop();
    }
}
