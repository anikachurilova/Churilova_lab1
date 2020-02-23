using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Churilova01.Models
{
    class Birthdate
    {
        private DateTime _bDate;
        private string _westGoroscop;
        private string _chinaGoroscop;
        private int _age;

        public DateTime BDate
        {
            get { return _bDate; }
            set { _bDate = value; }
        }
        public  string WGoroscope {
            get { return _westGoroscop; }
            set { _westGoroscop = value; }
        }

        public string CGoroscope
        {
            get { return _chinaGoroscop; }
            set { _chinaGoroscop = value; }
        }

        public  int Age
        {
            get { return _age;}
            set { _age = value; }
        }

        public static int CalculateAge(DateTime BirthDate)
        {

            int years = DateTime.Now.Year - BirthDate.Year;
            return years;
        }
        public void CalculateAge()
        {
            int years = DateTime.Now.Year - _bDate.Year;
            _age = years;
        }

        public void Westerngoroscope()
        {
            string resW = "";
            switch (_bDate.Month)
            {
                case 1:
                    if (_bDate.Day <= 20) resW = "You are Capricorn.";
                    else if (_bDate.Day >= 21) resW = "You are Aquarius.";
                    break;

                case 2:
                    if (_bDate.Day <= 19) resW = "You are Aquarius.";
                    else if (_bDate.Day >= 20) resW = "You are Pisces.";
                    break;

                case 3:
                    if (_bDate.Day <= 20) resW = "You are Pisces.";
                    else if (_bDate.Day >= 21) resW = "You are Aries.";
                    break;

                case 4:
                    if (_bDate.Day <= 20) resW = "You are Aries.";
                    else if (_bDate.Day >= 21) resW = "You are Telets.";
                    break;

                case 5:
                    if (_bDate.Day <= 21) resW = "You are Telets.";
                    else if (_bDate.Day >= 22) resW = "You are Gemini.";
                    break;

                case 6:
                    if (_bDate.Day <= 21) resW = "You are Gemini.";
                    else if (_bDate.Day >= 22) resW = "You are Cancer.";
                    break;

                case 7:
                    if (_bDate.Day <= 22) resW = "You are Cancer.";
                    else if (_bDate.Day >= 23) resW = "You are Leo.";
                    break;

                case 8:
                    if (_bDate.Day <= 23) resW = "You are Leo.";
                    else if (_bDate.Day >= 24) resW = "You are Virgo.";
                    break;

                case 9:
                    if (_bDate.Day <= 22) resW = "You are Virgo.";
                    else if (_bDate.Day >= 23) resW = "You are Libra.";
                    break;

                case 10:
                    if (_bDate.Day <= 22) resW = "You are Libra.";
                    else if (_bDate.Day >= 23) resW = "You are Scorpio.";
                    break;

                case 11:
                    if (_bDate.Day <= 21) resW = "You are Scorpio.";
                    else if (_bDate.Day >= 21) resW = "You are Sagittarius.";
                    break;

                case 12:
                    if (_bDate.Day <= 21) resW = "You are Sagittarius.";
                    else if (_bDate.Day >= 22) resW = "You are Capricorn.";
                    break;
            }

            _westGoroscop = resW;
        }



        public void Chinesegoroscope()
        {
            string resC = "";
            switch (_bDate.Year % 12)
            {
                case 1:
                    resC = "You are Rooster.";
                    break;

                case 2:
                    resC = "You are Dog.";
                    break;

                case 3:
                    resC = "You are Pig.";
                    break;

                case 4:
                    resC = "You are Rat.";
                    break;

                case 5:
                    resC = "You are Ox.";
                    break;

                case 6:
                    resC = "You are Tiger.";
                    break;

                case 7:
                    resC = "You are Rabbit.";
                    break;

                case 8:
                    resC = "You are Dragon.";
                    break;

                case 9:
                    resC = "You are Snake.";
                    break;

                case 10:
                    resC = "You are Horse.";
                    break;

                case 11:
                    resC = "You are Ram.";
                    break;

                case 0:
                    resC = "You are Monkey.";
                    break;
            }
           _chinaGoroscop = resC;
        }
    }
}
