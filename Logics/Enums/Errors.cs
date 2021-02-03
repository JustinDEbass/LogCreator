using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Utilities.AdditionalAttributes;

namespace Logics.Enums
{
    /// <summary>
    /// Ошибки
    /// </summary>
    public static class Errors
    {
        /// <summary>
        /// Ошибки валидации настроек таблицы с логами
        /// </summary>
        public enum LogTableSettingsValidateErrors : int
        {
            /// <summary>
            /// Пустое значение
            /// </summary>
            [StringValue("Пустое значение")]
            IsEmpty = 1
        }

        /// <summary>
        /// Ошибки валидации настроек триггера для логирования
        /// </summary>
        public enum LogTriggerSettingsValidateErrors : int 
        {
            /// <summary>
            /// Пустое значение
            /// </summary>
            [StringValue("Пустое значение")]
            IsEmpty = 1,
            /// <summary>
            /// Отрицательное значение
            /// </summary>
            [StringValue("Отрицательное значение")]
            IsNegative = 2,
            /// <summary>
            /// Нулевое значение
            /// </summary>
            [StringValue("Нулевое значение")]
            IsZero = 3
        }

        /// <summary>
        /// Ошибки класса "DatabaseLogCreator"
        /// </summary>
        public enum DatabaseLogCreatorError : int
        {
            /// <summary>
            /// Отсутствует строка подключения к СУБД
            /// </summary>
            [StringValue("Отсутствует строка подключения к СУБД")]
            MissingConnectionString = 1,
            /// <summary>
            /// Отсутствует наименование БД
            /// </summary>
            [StringValue("Отсутствует наименование БД")]
            MissingDatabaseName = 2,
            /// <summary>
            /// Отсутствует подключение к серверу
            /// </summary>
            [StringValue("Отсутствует подключение к серверу")]
            MissingConnection = 3,
            /// <summary>
            /// Отсутствует подключение к БД
            /// </summary>
            [StringValue("Отсутствует подключение к БД")]
            MissingConnectionToDatabase = 4,
            /// <summary>
            /// Список таблиц, изменения в которых требуется логировать, пустой
            /// </summary>
            [StringValue("Список таблиц, изменения в которых требуется логировать, пустой")]
            TableNameListForLogIsEmpty = 5,
            /// <summary>
            /// Не удалось однозначно определить триггер осуществляющий логирование изменений в таблице
            /// </summary>
            [StringValue("Не удалось однозначно определить триггер осуществляющий логирование изменений в таблице \"{{ TableName }}\", найдены следующие триггеры: {{ TriggerNameList }}")]
            TriggerAmbiguous = 6,
            /// <summary>
            /// Не корректно заданы параметры таблицы с логами
            /// </summary>
            [StringValue("Не корректно заданы параметры таблицы с логами")]
            LogTableSettingsIncorrect = 7,
            /// <summary>
            /// Не корректно заданы параметры триггера осуществляющий логирование изменений в таблице
            /// </summary>
            [StringValue("Не корректно заданы параметры триггера осуществляющий логирование изменений в таблице")]
            LogTriggerSettingsIncorrect = 8,
            /// <summary>
            /// Не корректно заданы переменные триггера осуществляющий логирование изменений в таблице
            /// </summary>
            [StringValue("Не корректно заданы переменные триггера осуществляющий логирование изменений в таблице")]
            LogTriggerVariablesIncorrect = 9
        }
    }
}
