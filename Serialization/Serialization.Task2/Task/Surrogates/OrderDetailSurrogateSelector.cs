using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Task.DB;

namespace Task.Surrogates
{
    /// <summary>
    /// Represents a <see cref="OrderDetailSurrogateSelector"/> class.
    /// </summary>
    public class OrderDetailSurrogateSelector : ISurrogateSelector
    {
        private ISurrogateSelector _nextSelector;

        ///<inheritdoc/>
        public void ChainSelector(ISurrogateSelector selector)
        {
            _nextSelector = selector;
        }

        ///<inheritdoc/>
        public ISurrogateSelector GetNextSelector()
        {
            return _nextSelector;
        }

        ///<inheritdoc/>
        public ISerializationSurrogate GetSurrogate(Type type, StreamingContext context, out ISurrogateSelector selector)
        {
            selector = this;

            if (type == typeof(Order_Detail)) return new OrderDetailSerializationSurrogate();

            return null;
        }
    }
}
