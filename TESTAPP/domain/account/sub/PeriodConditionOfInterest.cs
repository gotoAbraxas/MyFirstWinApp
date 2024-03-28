﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTAPP;
namespace TESTAPP.domain.account.sub
{

    internal struct PeriodConditionOfInterestDto
    {
        public string Start;    
        public string StartPeriod;
        public string End;
        public string EndPeriod;
        public string Interest;
        public int Sign;

    }

    internal class PeriodConditionOfInterest
    {

        public int StartValue { get; set; }
        public SettlePeriodType StartDateType { get; set; }
        public int EndValue { get; set; }
        public SettlePeriodType EndDateType { get; set; }
        public decimal ChangedValue { get; set; }
        public bool Applyed { get; set; } = true;

        public string Description { get; set; }

        public bool CompareDateEnter(DateTime start, DateTime when)
        {
            bool result;
            switch (StartDateType)
            {
                case SettlePeriodType.일:
                   result = start.CompareTo(when.AddDays(StartValue)) >= 0;
                    break;
                case SettlePeriodType.개월:
                    result = start.CompareTo(when.AddMonths(StartValue)) >= 0;
                    break;
                case SettlePeriodType.년:
                    result = start.CompareTo(when.AddYears(StartValue)) >= 0;
                    break;
                default:
                    result = start.CompareTo(when.AddMonths(StartValue)) >= 0;
                    break;
            }
            return result;
        }

        public bool CompareDatePass(DateTime start, DateTime when)
        {
            bool result;
            switch (EndDateType)
            {
                case SettlePeriodType.일:
                    result = start.CompareTo(when.AddDays(EndValue)) <= 0;
                    break;
                case SettlePeriodType.개월:
                    result = start.CompareTo(when.AddMonths(EndValue)) <= 0;
                    break;
                case SettlePeriodType.년:
                    result = start.CompareTo(when.AddYears(EndValue)) <= 0;
                    break;
                default:
                    result = start.CompareTo(when.AddMonths(EndValue)) <= 0;
                    break;
            }
            return result;
        }
    }
}
