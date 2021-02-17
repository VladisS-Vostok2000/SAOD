using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_Stack {
    internal sealed class Program {
        internal static void Main(string[] args) {
            {
                MyStack<int> stack = new MyStack<int>(3);
                Console.WriteLine(stack.IsEmpty);
                stack.Push(0);
                stack.Push(1);
                stack.Push(2);
                Console.WriteLine(stack.IsEmpty);

                try {
                    stack.Push(3);
                }
                catch (StackOverflowException) { }

                Console.WriteLine(stack.Top);
                Console.WriteLine(stack.Pop);
                Console.WriteLine(stack.Pop);
                Console.WriteLine(stack.Pop);

                try {
                    Console.WriteLine(stack.Pop);
                }
                catch (ArgumentOutOfRangeException) { }

                Console.WriteLine(stack.IsEmpty);

                Console.ReadKey(true);
            }

            do {
                string str;
                do {
                    Console.WriteLine("Входная строка: введите последовательность скобок.\r\nОтличные от '(', '{', '[', ')', '}', ']' символы будут удалены.\r\nМаксимум 20 скобок.");
                    str = Console.ReadLine();
                } while (str.Length == 0);

                MyStack<int> stack = new MyStack<int>(20);

                // Проверяем парность скобок.
                try {
                    foreach (var chr in str) {
                        switch (chr) {
                            case '(':
                                stack.Push(0);
                                break;
                            case '{':
                                stack.Push(1);
                                break;
                            case '[':
                                stack.Push(2);
                                break;
                            case ')':
                                if (stack.Pop != 0) {
                                    Console.WriteLine("Строка неверна.");
                                    goto End;
                                }
                                break;
                            case '}':
                                if (stack.Pop != 1) {
                                    Console.WriteLine("Строка неверна.");
                                    goto End;
                                }
                                break;
                            case ']':
                                if (stack.Pop != 2) {
                                    Console.WriteLine("Строка неверна.");
                                    goto End;
                                }
                                break;
                        }
                    }

                    if (!stack.IsEmpty) {
                        Console.WriteLine("Строка неверна.");
                    }
                    else {
                        Console.WriteLine("Строка верна.");
                    }

                End: continue;
                }
                catch (StackOverflowException) {
                    Console.WriteLine("Слишком много скобок.");
                }
                catch (Exception) {
                    Console.WriteLine("Строка неверна.");
                }
            } while (true);

        }

    }
}
