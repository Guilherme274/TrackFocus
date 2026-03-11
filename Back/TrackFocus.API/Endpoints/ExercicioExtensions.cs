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
    public static class ExercicioExtensions
    {
        public static void MapExercicioEndpoints(this WebApplication app)
        {

            app.MapPost("/criarExercicio", (ExercicioRequest request, DAL<Exercicio> dal) =>
            {
                var exercicioEntidade = dal.ConverterEmEntidade(request);
                dal.Adicionar(exercicioEntidade);

                var exercicioResposta = dal.ConverterEmResposta<ExercicioResponse>(exercicioEntidade);

                return Results.Created($"/criarExercicio/{exercicioEntidade.Id}", exercicioResposta);
            });

            app.MapGet("/visualizarExercicios", (DAL<Exercicio> dal) =>
            {
                var lista = dal.Listar();
                return Results.Ok(lista);
            });

            app.MapGet("/visualizarExercicios/{id}", (int id, DAL<Exercicio> dal) =>
            {
                var objetoBuscado = dal.ListarPorId(Exercicio => Exercicio.Id == id);
                return Results.Ok(objetoBuscado);
            });

            app.MapPut("/atualizarExercicio", (ExercicioRequest request, DAL<Exercicio> dal) =>
            {
                var exercicioEntidade = dal.ConverterEmEntidade(request);
                dal.Atualizar(exercicioEntidade);
                var exercicioResposta = dal.ConverterEmResposta<ExercicioResponse>(exercicioEntidade);

                return Results.Ok(exercicioResposta);
            });

            app.MapDelete("/deletarExercicio", (ExercicioRequest request, DAL<Exercicio> dal) =>
            {
                var exercicioEntidade = dal.ConverterEmEntidade(request);
                dal.Deletar(exercicioEntidade);
                var exercicioResposta = dal.ConverterEmResposta<ExercicioResponse>(exercicioEntidade);
 
                return Results.Ok(exercicioResposta);
            });
        }
    }
}