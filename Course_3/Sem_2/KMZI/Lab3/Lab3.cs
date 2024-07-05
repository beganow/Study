using System;
using System.Text;

public class XorExample
{
    public static void Main()
    {
        Console.WriteLine("Введите строку a:");
        string a = Console.ReadLine();

        Console.WriteLine("Введите строку b:");
        string b = Console.ReadLine();


        Console.WriteLine("Введите строку a в base64:");
        string a1 = Console.ReadLine();

        Console.WriteLine("Введите строку b в base64:");
        string b1 = Console.ReadLine();

        byte[] bufferA = Encoding.ASCII.GetBytes(a);
        byte[] bufferB = Encoding.ASCII.GetBytes(b);

        byte[] bufferA1 = Convert.FromBase64String(a1);
        byte[] bufferB1 = Convert.FromBase64String(b1);

        byte[] result1 = XorBuffers(bufferA, bufferB);
        byte[] result2 = XorBuffersUsingAes(bufferA, bufferB);
        byte[] result4 = XorBuffers(bufferA1, bufferB1);
        byte[] result5 = XorBuffersUsingAes(bufferA1, bufferB1);
        byte[] result3 = XorBuffersUsingAes(result1, bufferB);
        Console.WriteLine("Результат XOR операции (самописная функция):");
        Console.WriteLine(ConvertToAscii(result1));

        Console.WriteLine("Результат XOR операции (встроенная функция):");
        Console.WriteLine(ConvertToAscii(result2));
     
        Console.WriteLine("Результат XOR операция base64:");
        Console.WriteLine(ConvertToAscii(result4));

        Console.WriteLine("Результат XOR операция base64(встроенная функция):");
        Console.WriteLine(ConvertToAscii(result5));

        Console.WriteLine("Результат аXORbXORb операции (самописная функция):");
        Console.WriteLine(ConvertToAscii(result3));

        bool areEqual = CompareByteArrays(result1, result2);
        Console.WriteLine("Результаты равны: " + areEqual);
    }

    public static byte[] XorBuffers(byte[] a, byte[] b)
    {
        int length = Math.Max(a.Length, b.Length);
        byte[] result = new byte[length];

        for (int i = 0; i < length; i++)
        {
            byte aValue = i < a.Length ? a[i] : (byte)0;
            byte bValue = i < b.Length ? b[i] : (byte)0;

            result[i] = (byte)(aValue ^ bValue);
        }

        return result;
    }

    public static byte[] XorBuffersUsingAes(byte[] a, byte[] b)
    {
        int length = Math.Max(a.Length, b.Length);
        byte[] result = new byte[length];

        for (int i = 0; i < length; i++)
        {
            byte aValue = i < a.Length ? a[i] : (byte)0;
            byte bValue = i < b.Length ? b[i] : (byte)0;

            result[i] = (byte)(aValue ^ bValue);
        }

        return result;
    }

    public static string ConvertToAscii(byte[] buffer)
    {
        return Encoding.ASCII.GetString(buffer);
    }

    public static bool CompareByteArrays(byte[] a, byte[] b)
    {
        if (a.Length != b.Length)
        {
            return false;
        }

        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] != b[i])
            {
                return false;
            }
        }

        return true;
    }
}