using System.Security.Claims;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticAssets;
using Microsoft.IdentityModel.Tokens;
using TrackFocus.Application.DTOs.Request;
using TrackFocus.Application.DTOs.Response;
using TrackFocus.Application.Service;
using TrackFocus.Domain.Entities;
using TrackFocus.Infraestructure.Data;

namespace TrackFocus.API.Endpoints
{
    public static class TreinoExtensions
    {
        public static void MapTreinoEndpoints(this WebApplication app)
        {

            app.MapPost("/criarTreino", ([FromBody] TreinoRequest request, [FromServices] DAL<Treino> dal, ClaimsPrincipal user) =>
            {
                try
                {                                    
                    var userId = user.GetUserId();
                    var treinoEntidade = dal.ConverterEmEntidade(request);
                    
                    treinoEntidade.UserId = userId;                    

                    treinoEntidade.Id = 0;

                    foreach (var exercicio in treinoEntidade.Exercicios ?? Enumerable.Empty<Exercicio>())
                    {
                        exercicio.Id = 0;
                        exercicio.Treino = treinoEntidade;  // 👈 Importante: seta a navegação
                        exercicio.TreinoId = 0;  // Será atualizado pelo EF Core

                        foreach (var serie in exercicio.ExerciciosMusculacao ?? Enumerable.Empty<Serie_Musculacao>())
                        {
                            serie.Id = 0;
                            serie.Exercicio = exercicio;
                            serie.ExercicioId = 0;
                        }
            
                        foreach (var cardio in exercicio.ExerciciosCardio ?? Enumerable.Empty<Cardio>())
                        {
                            cardio.Id = 0;
                            cardio.Exercicio = exercicio;
                            cardio.ExercicioId = 0;
                        }

                    }

                    dal.Adicionar(treinoEntidade);

                    var treinoResposta = dal.ConverterEmResposta<TreinoResponse>(treinoEntidade);

                    return Results.Created($"/criarTreino/{treinoEntidade.Id}", treinoResposta);
                }
                catch(Exception ex)
                {
                    return Results.Problem($"Erro ao criar treino: {ex.Message}");
                }
            })
            .RequireAuthorization();

            app.MapGet("/visualizarTreinos", (DAL<Treino> dal) =>
            {
                var lista = dal.Listar();

                var listaResposta = dal.ListaParaResposta<TreinoResponse>(lista);

                return Results.Ok(listaResposta);
            });

            app.MapGet("/visualizarTreinos/{id}", (int id, [FromServices] DAL<Treino> dal) =>
            {
                var objetoBuscado = dal.ListarPorId(treino => treino.Id == id);

                var objetoBuscadoResposta = dal.ConverterEmResposta<TreinoResponse>(objetoBuscado);
                return Results.Ok(objetoBuscadoResposta);
            });

            app.MapPut("/atualizarTreino", ([FromBody] TreinoRequest request, [FromServices] DAL<Treino> dal) =>
            {
                var treinoEntidade = dal.ConverterEmEntidade(request);
                dal.Atualizar(treinoEntidade);
                var treinoResposta = dal.ConverterEmResposta<TreinoResponse>(treinoEntidade);

                return Results.Ok(treinoResposta);
            });

            app.MapDelete("/deletarTreino/{id}", (int id, [FromServices] DAL<Treino> dal) =>
            {
                var objetoBuscado = dal.ListarPorId(treino => treino.Id == id);
                dal.Deletar(objetoBuscado);
 
                return Results.Ok();
            });
        }
    }
}