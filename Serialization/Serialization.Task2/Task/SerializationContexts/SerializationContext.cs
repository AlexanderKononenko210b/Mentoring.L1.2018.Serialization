using System;
using System.Data.Entity.Core.Objects;

namespace Task.SerializationContexts
{
    /// <summary>
    /// Represents a <see cref="SerializationContext"/> class.
    /// </summary>
    public class SerializationContext
    {
        /// <summary>
        /// Gets or sets ObjectContext.
        /// </summary>
        public ObjectContext ObjectContext { get; set; }

        /// <summary>
        /// Gets or sets TypeToSerialize.
        /// </summary>
        public Type TypeToSerialize { get; set; }
    }
}
