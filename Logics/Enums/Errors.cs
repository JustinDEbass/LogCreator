using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Utilities.AdditionalAttributes;

namespace Logics.Enums
{
    public static class Errors
    {
        public enum LogTableSettingsValidateErrors : int
        {
            [StringValue("Пустое значение")]
            IsEmpty = 1
        }

        public enum LogTriggerSettingsValidateErrors : int 
        {
            [StringValue("Пустое значение")]
            IsEmpty = 1,
            [StringValue("Отрицательное значение")]
            IsNegative = 2,
            [StringValue("Нулевое значение")]
            IsZero = 3
        }

        public enum DatabaseLogCreatorError : int
        {
            [StringValue("Отсутствует строка подключения к СУБД")]
            MissingConnectionString = 1,
            [StringValue("Отсутствует наименование БД")]
            MissingDatabaseName = 2,
            [StringValue("Отсутствует подключение к серверу")]
            MissingConnection = 3,
            [StringValue("Отсутствует подключение к БД")]
            MissingConnectionToDatabase = 4,
            [StringValue("Список таблиц, изменения в которых требуется логировать, путой")]
            TableNameListForLogIsEmpty = 5,
            [StringValue("Не удалось однозначно определить триггер осуществляющий логирование изменений в таблице \"{{ TableName }}\", найдены следующие триггеры: {{ TriggerNameList }}")]
            TriggerAmbiguous = 6,
            [StringValue("Не корректно заданы параметры таблицы с логами")]
            LogTableSettingsIncorrect = 7,
            [StringValue("Не корректно заданы параметры триггера осуществляющий логирование изменений в таблице")]
            LogTriggerSettingsIncorrect = 8,
            [StringValue("Не корректно заданы переменные триггера осуществляющий логирование изменений в таблице")]
            LogTriggerVariablesIncorrect = 9
        }
    }
}
