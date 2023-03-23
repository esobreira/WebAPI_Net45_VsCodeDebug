using System.Web.Http;
using System.Web.Configuration;
using System.Web;
using System.Configuration;
using System;

public class ServerDetailsController : ApiController
{
    [HttpGet]
    public IHttpActionResult GetServerDetails()
    {
        // Obtém o objeto do servidor atual
        var server = HttpContext.Current.Server;

        // Obtém o objeto de configuração atual do IIS
        Configuration config = WebConfigurationManager.OpenWebConfiguration("~");

        // Obtém a seção de configuração do sistema web
        SystemWebSectionGroup systemWeb = (SystemWebSectionGroup)config.GetSectionGroup("system.web");

        // Obtém a versão do ASP.NET atualmente em execução no servidor
        string aspNetVersion = systemWeb.Compilation.TargetFramework;

        // Obtém o número de processadores lógicos do servidor
        //int processorCount = server.ProcessorCount;

        // Obtém o tempo máximo de espera da solicitação configurado no servidor
        TimeSpan requestTimeout = TimeSpan.FromSeconds(server.ScriptTimeout);

        // Retorna um objeto JSON com os detalhes do servidor
        return Ok(new ServerDetailsViewModel
        {
            AspNetVersion = aspNetVersion,
            //ProcessorCount = processorCount,
            RequestTimeout = requestTimeout
        });
    }
}

public class ServerDetailsViewModel
{
    public string AspNetVersion { get; set; }
    public int ProcessorCount { get; set; }
    public TimeSpan RequestTimeout { get; set; }
    public string ApplicationName {get;set;}
    
    private int _value;
    public int Value { 
        get {
            return 100;
        }
        set {
            _value = value;
        }
     }
    public DateTime CurrentDate => DateTime.Now;
    public int CurrentValue { get; set; }
}
