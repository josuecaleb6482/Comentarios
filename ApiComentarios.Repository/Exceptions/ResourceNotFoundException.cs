using System;

namespace ApiComentarios.Repositories.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        public Type ResourceType { get; }

        public ResourceNotFoundException(Type resourceType, string message) : base(message)
        {
            ResourceType = resourceType;
        }
    }
}
