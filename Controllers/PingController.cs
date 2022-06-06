using Microsoft.AspNetCore.Mvc;

namespace ping.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class PingController : ControllerBase
{
    private readonly ILogger<PingController> _logger;
    private readonly int dimension;

    public PingController(ILogger<PingController> logger)
    {
        _logger = logger;
        dimension = 10000;
    }

    [HttpGet(Name = "Ping")]
    public OkObjectResult Ping()
    {
        return Ok("ok");
    }

    [HttpGet(Name = "BadPing")]
    public OkObjectResult BadPing()
    {

        var intArrays = new int[dimension][];

        for(var i = 0; i < dimension; i++)
        {

            intArrays[i] = new int[dimension];

            for(var j = 0; j < dimension; j++)
            {
                intArrays[i][j] = i * i;
            }
        }

        var intLists = new List<int>();

        foreach(var intArray in intArrays)
        {
            intLists.AddRange(intArray.ToList());
        }

        return Ok("ok");
    }

    [HttpGet(Name = "GoodPing")]
    public OkObjectResult GoodPing()
    {

        var intArrays = new int[dimension][];

        for(var i = 0; i < dimension; i++)
        {

            intArrays[i] = new int[dimension];

            for(var j = 0; j < dimension; j++)
            {
                intArrays[i][j] = i * i;
            }
        }

        var intArray = new int[dimension * dimension];

        var counter = 0;

        for(var i = 0; i < dimension; i++)
        {
            for(var j = 0; j < dimension; j++)
            {
                intArray[counter] = intArrays[i][j];

                ++counter;
            }
        }

        return Ok("ok");
    }
}