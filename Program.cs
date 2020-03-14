using System;

namespace ConvertCriptJulioCesar
{
    class Program
    {
        static void Main(string[] args)
        {
            var lModel = Message.GetMessage().Result;
            if (lModel?.cifrado != null)
            {
                lModel.decifrado = EncriptDecript.DecriptMessage(lModel.cifrado.ToLower(), lModel.numero_casas);
                lModel.resumo_criptografico = EncriptDecript.GenerateHashSha1(lModel.decifrado);
                HandleFile.SaveFile("answer.json", lModel);
                string lResponse = Message.PostMessage("answer.json").Result;
                Console.WriteLine(lResponse);
            }else
                Console.WriteLine("Mensagem não foi recebida");
            Console.ReadKey();
        }      
     
    }
}
