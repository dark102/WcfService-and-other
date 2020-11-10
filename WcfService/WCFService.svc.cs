using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Newtonsoft.Json;

namespace WcfService
{
    // Прям по правилам один метод одно действие
    public class WCFService : IWCFService
    {
        /// <summary>
        /// Точка входа которая возвращает JSON
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetData(int value)
        {
            if (Kratnost(value))
            {
                return JsonConvert.SerializeObject($"Число {VozvedenieVStepen(value)} кратно 2");
            }
            else
            {
                return JsonConvert.SerializeObject("Число не кратно 2");
            }
        }
        /// <summary>
        /// Возведение в степень
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int VozvedenieVStepen(int value)
        {
            int rez = 0;
            if (!int.TryParse(Math.Pow(value, 2).ToString(), out rez))
                throw new Exception("Ошибка при Возведении в степень");
            return rez;
        }
        /// <summary>
        /// Проверка на кратность
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Kratnost(int value)
        {
            if (value % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
