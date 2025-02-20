﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.Command.MSVC.Params
{
    public class ExceptionHandlingModelInfo
    {
        // IMPORTANT: it must be called equal to its own Type, otherwise, reflection won't work
        public ExceptionHandlingModel ExceptionHandlingModel { get; set; }
        public string Name { get; set; }
        public string Param { get; set; }

        private static ExceptionHandlingModelInfo _Create(ExceptionHandlingModel except, string name, string param)
        {
            ExceptionHandlingModelInfo eh = new ExceptionHandlingModelInfo();
            eh.ExceptionHandlingModel = except;
            eh.Name =   name;
            eh.Param =  param;
            return eh;
        }

        public static ExceptionHandlingModelInfo Get(ExceptionHandlingModel except)
        {
            switch (except)
            {
                case ExceptionHandlingModel.None:   return _Create(except, "",                  "");
                case ExceptionHandlingModel.EHa:    return _Create(except, "Exception EHa",     "/EHa");
                case ExceptionHandlingModel.EHs:    return _Create(except, "Exception EHs",     "/EHs");
                case ExceptionHandlingModel.EHc:    return _Create(except, "Exception EHc",     "/EHc");
                case ExceptionHandlingModel.EHr:    return _Create(except, "Exception EHr",     "/EHr");
                case ExceptionHandlingModel.EHsc:   return _Create(except, "Exception EHsc",    "/EHsc");
                default: return null;
            }
        }

        public static ExceptionHandlingModelInfo GetByParam(string param)
        {
            switch (param)
            {
                case "":        return Get(ExceptionHandlingModel.None);
                case "/EHa":    return Get(ExceptionHandlingModel.EHa);
                case "/EHs":    return Get(ExceptionHandlingModel.EHs);
                case "/EHc":    return Get(ExceptionHandlingModel.EHc);
                case "/EHr":    return Get(ExceptionHandlingModel.EHr);
                case "/EHsc":   return Get(ExceptionHandlingModel.EHsc);
                default: return null;
            }
        }
    }
}
