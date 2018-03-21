using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClasseJson
{
    class Program
    {
        static void Main(string[] args)
        {          
            Console.WriteLine(ToJson());

            var t = JsonConvert.DeserializeObject<List<MensagemJson>>(ToJson());
            Console.ReadKey();
        }

        public static string ToJson()
        {
            Array values = Enum.GetValues(typeof(Mensagem));
            List<MensagemJson> jsonCompleto = new List<MensagemJson>();

            foreach (Mensagem value in values)
            {
                MensagemJson json = new MensagemJson();

                json.Chave = Enum.GetName(typeof(Mensagem), value);
                json.Id = value.GetAttribute<CustomAttribute>().Id;
                //json.Mensagem = value.GetAttribute<CustomAttribute>().Mensagem;
                json.Mensagem = value.GetMensagem();
             
                jsonCompleto.Add(json);
            }

            return JsonConvert.SerializeObject(jsonCompleto);        
        }      
    }

    public static class EnumExtensions
    {
        public static TAttribute GetAttribute<TAttribute>(this Enum value)
            where TAttribute : Attribute
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            return type.GetField(name) // I prefer to get attributes this way
                .GetCustomAttributes(false)
                .OfType<TAttribute>()
                .SingleOrDefault();
        }

        public static string GetMensagem(this Mensagem value)            
        {
            var name = Enum.GetName(value.GetType(), value);

            var attribute =
           (CustomAttribute)
           typeof(Mensagem)
              .GetField(name)
              .GetCustomAttributes(typeof(CustomAttribute), false).First();

            return attribute.Mensagem;
          
        }
    }
}
