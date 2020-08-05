using System;
using System.ComponentModel.DataAnnotations;
using JLRP.Domain.Dtos;
using Newtonsoft.Json;

namespace JLRP.Domain.Queries
{
    public class GetUserQuery : QueryBase<UserDto>
    {
        public GetUserQuery()
        {
            
        }
        [JsonConstructor]
        public GetUserQuery(Guid userId)
        {
            UserId = userId;
        }

        [JsonProperty("id")]
        [Required]
        public Guid UserId { get; set; }
    }
}
