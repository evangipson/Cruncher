using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.HttpResults;
using Domain.Entities;

namespace API.Serializers;

[JsonSerializable(typeof(List<Monster>))]
[JsonSerializable(typeof(ProblemHttpResult))]
internal partial class AppJsonSerializerContext : JsonSerializerContext;
