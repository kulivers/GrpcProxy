using System;
using System.Collections.Generic;

namespace ApiDescriptions.Rest
{
    public enum HttpMethod
    {
        Get,
        Post,
        Delete,
        Put,
        Head,
        Options,
        Patch,
    }
    public class RestMethodDescription
    {
        public string Name { get; set; }
        public IEnumerable<string> Routes { get; set; } //todo
        public HttpMethod Method { get; set; }
        public IEnumerable<PropertyDescription> BodyDescription { get; set; }
    }

    
    public struct PropertyDescription 
    {
        public Type Type { get; set; }
        public string Name { get; set; }
    }
}