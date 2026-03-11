using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticAssets;
using TrackFocus.Application.DTOs.Security.Request;
using TrackFocus.Application.DTOs.Security.Response;
using TrackFocus.Application.Service;
using TrackFocus.Domain.Entities;

namespace TrackFocus.API.Endpoints
{
    public static class UserExtensions
    {
        public static void MapUserEndpoints(this WebApplication app)
        {
            app.MapPost("/register", async (RegisterRequest request, IUserService userService) =>
            {
                await userService.RegisterUserAsync(request);

                return Results.Created();
            });

            app.MapPost("/login", async (LoginRequest request, IUserService userService) =>
            {
                var response = await userService.LoginUserAsync(request);

                return Results.Ok(response);
            });
        }
    }
}