using Microsoft.AspNetCore.Mvc;

namespace PRoRA.Controllers;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Collections;
using System.Text.RegularExpressions;

[ApiController]
[Route("/api/")]
public class EnvVarController : ControllerBase
{
    private readonly ILogger<EnvVarController> logger;
    private readonly CLIOptions cliOptions;

    public EnvVarController(ILogger<EnvVarController> logger,CLIOptions cliOptions)
    {
        this.logger = logger;
        this.cliOptions = cliOptions;
    }

    [HttpGet()]
    [Route("GetEnvVar")]
    public IEnumerable<EnvVar> Get(){
        var regex = new Regex(cliOptions.Regex);
        if(cliOptions.Regex == string.Empty)
            regex = new Regex(@".*"); // 指定がない場合は全許可
        
        return Environment.GetEnvironmentVariables()
                            .Cast<DictionaryEntry>()
                                .Where(x => regex.IsMatch(x.Key?.ToString() ?? string.Empty))
                                .Select(x => new EnvVar(x.Key?.ToString() ?? string.Empty, x.Value?.ToString() ?? string.Empty));
    }

}
