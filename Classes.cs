using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTask
{
    /// <summary>
    /// Интерфейс конвертации строки в массив
    /// </summary>
    interface IConvertToArray
    {
        int[] ConvertToIntArray(string value);
    }
    /// <summary>
    /// Конвертация строки в массив
    /// </summary>
    internal class ConvertToArray: IConvertToArray
    {
        /// <summary>
        /// Разделитель при конвертации
        /// </summary>
        char Separator { get; set; } = ',';
        /// <summary>
        /// Конфертация строки в массив int
        /// </summary>
        /// <param name="value">Строка для преобразования в массив</param>
        /// <returns>Массив сформированный из строки</returns>
        public int[] ConvertToIntArray(string value)
        {
            if(value.Length == 0) return null;
            int mInt;
            value = value.Replace(" ", "");
            return value.Split(Separator).Select(m => { int.TryParse(m, out mInt); return mInt; }).ToArray();
        }
    }
    /// <summary>
    /// Интерфейс преобразования числа в слово
    /// </summary>
    interface IIntToWord
    {
        string ToWord(int value);
    }
    /// <summary>
    /// Преобразование чисел кратных 3 в fizz
    /// </summary>
    class Fizz: IIntToWord
    {
        /// <summary>
        /// Преобразование чисел кратных 3 в fizz
        /// </summary>
        /// <param name="value">Принимаемое число</param>
        /// <returns>Если число кратно 3 возвращается fizz, иначе пустая строка</returns>
        public string ToWord(int value)
        {
            return value % 3 == 0 ? "fizz" : "";

        }
    }

    /// <summary>
    /// Преобразование чисел кратных 5 в buzz
    /// </summary>
    class Buzz : IIntToWord
    {
        /// <summary>
        /// Преобразование чисел кратных 5 в buzz
        /// </summary>
        /// <param name="value">Принимаемое число</param>
        /// <returns>Если число кратно 5 возвращается buzz, иначе пустая строка</returns>
        public string ToWord(int value)
        {
            return value % 5 == 0 ? "buzz" : "";

        }
    }

    /// <summary>
    /// Преобразование чисел кратных 4 в muzz
    /// </summary>
    class Muzz : IIntToWord
    {
        /// <summary>
        /// Преобразование чисел кратных 4 в muzz
        /// </summary>
        /// <param name="value">Принимаемое число</param>
        /// <returns>Если число кратно 4 возвращается muzz, иначе пустая строка</returns>
        public string ToWord(int value)
        {
            return value % 4 == 0 ? "muzz" : "";

        }
    }

    /// <summary>
    /// Преобразование чисел кратных 7 в guzz
    /// </summary>
    class Guzz : IIntToWord
    {
        /// <summary>
        /// Преобразование чисел кратных 7 в guzz
        /// </summary>
        /// <param name="value">Принимаемое число</param>
        /// <returns>Если число кратно 7 возвращается guzz, иначе пустая строка</returns>
        public string ToWord(int value)
        {
            return value % 7 == 0 ? "guzz" : "";

        }
    }

    /// <summary>
    /// Преобразование чисел кратных 3 в dog, кратных 5 в cat, кратных и 3 и 5 в goodboy
    /// </summary>
    class GodBoy : IIntToWord
    {
        /// <summary>
        /// Преобразование чисел кратных 3 в dog, кратных 5 в cat, кратных и 3 и 5 в goodboy
        /// </summary>
        /// <param name="value">Принимаемое число</param>
        /// <returns>Если число кратно 3 возвращает dog, кратно 5 возвращает cat, кратно и 3, и 5 возвращает goodboy, иначе пустая строка</returns>
        public string ToWord(int value)
        {
            if (value % 3 == 0 && value % 5 == 0) return "good-boy";
            if (value % 3 == 0) return "dog";
            if (value % 5 == 0) return "cat";
            return "";
        }
    }
    
    /// <summary>
    /// Интерфейс преобразования массива чисел в массив строк с заменой значений
    /// </summary>
    interface IReplaceToWorld
    {
        string[] IntArrToWordArr(int[] ints);
    }
    /// <summary>
    /// Преобразования массива чисел в массив строк с заменой значени
    /// </summary>
    class ReplaceToWord : IReplaceToWorld
    {
        /// <summary>
        /// Определяет заменяемые значения в методе IntArrToWordArr
        /// </summary>
        public List<IIntToWord> ListWord { get; set; }
        public ReplaceToWord(List<IIntToWord> listWord)
        {
            ListWord = listWord;
        }
        /// <summary>
        /// Преобразования массива чисел в массив строк с заменой значени
        /// </summary>
        public string[] IntArrToWordArr(int[] ints)
        {
            string[] result = new string[ints.Length];
            for (int i = 0; i < ints.Length; i++)
            {
                foreach (IIntToWord L in ListWord)
                {
                    string str = L.ToWord(ints[i]);
                    if (str.Length > 0)
                    {
                        if (result[i] != null && result[i].Length > 0) result[i] += "-";
                        result[i] += str;
                    }
                }
                if (result[i] == null || result[i].Length == 0) result[i] = ints[i].ToString();
            }
            return result;
        }
    }

    /// <summary>
    /// Преобразование массива string в строку с замененными значениями
    /// </summary>
    class ConvertArrToString
    {
        /// <summary>
        /// Разделитель в методе ReplaceStrArr
        /// </summary>
        string Separator { get; set; } = ",";
        /// <summary>
        /// Преобразование массива string в строку с замененными значениями
        /// </summary>
        public string ReplaceStrArr(string[] arr)
        {
            if (arr == null) return "Некорректный ввод данных!";
            return String.Join(Separator, arr);
        }
    }

}
