using System;
using System.Collections.Generic;
using System.Text;

namespace ClasseJson
{
    public enum Mensagem
    {
        [CustomAttribute("1","Deu bom")]
        item1 = 1,
        [CustomAttribute("2", "Deu bom p")]
        item2 = 2
    }

    public class CustomAttribute : Attribute
    {
        public CustomAttribute(string id, string mensagem)
        {
            this.Id = id;
            Mensagem = mensagem;
        }

        public string Id { get; set; }
        public string Mensagem { get; set; }
    }

  

    public class MensagemJson
    {
        public string Id { get; set; }
        public string Chave { get; set; }
        public string Mensagem { get; set; }
    }
}
