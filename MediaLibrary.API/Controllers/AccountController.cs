using MediaLibrary.Application.Features.AccountFeatures.Commands;
using MediaLibrary.Application.Features.BookFeatures.Commands;
using MediaLibrary.Application.Implementations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace MediaLibrary.API.Controllers;

/// <summary>
/// Account/Users/Login Controller
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    public IMediator _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();


    /// <summary>
    /// Confirm the Email of the Account
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpGet("ConfirmEmail")]
    [Authorize]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> ConfirmEmail(ConfirmEmailAccountCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }

    /// <summary>
    /// Register new Account/User
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost("Register")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(409)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Create(RegisterAccountCommand command)
    {
        command.Origin = GetOriginUri();
        await Mediator.Send(command);
        return NoContent();
    }

    /// <summary>
    /// Login Account and return Token
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost("Login")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Login(LoginAccountCommand command)
    {
        command.IpAddress = GetRequestIp();
        return Ok(await Mediator.Send(command));
    }

    /// <summary>
    /// Forgot Password API
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost("ForgotPassword")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordAccountCommand command)
    {
        command.Origin = GetOriginUri();
        await Mediator.Send(command);
        return NoContent();
    }
    
    /// <summary>
    /// Reset Password Method
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost("ResetPassword")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> ResetPassword(ResetPasswordAccountCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }

    /// <summary>
    /// Change Password Method
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost("ChangePassword")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> ChangePassword(ChangePasswordAccountCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }

    /// <summary>
    /// Resend Verification URL
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost("ResendVerification")]
    [Authorize]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> ResendVerification(ResendVerificationAccountCommand command)
    {
        command.Origin = GetOriginUri();
        await Mediator.Send(command);
        return NoContent();
    }

    /// <summary>
    /// Refresh User token and get a new one
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost("RefreshToken")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> RefreshToken(RefreshTokenAccountCommand command)
    {
        command.IpAddress = GetRequestIp();
        return Ok(await Mediator.Send(command));
    }
    
    /// <summary>
    /// Revoke refresh token of the account
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost("RevokeToken")]
    [Authorize("SUPERADMIN")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> RevokeToken(RevokeTokenAccountCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }
    
    /// <summary>
    /// Revoke Refresh Tokens of all accounts
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost("RevokeAllTokens")]
    [Authorize("SUPERADMIN")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> RevokeAllTokens(RevokeAllAccountCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }

    private string GetOriginUri() => Request.Headers.Origin.ToString() ?? "";
    private string GetRequestIp() => ChooseIp() ?? "";
    private string? ChooseIp() => Request.Headers.ContainsKey("X-Forwarded-For") ? 
        Request.Headers["X-Forwarded-For"] : 
        HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();

}
