//フィボナッチ数列を10個表示
var i = 1;
while (i <= 10)
{
    Console.WriteLine(Fibonacci(i));
    i++;
}

int Fibonacci(int n)
{
    if (n == 1 || n == 2)
    {
        return 1;
    }
    else
    {
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }
}