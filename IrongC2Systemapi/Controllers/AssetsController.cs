using Microsoft.AspNetCore.Mvc;
using IrongC2Systemapi.context;
using IrongC2Systemapi.Model;
namespace IrongC2Systemapi.Controllers;

[ApiController]
[Route("[controller]")]
public class AssetsController : ControllerBase
{
    private IrongC2SystemapiDbContext _context;

    public AssetsController(IrongC2SystemapiDbContext context)
    {  
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Assets>> GetFindAssetsAsync(int id)
    {
        var data = await _context.Assets.FindAsync(id);
        if (data == null)
        {
            return NotFound(data);
        }
        return Ok(data);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAsitsAsync(int id, [FromBody]UpdateAssetsDTo assetsDTo)
    {
        var Data = await _context.Assets.FindAsync(id);
        if(Data == null)
        {
            return NotFound(Data);
        }

        if (assetsDTo == null)
        
        return Ok();

        if(assetsDTo.AssetSerial != null)
        {
            Data.AssetSerial = assetsDTo.AssetSerial;
        }

        if(assetsDTo.Type != null)
        {
            Data.Type = assetsDTo.Type;
        }
        _context.SaveChanges();
        return Ok();

    }
}