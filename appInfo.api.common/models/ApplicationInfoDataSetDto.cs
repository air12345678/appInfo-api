using System.Runtime.InteropServices;
using CloudinaryDotNet.Actions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace appInfo.api.common.models
{
    public class ApplicationInfoDataSetDto
    {
        public string ApplicationName { get; set; } = string.Empty;
        public string RolesName { get; set; } = string.Empty;
        public string ApplicationSMEName { get; set; } = string.Empty;
        public string ApplicationType { get; set; } = string.Empty;
        public IDictionary<string, string>? Databases {get;set;} = new Dictionary<string,string>();
        public string[]? TechStack {get;set;}
        public IDictionary<string, string>? GitRepoistoryPath {get;set;} = new Dictionary<string,string>();
        public string ApplicationURL {get;set;} = string.Empty;
        public string SharepointLink {get;set;} = string.Empty;
        public string ExcelLink {get;set;} = string.Empty;
    }

    public class ApplicationInfoDataSetWithDto : ApplicationInfoDataSetDto{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }
    }
}